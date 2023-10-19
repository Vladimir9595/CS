
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsBooking
{

    public class Booking {

        public DateTime dateArrival;
        public DateTime  dateLeaving;
        public Rooms room;
        public Hotels hotel;

        public Booking(DateTime dateArrival, DateTime dateLeaving, Rooms room) {
            this.dateArrival = dateArrival;
            this.dateLeaving = dateLeaving;
            this.room = room;
        }

        public Booking CreateBooking(Hotels hotel)
        {
            // V�rifier si la chambre est disponible pour les dates sp�cifi�es
            bool isRoomAvailable = true;

            foreach (var booking in hotel.bookings)
            {
                if (booking.dateArrival <= dateLeaving && booking.dateLeaving >= dateArrival)
                {
                    // Les dates de la r�servation existante chevauchent les dates de la nouvelle r�servation
                    isRoomAvailable = false;
                    break;
                }
            }

            if (isRoomAvailable)
            {
                // Cr�er la r�servation
                Booking newBooking = new Booking(dateArrival, dateLeaving, room)
                {
                    hotel = hotel
                };

                // Associer la r�servation � l'h�tel
                hotel.AssociateBooking(newBooking);

                Console.WriteLine("R�servation cr��e avec succ�s.");
                return newBooking;
            }
            else
            {
                Console.WriteLine("La chambre n'est pas disponible pour ces dates.");
                return null;
            }
        }

        public void ConsultBookings(Rooms room) {
            Console.WriteLine("D�tails de la r�servation :");
            Console.WriteLine("Date d'arriv�e : " + dateArrival);
            Console.WriteLine("Date de d�part : " + dateLeaving);
            Console.WriteLine("Chambre r�serv�e : " + room.number);
            Console.WriteLine("Type de chambre : " + room.typeRoom);
            Console.WriteLine("Tarif par nuit : " + room.nightlyRate);
        }

        public void CancelBookings(Hotels hotel) {
            // Rechercher la r�servation dans la liste des r�servations de l'h�tel
            foreach (var booking in hotel.bookings)
            {
                if (booking == this)
                {
                    // Supprimer la r�servation de la liste des r�servations de l'h�tel
                    hotel.bookings.Remove(booking);
                    Console.WriteLine("R�servation annul�e avec succ�s.");
                    break;
                }
            }
        }

    }
}