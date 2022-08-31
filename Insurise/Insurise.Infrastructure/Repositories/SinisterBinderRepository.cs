using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Infrastructure.Data;
using Insurise.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Infrastructure.Repositories
{
    public class SinisterBinderRepository : BaseRepository<SinisterBinder>, IRepository<SinisterBinder>
    {
        public SinisterBinderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
