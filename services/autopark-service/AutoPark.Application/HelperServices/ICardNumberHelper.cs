namespace AutoPark.Application.HelperService;

public interface ICardNumberHelper
{
    public string GetMasked(string cardNumber);
}
