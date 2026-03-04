using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class PersonSelectListQuery : IRequest<WbSelectList<int, PersonSelectListDto>>;
