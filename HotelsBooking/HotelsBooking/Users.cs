
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsBooking
{
    public class Users {
        private string name { get; set; }
        private string password { get; set; }
        private string informations { get; set; }

        public Users(string name, string password, string informations) {
            this.name = name;
            this.password = password;
            this.informations = informations;
        }
        public void CreateUserAccount(string name, string password, string informations) {
            // Créer le compte utilisateur
            Users user = new Users(name, password, informations);

            Console.WriteLine(user.name + " a bien été créé.");
        }

        public void SearchHotel(DateTime dateArrival, DateTime dateLeaving) {
            // Utilisez les informations fournies pour effectuer la recherche d'hôtels disponibles
            // TODO implement here
            Console.WriteLine("Veuillez entrer les dates de votre séjour");
            Console.WriteLine("Date d'arrivée : " + dateArrival);
            Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Date de départ : " + dateLeaving);
            Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de chambres souhaitées : ");
            int numberRooms = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de personnes :");
            int numberPersons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre d'enfants :");
            int numberChildren = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de bébés :");        
            int numberBabies = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de lits simples :");
            int numberSingleBeds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de lits doubles :");
            int numberDoubleBeds = Convert.ToInt32(Console.ReadLine());     
            Console.WriteLine("Veuillez entrer le nombre de lits bébés :");
        }

        public void BookingRoom() {
            // TODO implement here
        }

        public void ManageBooking() {
            // TODO implement here
        }

    }
}