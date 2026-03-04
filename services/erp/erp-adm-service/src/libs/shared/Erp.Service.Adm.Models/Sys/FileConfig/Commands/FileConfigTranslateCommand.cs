using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class FileConfigTranslateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
