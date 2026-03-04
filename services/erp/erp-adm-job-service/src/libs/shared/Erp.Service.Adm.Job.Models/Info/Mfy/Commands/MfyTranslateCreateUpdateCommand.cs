using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class MfyTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
