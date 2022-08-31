using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;

namespace Insurise.Application.Contracts.Persistence;

public interface IWarrantyRepository : IRepository<Warranty>
{
    Task<List<Warranty>> GetWarrantyWithFeatures(bool includePassedFeatures);
}