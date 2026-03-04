using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class LanguageSelectListQuery : IRequest<WbSelectList<int, LanguageSelectListDto>>
{
}
