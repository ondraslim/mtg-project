using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Common.Query
{
    public interface IAppQuery<TResult>
    {

        IList<TResult> Execute();
        Task<IList<TResult>> ExecuteAsync();
        int GetTotalRowCount();
        Task<int> GetTotalRowCountAsync();
    }
}