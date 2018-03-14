namespace TranscribeMe.API.Data.Billing
{
    public class BillingAddressModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public NamedEntityModel Country { get; set; }

        public NamedEntityModel State { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }
}