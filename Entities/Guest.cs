using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    
    public class Guest
    {

        public int GuestID { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }

        [MaxLength(40)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string StreetAddress { get; set; }

        public int ApartmentSuite { get; set; }

        [MaxLength(20)]
        public virtual City City { get; set; }

        [MaxLength(20)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }

    }

}
