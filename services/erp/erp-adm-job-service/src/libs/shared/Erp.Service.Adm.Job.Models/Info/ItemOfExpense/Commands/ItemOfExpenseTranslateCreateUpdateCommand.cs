using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
