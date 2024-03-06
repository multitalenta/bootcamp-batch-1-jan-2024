using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRestoAPI.Models;

public partial class Product
{
    [Key]
    public long Id { get; set; }

    public string? Kode { get; set; }

    public string Nama { get; set; } = null!;

    public decimal Harga { get; set; }

    public string Keterangan { get; set; } = null!;

    public bool IsReady { get; set; }

    public string? Gambar { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

}
