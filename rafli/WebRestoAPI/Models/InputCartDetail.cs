namespace WebRestoAPI.Models
{
    public class InputCartDetail
    {
        public long Id { get; set; }
        public long? Cart_Id { get; set; }

        public long Product_Id { get; set; }

        public int Qty { get; set; }

        public decimal TotalHarga { get; set; }

        public string Catatan { get; set; } = null!;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

