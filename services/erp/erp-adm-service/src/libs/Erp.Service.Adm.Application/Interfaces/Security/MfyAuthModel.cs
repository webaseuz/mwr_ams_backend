using Erp.Core.Security;

namespace Erp.Service.Adm.Application;

public class MfyAuthModel : IMfyAuthModel
{
    public int MfyId { get; set; }
    public string Mfy { get; set; }
}
