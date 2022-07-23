using System.Threading;
using System.Threading.Tasks;

namespace NPay.Shared.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}