using Erp.Core.Extensions;
using System.Text.Json.Serialization;


namespace Erp.Service.Adm.Models;

public class ErrorScopeListDto
{
    public long Id { get; set; }

    public string AppName { get; set; }

    public string NormalizedPath { get; set; }

    public string Type { get; set; }

    public string Title { get; set; }

    public string Code { get; set; }

    public bool? IsFixed { get; set; }

    public string ScopeKey { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    //[JsonConverter(typeof(DateTimeMinuteNullableConverter))]
    public DateTime? LastOccuredAt { get; set; }

    public int Count { get; set; }

    public DateTime? FixedAt { get; set; }

    public bool CanFix { get; set; }
}
