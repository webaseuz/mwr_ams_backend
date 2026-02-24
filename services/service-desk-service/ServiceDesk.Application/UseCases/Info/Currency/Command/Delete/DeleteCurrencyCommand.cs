using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Currencies;

public class DeleteCurrencyCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}