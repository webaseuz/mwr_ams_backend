using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class UserTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
