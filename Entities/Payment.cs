using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }

        [Column(TypeName = "Money")]
        public double TotalBill { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardType CardType { get; set; }

        [MaxLength(16)]
        public string CardNumber { get; set; }
        public DateTime CardExpireDate { get; set; }

        [MaxLength(3)]
        public string CardCVC { get; set; }

        public virtual Guest Guest { get; set; }


    }
}
