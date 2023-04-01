using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem;

public partial class Reservation
{
    [Key]
    public int ReservationID { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public Gender Gender { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    [MaxLength(50)]
    public string Email { get; set; }

    public int NumberOfGuests { get; set; }

    [MaxLength(50)]
    public string StreetAddress { get; set; }

    public int ApartmentSuite { get; set; }

    [MaxLength(20)]
    public string City { get; set; }

    [MaxLength(20)]
    public string State { get; set; }

    [MaxLength(10)]
    public string ZipCode { get; set; }

    public RoomType RoomType { get; set; }

    public int RoomFloor { get; set; }

    public int RoomNumber { get; set; }
    [Column(TypeName ="Money")]
    public double TotalBill { get; set; }

    public PaymentType PaymentType { get; set; }

    public CardType CardType { get; set; }
    [MaxLength(16)]
    public string CardNumber { get; set; }

    public DateTime CardExpireDate { get; set; }

    [MaxLength(3)]
    public string CardCVC { get; set; }

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
}