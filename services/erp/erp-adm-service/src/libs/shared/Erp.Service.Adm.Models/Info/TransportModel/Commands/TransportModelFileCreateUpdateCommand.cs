namespace Erp.Service.Adm.Models;

public class TransportModelFileCreateUpdateCommand
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public int TransportColorId { get; set; }
}
