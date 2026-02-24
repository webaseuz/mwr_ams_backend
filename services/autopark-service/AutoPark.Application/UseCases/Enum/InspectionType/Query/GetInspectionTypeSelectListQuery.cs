using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInspectionTypeSelectListQuery : IRequest<SelectList<int>>
{ }