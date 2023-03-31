#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem;

public partial class Frontend
{
    public int ID { get; set; }

    [MaxLength(50)]
    public string Username { get; set; }
    [MaxLength(64)]
    public string Password { get; set; }
}