using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Application.UseCases.Banks;

public class BankDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string OrderCode { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Required]
    [StringLength(5)]
    public string BankCode { get; set; } = null!;
    [Required]
    public int StateId { get; set; }
    public string StateName {  get; set; } = null!;
    public List<BankTranslateDto> Translates { get; set; } = new();
}
