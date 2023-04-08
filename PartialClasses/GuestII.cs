using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Guest
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
