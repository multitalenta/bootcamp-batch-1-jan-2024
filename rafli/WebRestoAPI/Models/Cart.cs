using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRestoAPI.Models;

public partial class Cart
{
    [Key]
    public long Id { get; set; }

    public string Nama { get; set; } = null!;

    public int NoMeja { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;
}
