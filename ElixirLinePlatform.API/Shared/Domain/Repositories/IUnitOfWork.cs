using System.Threading.Tasks;

namespace ElixirLinePlatform.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}