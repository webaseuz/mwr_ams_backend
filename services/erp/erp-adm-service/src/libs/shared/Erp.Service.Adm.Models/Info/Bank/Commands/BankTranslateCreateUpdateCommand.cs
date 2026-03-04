using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class BankTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
