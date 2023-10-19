
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
            // Vérifier si la chambre est disponible pour les dates spécifiées
            bool isRoomAvailable = true;

            foreach (var booking in hotel.bookings)
            {
                if (booking.dateArrival <= dateLeaving && booking.dateLeaving >= dateArrival)
                {
                    // Les dates de la réservation existante chevauchent les dates de la nouvelle réservation
                    isRoomAvailable = false;
                    break;
                }
            }

            if (isRoomAvailable)
            {
                // Créer la réservation
                Booking newBooking = new Booking(dateArrival, dateLeaving, room)
                {
                    hotel = hotel
                };

                // Associer la réservation à l'hôtel
                hotel.AssociateBooking(newBooking);

                Console.WriteLine("Réservation créée avec succès.");
                return newBooking;
            }
            else
            {
                Console.WriteLine("La chambre n'est pas disponible pour ces dates.");
                return null;
            }
        }

        public void ConsultBookings(Rooms room) {
            Console.WriteLine("Détails de la réservation :");
            Console.WriteLine("Date d'arrivée : " + dateArrival);
            Console.WriteLine("Date de départ : " + dateLeaving);
            Console.WriteLine("Chambre réservée : " + room.number);
            Console.WriteLine("Type de chambre : " + room.typeRoom);
            Console.WriteLine("Tarif par nuit : " + room.nightlyRate);
        }

        public void CancelBookings(Hotels hotel) {
            // Rechercher la réservation dans la liste des réservations de l'hôtel
            foreach (var booking in hotel.bookings)
            {
                if (booking == this)
                {
                    // Supprimer la réservation de la liste des réservations de l'hôtel
                    hotel.bookings.Remove(booking);
                    Console.WriteLine("Réservation annulée avec succès.");
                    break;
                }
            }
        }

    }
}