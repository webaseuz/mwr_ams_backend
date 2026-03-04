using WEBASE;

namespace Erp.Adm.Bff.Web.Application;

public interface IMainAuthService : IWbAuthService
{
    string UserName { get; }
}
