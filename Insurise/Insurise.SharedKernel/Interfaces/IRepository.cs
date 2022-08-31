using Ardalis.Specification;

namespace Insurise.SharedKernel.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}