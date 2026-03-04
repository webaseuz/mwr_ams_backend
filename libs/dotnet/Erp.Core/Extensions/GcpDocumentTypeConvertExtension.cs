using Erp.Core.Constants;

namespace Erp.Core.Extensions;
public static class GcpDocumentTypeConvertExtension
{
    public static int GetId(string documentType)
    {
        return documentType switch
        {
            "BIRTH_CERTS" => GcpDocumentTypeIdConst.IDMS_RECV_MJ_BIRTH_CERTS,
            "IDCARD_CITIZEN" => GcpDocumentTypeIdConst.IDMS_RECV_MVD_IDCARD_CITIZEN,
            _ => 6 // default qiymat Id karta
        };
    }
}
