using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Contractors;

public class GetContractorTypeSelectListQuery : IRequest<SelectList<long>>
{ }

