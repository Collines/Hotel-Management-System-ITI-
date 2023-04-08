using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Payment
    {
        public CardType GetCardType()
        {
            Regex VisaRegEX = new("^4[0-9]{6,}$");
            Regex MastercardRegEX = new("^5[1-5][0-9]{5,}|222[1-9][0-9]{3,}|22[3-9][0-9]{4,}|2[3-6][0-9]{5,}|27[01][0-9]{4,}|2720[0-9]{3,}$");
            Regex DiscoverRegEX = new("^6(?:011|5[0-9]{2})[0-9]{3,}$");
            if (VisaRegEX.Matches(CardNumber).Count > 0)
                return HotelManagementSystem.CardType.Visa;
            else if (MastercardRegEX.Matches(CardNumber).Count > 0)
                return HotelManagementSystem.CardType.Mastercard;
            else if (DiscoverRegEX.Matches(CardNumber).Count > 0)
                return HotelManagementSystem.CardType.Discover;
            else
                return HotelManagementSystem.CardType.Unknown;
        }
    }
}
