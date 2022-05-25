namespace BLENDSEASONINGS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Total { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string Expiration { get; set; }
        public string BillingZip { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string Weight { get; set; }

    }
}
