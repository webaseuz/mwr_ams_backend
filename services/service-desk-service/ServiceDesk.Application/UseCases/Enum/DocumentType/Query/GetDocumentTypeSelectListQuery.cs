using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DocumentTypes;

public class GetDocumentTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
