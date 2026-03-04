using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransmissionBoxTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}