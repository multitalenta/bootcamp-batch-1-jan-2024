using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRestoAPI.Models;

public partial class OrderDetail
{
    [Key]
    public long Id { get; set; }

    [ForeignKey("Order")]
    public long? Order_Id { get; set; }
    public Order Order { get; set; }

    [ForeignKey("Product")]
    public long? Product_Id { get; set; }
    public Product Product { get; set; }

    public int Qty { get; set; }

    public decimal TotalHarga { get; set; }

    public string Catatan { get; set; } = null!;

    public DateTime DateCreated { get; set; } = DateTime.Now;

}
