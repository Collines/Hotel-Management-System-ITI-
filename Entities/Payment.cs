using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Payment
    {
        public int PaymentID { get; set; }


        [Column(TypeName = "Money")]
        public double Foodbill { get; set; }

        [Column(TypeName = "Money")]
        public double CurrentBill { get; set; }

        [Column(TypeName = "Money")]
        public double Tax { get; set; }

        public int PaymentType { get; set; }
        public int CardType { get; set; }

        [MaxLength(16)]
        public string CardNumber { get; set; }
        public int ExpireYear { get; set; }
        public int ExpireMonth { get; set;}

        [MaxLength(3)]
        public string CardCVC { get; set; }
    }
}
