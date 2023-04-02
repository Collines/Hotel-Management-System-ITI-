using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem;

[Index(nameof(Frontend.Username), IsUnique = true)]
public partial class Frontend
{
    public int ID { get; set; }

    [MaxLength(50)]
    public string Username { get; set; }
    [MaxLength(128)]
    public string Password { get; set; }
    [MaxLength(128)]
    public string Salt { get; set; }
}