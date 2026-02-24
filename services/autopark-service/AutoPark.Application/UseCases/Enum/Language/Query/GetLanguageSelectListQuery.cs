using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Languages;

public class GetLanguageSelectListQuery :
    IRequest<SelectList<int>>
{
}
