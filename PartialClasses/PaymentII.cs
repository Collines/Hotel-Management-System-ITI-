using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Payment
    {
        public static implicit operator bool(Payment P)
        {
            if (P.CardNumber.IsNullOrEmpty() || P.CardCVC.IsNullOrEmpty() || P.ExpireMonth > 11 || P.ExpireYear < DateTime.Now.Year || P.CurrentBill==0) { return false; }
            else return true;
        }
    }
}
