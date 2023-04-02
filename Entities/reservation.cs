using HotelManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem;

public partial class Reservation
{
    [Key]
    public int ReservationID { get; set; }

    public int NumberOfGuests { get; set; }
    
    public DateTime ArrivalTime { get; set; }

    public DateTime LeavingTime { get; set; }

    public bool CheckedIn { get; set; }

    public int Breakfast { get; set; }

    public int Lunch { get; set; }

    public int Dinner { get; set; }

    public bool Cleaning { get; set; }

    public bool Towel { get; set; }

    public bool SSurprise { get; set; }

    public bool SupplyStatus { get; set; }

    public int FoodBill { get; set; }

    public virtual Guest Guest { get; set; }
    public virtual Room Room { get; set; }
}