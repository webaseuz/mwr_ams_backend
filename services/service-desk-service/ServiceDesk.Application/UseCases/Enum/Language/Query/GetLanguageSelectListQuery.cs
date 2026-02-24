using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Languages;

public class GetLanguageSelectListQuery :
    IRequest<SelectList<int>>
{
}
