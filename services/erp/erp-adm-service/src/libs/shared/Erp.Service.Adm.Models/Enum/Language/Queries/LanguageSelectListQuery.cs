using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class LanguageSelectListQuery : IRequest<WbSelectList<int>>
{
}