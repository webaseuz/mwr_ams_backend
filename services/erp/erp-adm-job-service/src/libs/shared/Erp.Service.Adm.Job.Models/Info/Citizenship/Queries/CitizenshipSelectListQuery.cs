using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class CitizenshipSelectListQuery : IRequest<WbSelectList<int, CitizenshipSelectListDto>>
{ }
