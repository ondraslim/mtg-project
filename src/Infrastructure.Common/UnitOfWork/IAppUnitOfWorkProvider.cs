using Riganti.Utils.Infrastructure.Core;

namespace Infrastructure.Common
{
    public interface IAppUnitOfWorkProvider : IUnitOfWorkProvider
    {
        IUnitOfWork Create();
    }
}