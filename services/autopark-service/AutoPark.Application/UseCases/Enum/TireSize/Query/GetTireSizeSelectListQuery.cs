using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeSelectListQuery :
    IRequest<SelectList<int>>
{
}

