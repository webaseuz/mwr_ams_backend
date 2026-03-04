using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TableTranslateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
