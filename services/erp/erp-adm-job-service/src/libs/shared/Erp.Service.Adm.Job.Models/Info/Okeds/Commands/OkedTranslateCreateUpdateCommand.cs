using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OkedTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
