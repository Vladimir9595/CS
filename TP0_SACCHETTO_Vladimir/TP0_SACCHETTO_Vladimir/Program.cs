using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TP0_SACCHETTO_Vladimir
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe. Presse entrer pour y rentrer ...");
            Console.ReadLine();

            string surname;
            bool isValidSurname;
            string name;
            bool isValidName;

            // Vérification du nom de famille
            do
            {
                Console.WriteLine("Donne moi ton nom de famille, vil chenapan : ");
                surname = Console.ReadLine();

                isValidSurname = !string.IsNullOrWhiteSpace(surname) && !ContainsNumbers(surname);

                if (!isValidSurname)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un nom de famille valide (sans chiffres ni espaces vides).");
                    Console.WriteLine();
                }
            } while (!isValidSurname);

            Console.WriteLine("Nom de famille valide : " + surname);
            Console.WriteLine();
            
            // Vérification du prenom
            do
            {
                Console.WriteLine("Et quel est ton prénom, petit galopin : ");
                name = Console.ReadLine();

                isValidName = !string.IsNullOrWhiteSpace(name) && !ContainsNumbers(name);

                if (!isValidName)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un prenom valide (sans chiffres ni espaces vides).");
                    Console.WriteLine();
                }
            } while (!isValidName);

            Console.WriteLine("Ton prenom est aussi valide : " + name);
            Console.WriteLine();

            
            // Affichage du nom et du prénom avec fonction
            Console.WriteLine(NameFormat(name, surname));
            Console.ReadLine();

            // Affichage de la taille, du poids et de l'âge
            float height;
            float weight;
            float age;
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Quelle est ta taille en cm? ");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                height = float.Parse(Console.ReadLine());
                Console.WriteLine();
                if (height <= 0)
                {
                    Console.WriteLine("Erreur : Veuillez entrer une taille valide (supérieure à 0).");
                    Console.ReadLine();
                }
            } while (height <= 0);
            
            do
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Quel est ton poids ?");
                Console.WriteLine("----------------------");
                Console.WriteLine();
                weight = float.Parse(Console.ReadLine());
                Console.WriteLine();
                if (weight <= 0)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un poids valide (supérieure à 0).");
                    Console.ReadLine();
                }
            } while (weight <= 0);
            
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Quel est ton âge ? ");
                Console.WriteLine("--------------------");
                Console.WriteLine();
                age = float.Parse(Console.ReadLine());
                Console.WriteLine();
                if (age <= 0)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un poids valide (supérieure à 0).");
                    Console.ReadLine();
                }
            } while (age <= 0);
                        
            Console.WriteLine("Tu mésures " + height + "cm, tu pèses " + weight + "kg et tu es âgé de " + age + " ans !");
            Console.ReadLine();

            // Affichage de la majorité

            Console.WriteLine(age <= 18
            ? "Tu es un morveux puéril et immature qui n’a même pas le droit d’acheter de l’alcool en grande surface."
            : "Tu es majeur ! Tu es prêt.e à consommer ta première dose d’alcool !");
            Console.ReadLine();

            // IMC
            Console.WriteLine(ToString(height, weight));
            Console.ReadLine();

            // Commentaire IMC
            CommentToDisplay(height, weight);
            Console.ReadLine();

            // Declaration de la variable estimate
            int estimate;
            bool isValidEstimate;

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Maintenant nous allons estimer le nombre de cheveux que tu as sur ta tête");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            // Estimation du nombre de cheveux avec do ... while et if ... else
            do
            {
                Console.WriteLine("Estime le nombre de cheveux sur ta tête (entre 100 000 et 150 000) : ");
                string input = Console.ReadLine();

                isValidEstimate = int.TryParse(input, out estimate);

                if (isValidEstimate && (estimate >= 100000 && estimate <= 150000))
                {
                    Console.WriteLine("Estimation valide : " + estimate);
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("Erreur : Veuillez entrer un nombre valide (entre 100 000 et 150 000).");
                    Console.ReadLine();
                }
                
            } while (!isValidEstimate && !(estimate >= 100000 && estimate <= 150000));

            Console.WriteLine("Merci pour ton estimation. Rassure toi, tu as encore des cheveux !");
            Console.ReadLine();

            // TimeOut de 5 secondes
            await TimeOut();

        }

        public static async Task TimeOut() 
        { 
            var inputTask = Task.Run(() => Console.ReadLine());

            var completedTask = await Task.WhenAny(inputTask, Task.Delay(TimeSpan.FromSeconds(5))); // Temps limite de 10 secondes

            if (completedTask == inputTask)
            {
                string input = inputTask.Result;
                Console.WriteLine("Vous avez entré : " + input);
            }
            else
            {
                Console.WriteLine("Le temps imparti est écoulé. Le programme se ferme.");
            }
        }
        
        public static string NameFormat(string name, string surname)
        {
            return "Bonjour " + name + " " + surname.ToUpper() + " !";

        }

        static bool ContainsNumbers(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static float CalculateIMC(float height, float weight)
        {
            float heightInMeters = height / 100.0f;

            float imc =  weight / (heightInMeters * heightInMeters);

            return imc;
        }

        public static string ToString(float height, float weight)
        {
            float imc = CalculateIMC(height, weight);
            return "Ton IMC est : " + imc.ToString("0.0");
        }

        public static void CommentToDisplay(float height, float weight)
        {
            const string FIRST_COMMENT = "Attention à l’anorexie !";
            const string SECOND_COMMENT = "Vous êtes un peu maigrichon !";
            const string THIRD_COMMENT = "Vous êtes de corpulence normale !";
            const string FOURTH_COMMENT = "Vous êtes en surpoids !";
            const string FIFTH_COMMENT = "Obésité modérée !";
            const string SIXTH_COMMENT = "Obésité sévère !";
            const string SEVENTH_COMMENT = "Obésité morbide !";

            float imc = CalculateIMC(height, weight);

            if (imc < 16.5)
            {
               Console.WriteLine(FIRST_COMMENT);
            }
            else if (imc >= 16.5 && imc < 18.5)
            {
                Console.WriteLine(SECOND_COMMENT);
            }
            else if (imc >= 18.5 && imc < 25)
            {
                Console.WriteLine(THIRD_COMMENT);
            }
            else if (imc >= 25 && imc < 30)
            {
                Console.WriteLine(FOURTH_COMMENT);
            }
            else if (imc >= 30 && imc < 35)
            {
                Console.WriteLine(FIFTH_COMMENT);
            }
            else if (imc >= 35 && imc < 40)
            {
                Console.WriteLine(SIXTH_COMMENT);
            }
            else
            {
                Console.WriteLine(SEVENTH_COMMENT);
            }
        }


    }
}
