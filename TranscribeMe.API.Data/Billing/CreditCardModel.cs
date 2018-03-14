namespace TranscribeMe.API.Data.Billing
{
    public class CreditCardModel
    {
        public string Last4 { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public string CardType { get; set; }
    }
}