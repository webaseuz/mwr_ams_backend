using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class QrCodeStateSelectListQuery : IRequest<WbSelectList<int>>
{
}