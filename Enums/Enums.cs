
namespace HotelManagementSystem
{
    public enum Gender : byte
    {
        Male,
        Female
    }
    public enum RoomType
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

    public enum CardType
    {
        Unknown = -1,
        Visa,
        Mastercard,
        Discover
    }

    public enum Months : byte
    {
        January,
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
