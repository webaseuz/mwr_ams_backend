using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationalFormTranslateCreateUpdateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
