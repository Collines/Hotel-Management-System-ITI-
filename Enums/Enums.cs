
namespace HotelManagementSystem
{
    public enum Gender : byte
    {
        Male=1,
        Female
    }
    public enum RoomType : byte
    {
        Single=1,
        Double,
        Duplex,
        Suite
    }

    public enum PaymentType : byte
    {
        Credit=1,
        Debit
    }

    public enum CardType : byte
    {
        Unknown = 0,
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
    public enum AccountType:byte
    {
        KitchenAccount,
        FrontendAccount
    }
}
