using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.DocumentTypes;

public class GetDocumentTypeSelectListQuery :
    IRequest<SelectList<int>>
{
}
