using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class RolePrintAsExcelCommand : WbSortFilterPageOptions,
    IRequest<byte[]>
{ }
