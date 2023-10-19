
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsBooking
{
    public class Hotels {

        private string name { get; set; }
        private int adressNumber { get; set; } 
        private string street { get; set; }
        private int postalCode { get; set; } 
        private string city { get; set; }
        private int totalRooms { get; set; }
        private List<Rooms> availableRooms { get; set; }
        public List<Booking> bookings { get; set; }

        public Hotels(string name, int adressNumber, string street, int postalCode, string city, int totalRooms, List<Rooms> availableRooms) {
            this.name = name;
            this.adressNumber = adressNumber;
            this.street = street;
            this.postalCode = postalCode;
            this.city = city;
            this.totalRooms = totalRooms;
            this.availableRooms = availableRooms;
        }

        public List<Rooms> SearchAvailableRoom(DateTime dateArrival, DateTime dateLeaving) {

            // Code pour rechercher les chambres disponibles en fonction des dates choisies
            List<Rooms> availableRooms = new List<Rooms>();

            foreach (var room in availableRooms)
            {
                bool isRoomAvailable = true;

                foreach (var booking in room.bookings)
                {
                    if (booking.dateArrival <= dateLeaving && booking.dateLeaving >= dateArrival)
                    {
                        isRoomAvailable = false;
                        break;
                    }
                }

                if (isRoomAvailable)
                {
                    availableRooms.Add(room);
                
                } else if (availableRooms.Count == 0)
                {
                    Console.WriteLine("Aucune chambre disponible pour ces dates.");
                
                } else
                {
                    Console.WriteLine("Chambres disponibles :");
                    
                    foreach (var singleRoom in availableRooms)
                    {
                        Console.WriteLine($"Num�ro : {singleRoom.number}, Type : {singleRoom.typeRoom}, Tarif : {singleRoom.nightlyRate}");
                    }
                }
            }

            return availableRooms;

        }

        public void ConsultDetailsHotel() {
            Console.WriteLine("Nom de l'h�tel : " + name);
            Console.WriteLine("Adresse compl�te : " + adressNumber + street + ", " + postalCode + city);
            Console.WriteLine("Nombre de chambres : " + totalRooms);
            Console.WriteLine("Chambres disponibles :");
            foreach (var chambre in availableRooms)
            {
                Console.WriteLine($"Num�ro : {chambre.number}, Type : {chambre.typeRoom}, Tarif : {chambre.nightlyRate}");
            }
        }

        public void AssociateBooking(Booking booking) {

            List<Booking> bookings = new List<Booking>();

            // V�rifie si la r�servation concerne cet h�tel
            if (booking.hotel == this)
            {
                // Ajoute la r�servation � la liste des r�servations de l'
                bookings.Add(booking);

                // Met � jour la disponibilit� des chambres
                foreach (var room in availableRooms)
                {
                    if (room.number == booking.room.number)
                    {
                        // La r�servation concerne cette chambre, donc la chambre n'est plus disponible
                        availableRooms.Remove(room);
                        break;
                    }
                }

                Console.WriteLine("R�servation associ�e � l'h�tel avec succ�s.");
            }
            else
            {
                Console.WriteLine("Cette r�servation ne concerne pas cet h�tel.");
            }
        }

    }
}