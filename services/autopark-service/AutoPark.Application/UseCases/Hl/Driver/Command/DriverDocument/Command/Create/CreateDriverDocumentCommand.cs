using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class CreateDriverDocumentCommand :
    IRequest<IHaveId<long>>
{
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public Guid? DocumentFileId { get; set; }
    public string DocumentFileName { get; set; }
    public DateTime? DocumentEndOn { get; set; }
}
