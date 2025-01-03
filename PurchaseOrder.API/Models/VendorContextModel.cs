﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseOrder.API.Models;

[Table("Vendor")]
public class VendorContextModel
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public string ContactName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }
}
