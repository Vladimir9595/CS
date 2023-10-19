
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsBooking
{
    public class Rooms {

        public int number { get; set; }
        public float nightlyRate { get; set; }
        public string typeRoom { get; set; }
        public string status { get; set; }
        public List<Booking> bookings { get; set; }

        public Rooms(int number, float nightlyRate, string typeRoom, string status, List<Booking> bookings) {
            this.number = number;
            this.nightlyRate = nightlyRate;
            this.typeRoom = typeRoom;
            this.status = status;
            this.bookings = bookings;
        }

    }
}