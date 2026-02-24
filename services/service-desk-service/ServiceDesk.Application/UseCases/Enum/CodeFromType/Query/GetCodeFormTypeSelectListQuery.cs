using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.CodeFromTypes;

public class GetCodeFromTypeBriefListQuery :
    IRequest<SelectList<int>>
{
}
