using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverDocumentCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public int OwnerId { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public DateTime? DocumentEndOn { get; set; }
    public Guid? DocumentFileId { get; set; }
    public string DocumentFileName { get; set; }
}
