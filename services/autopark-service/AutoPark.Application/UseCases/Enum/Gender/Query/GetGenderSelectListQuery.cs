using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Genders;

public class GetGenderSelectListQuery :
    IRequest<SelectList<int>>
{
}
