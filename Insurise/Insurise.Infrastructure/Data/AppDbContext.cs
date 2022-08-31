using System.Reflection;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Insurise.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator,
        IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      
    }
    protected void SeedData(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Branch>().HasData(
          new Branch("Automobile", "Automobile") ,
             new Branch("Divers", "Divers")
             );
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var modifiedOrCreatedBy = _httpContextAccessor.HttpContext.User.Identity?.Name ?? "System";
        var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        // ignore events if no dispatcher provided
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditedEntityBase && e.State is EntityState.Added or EntityState.Modified);


        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((IAuditedEntityBase) entityEntry.Entity).CreatedDate = DateTime.Now;
                ((IAuditedEntityBase) entityEntry.Entity).CreatedBy = modifiedOrCreatedBy;
                ((IAuditedEntityBase) entityEntry.Entity).IsDeleted = false;
            }
            else
            {
                Entry((IAuditedEntityBase) entityEntry.Entity).Property(p => p.CreatedDate).IsModified = false;
                Entry((IAuditedEntityBase) entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
            }

            ((IAuditedEntityBase) entityEntry.Entity).IpAddress = ipAddress;
            ((IAuditedEntityBase) entityEntry.Entity).LastModifiedDate = DateTime.Now;
            ((IAuditedEntityBase) entityEntry.Entity).LastModifiedBy = modifiedOrCreatedBy;
        }

        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var entitiesWithEvents = ChangeTracker
            .Entries()
            .Select(e => e.Entity as BaseEntity<Guid>)
            .Where(e => e?.Events != null && e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            if (entity == null) continue;
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
                await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
   
}
