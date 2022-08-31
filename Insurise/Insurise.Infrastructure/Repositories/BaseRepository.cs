using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Insurise.Infrastructure.Data;
using Insurise.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Insurise.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;
    private readonly ISpecificationEvaluator specificationEvaluator;

    public BaseRepository(AppDbContext dbContext)
        : this(dbContext, SpecificationEvaluator.Default)
    {
    }


    /// <inheritdoc/>
    public BaseRepository(AppDbContext dbContext, ISpecificationEvaluator specificationEvaluator)
    {
        _dbContext = dbContext;
        this.specificationEvaluator = specificationEvaluator;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _dbContext.Set<T>()
            .FindAsync(new object?[] {id}, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<T?> GetBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default)
        where Spec : ISpecification<T>, ISingleResultSpecification
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<TResult?> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    public virtual async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Filters the entities  of <typeparamref name="T"/>, to those that match the encapsulated query logic of the
    /// <paramref name="specification"/>.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered entities as an <see cref="IQueryable{T}"/>.</returns>
    protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification,
        bool evaluateCriteriaOnly = false)
    {
        return specificationEvaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), specification, evaluateCriteriaOnly);
    }

    public virtual async Task<List<T>> ListAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        return specification.PostProcessingAction == null
            ? queryResult
            : specification.PostProcessingAction(queryResult).ToList();
    }

    /// <inheritdoc/>
    public virtual Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
        //var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        //return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
    }

    /// <inheritdoc/>
    public virtual async Task<int> CountAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification, true).CountAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().CountAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<bool> AnyAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification, true).AnyAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().AnyAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().AnyAsync(predicate);
    }
    //public async virtual Task<T> CreateOrUpdateAsync<TId>(T entity, TId id)
    //{
    //    bool exists = await Exists(x => x.id.Equals(id));
    //    if (entity.Id.Equals(0) && exists)
    //    {
    //        _ = UpdateAsync(entity);
    //    }
    //    else
    //    {
    //        _ = AddAsync(entity);
    //    }
    //    return entity;
    //}
}
