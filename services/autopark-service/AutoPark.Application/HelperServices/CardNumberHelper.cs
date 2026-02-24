namespace AutoPark.Application.HelperService;

public class CardNumberHelper : ICardNumberHelper
{
    public string GetMasked(string cardNumber)
    {
        if (cardNumber == null)
            return cardNumber;

        return new string(cardNumber.Select((ch, idx) => idx > 3 && idx < 12 ? '*' : ch).ToArray());

    }
}
