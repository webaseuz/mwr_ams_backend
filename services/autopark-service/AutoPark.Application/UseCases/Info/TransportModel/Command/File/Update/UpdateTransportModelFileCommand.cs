namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelFileCommand
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public int? TransportModelId { get; set; }
    public int? TransportColorId { get; set; }
}
