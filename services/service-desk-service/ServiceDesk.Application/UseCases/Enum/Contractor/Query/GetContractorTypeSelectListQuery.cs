using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Contractors;

public class GetContractorTypeSelectListQuery : IRequest<SelectList<long>>
{ }

