using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduYearSelectListQuery : IRequest<WbSelectList<int, EduYearSelectListDto>>
{}
