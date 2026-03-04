using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class BankSelectListQuery : IRequest<WbSelectList<int>>
{}
