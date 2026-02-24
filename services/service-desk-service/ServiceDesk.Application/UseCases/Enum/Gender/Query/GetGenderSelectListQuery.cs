using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Genders;

public class GetGenderSelectListQuery :
    IRequest<SelectList<int>>
{
}
