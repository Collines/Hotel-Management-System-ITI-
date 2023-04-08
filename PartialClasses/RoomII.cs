using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Room
    {
        public override bool Equals(object? obj)
        {
            if(obj != null && obj is Room room)
                return RoomNumber == room.RoomNumber;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(RoomNumber, RoomID);
        }

        public override string ToString()
        {
            return RoomNumber;
        }
    }
}
