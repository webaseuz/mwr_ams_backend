using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class QrCodeTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}