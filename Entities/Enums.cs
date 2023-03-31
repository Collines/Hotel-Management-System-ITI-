using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public enum Gender : byte
    {
        Male,
        Female
    }
    public enum RoomType : byte
    {
        Single,
        Double,
        Duplex,
        Suite
    }

    public enum PaymentType : byte
    {
        Credit,
        Debit
    }

    public enum CardType : byte
    {
        Visa,
        Mastercard,
        Discover
    }

    public enum Months : byte
    {
        January=1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
}
