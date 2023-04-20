using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public partial class Room
    {
        public int RoomID { get; set; }
        [MaxLength(6)]
        public string RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public RoomType RoomType { get; set; }
        [DefaultValue("false")]
        public bool IsReserved { get; set; }

    }
}
