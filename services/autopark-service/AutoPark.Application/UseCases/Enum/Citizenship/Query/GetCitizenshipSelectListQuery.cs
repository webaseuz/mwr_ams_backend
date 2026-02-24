using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class GetCitizenshipSelectListQuery :
    IRequest<SelectList<int>>
{
}
