using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;

namespace Insurise.Core.Repositories.Interfaces;

public interface IChainElementRepository : IRepository<ChainElement>
{
    Task<Chain?> GetChainAsync(int Id, bool includeChainElements);
    Task AddElementForChainAsync(int chainId, ChainElement chainElement);
}