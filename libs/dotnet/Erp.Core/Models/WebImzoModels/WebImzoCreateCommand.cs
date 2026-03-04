using MediatR;
using Newtonsoft.Json;
using WbImzo.Models;

namespace Erp.Core;

public class WebImzoCreateCommand : IRequest<WbImzoSignInformResponseDto>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("secretKey")]
    public string SecretKey { get; set; }

    //[JsonProperty("title")]
    //public string Title { get; set; } = string.Empty;

    [JsonProperty("tableId")]
    public int TableId { get; set; }

    [JsonProperty("documentId")]
    public long? DocumentId { get; set; }

    //[JsonProperty("documentIdAsString")]
    //public string DocumentIdAsString { get; set; } = string.Empty;

    //[JsonProperty("documentType")]
    //public string DocumentType { get; set; } = string.Empty ;

    //[JsonProperty("signDataTypeId")]
    //public int SignDataTypeId { get; set; }

    //[JsonProperty("signData")]
    //public string SignData { get; set; } = string.Empty;

    //[JsonProperty("signerUserCount")]
    //public int SignerUserCount { get; set; }

    //[JsonProperty("signedUserCount")]
    //public int SignedUserCount { get; set; }

    //[JsonProperty("haveMoreSignUser")]
    //public bool HaveMoreSignUser { get; set; }

    //[JsonProperty("previewPrintableLink")]
    //public string PreviewPrintableLink { get; set; } = string.Empty;

    //[JsonProperty("printableLink")]
    //public string PrintableLink { get; set; } = string.Empty;

    //[JsonProperty("printableLinkExt")]
    //public string PrintableLinkExt { get; set; } = string.Empty;

    //[JsonProperty("organizationName")]
    //public string OrganizationName { get; set; } = string.Empty;

    //[JsonProperty("organizationInn")]
    //public string OrganizationInn { get; set; } = string.Empty;

    //[JsonProperty("isVisibleToOthers")]
    //public bool IsVisibleToOthers { get; set; }

    //[JsonProperty("smsInformed")]
    //public bool SmsInformed { get; set; }

    //[JsonProperty("signCheckUrl")]
    //public string SignCheckUrl { get; set; } = string.Empty;

    [JsonProperty("signRequestUsers")]
    public WbImzoSignRequestUserDto SignRequestUser { get; set; }


    [JsonProperty("signatureMethods")]
    public List<WbImzoSignatureMethodDto> SignatureMethods { get; set; } = new List<WbImzoSignatureMethodDto>();
}

