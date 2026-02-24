using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.CodeFromTypes;

public class GetCodeFromTypeBriefListQuery :
    IRequest<SelectList<int>>
{
}
