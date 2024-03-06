namespace WebRestoAPI.Models
{
    public class InputOrderDetail
    {
        public long Id { get; set; }
        public long? Order_Id { get; set; }

        public long Product_Id { get; set; }

        public int Qty { get; set; }

        public decimal? TotalHarga { get; set; }

        public string? Catatan { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
