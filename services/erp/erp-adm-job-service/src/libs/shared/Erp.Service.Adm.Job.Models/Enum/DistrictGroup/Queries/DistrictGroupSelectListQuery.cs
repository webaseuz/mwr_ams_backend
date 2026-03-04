using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DistrictGroupSelectListQuery : IRequest<WbSelectList<int, DistrictGroupSelectListDto>>
{}
