using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP0_SACCHETTO_Vladimir
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            RunProgram();   
            Menu();

        }
        
        public static string NameFormat(string name, string surname)
        {
            return "Bonjour " + name + " " + surname.ToUpper() + " !";

        }

        public static int RetrieveHeight()
        {
            int height;
            bool isValidHeight;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Quelle est ta taille en cm? ");
                Console.WriteLine("----------------------------");
                Console.WriteLine();
                string input = Console.ReadLine();

                isValidHeight = int.TryParse(input, out height);

                if (isValidHeight && height > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ta taille est valide : " + height + "cm.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Erreur : Entres une taille valide (j'accepte les décimaux).");
                    Console.WriteLine();
                }

            } while (!isValidHeight || height <= 0);

            

            return height;
        
        }

        public static int RetrieveWeight()
        { 
            int weight;
            bool isValidWeight;
        
            do
            { 
                Console.WriteLine("--------------------");
                Console.WriteLine("Quel est ton poids ?");
                Console.WriteLine("--------------------");
                Console.WriteLine();
                string input = Console.ReadLine();

                isValidWeight = int.TryParse(input, out weight);

                if (isValidWeight && weight >= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ton poids est valide : " + weight + "kg.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Erreur : Entres un poids valide (j'accepte les décimaux).");
                    Console.WriteLine();
                }

            } while (!isValidWeight || weight <= 0);

            return weight;
        }
        
        public static int RetrieveAge()
        {
            int age;
            bool isValidAge;

            do
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Quel est ton âge ? ");
                Console.WriteLine("-------------------");
                Console.WriteLine();

                string input = Console.ReadLine();

                isValidAge = int.TryParse(input, out age);
                Console.WriteLine();

                if (isValidAge && age >= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ton age est valide : " + age + "ans.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Erreur : Entres un vrai âge.");
                    Console.WriteLine();
                }
            } while (!isValidAge || age <= 0);

            return age;
        }

        public static bool ContainsNumbers(string text)
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

        public static int Estimation()
        {
                int estimate;
                bool isValidEstimate;
            do
            {

                Console.WriteLine("Estime le nombre de cheveux sur ta tête (entre 100 000 et 150 000) : ");
                string input = Console.ReadLine();

                isValidEstimate = int.TryParse(input, out estimate);

                if (isValidEstimate && (estimate >= 100000 && estimate <= 150000))
                {
                    Console.WriteLine("\nEstimation valide : " + estimate);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nErreur : Veuillez entrer un nombre valide (entre 100 000 et 150 000).");
                    Console.WriteLine();
                }

            } while (!isValidEstimate || estimate <= 100000 && estimate >= 150000);

            Console.WriteLine("Merci pour ton estimation. Rassure toi, tu as encore des cheveux !");
            Console.ReadLine();

            return estimate;
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

        public static void Menu()
        {
            bool sleepProgram = false;

            while (!sleepProgram)
            { 

                Console.WriteLine("\t Tu vas choisir entre ces 4 possibilités : ");
                Console.WriteLine();
                Console.WriteLine("1 - Tu souhaites quitter mon programme .......... ");
                Console.WriteLine("2 - Tu souhaites recommencer le programme =) ");
                Console.WriteLine("3 - Tu souhaites compter jusqu’à 10 ");
                Console.WriteLine("4 - Tu souhaites téléphoner à Tata Jacqueline ");
                Console.WriteLine();
                Console.Write("Fais ton choix : ");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1" :
                        Console.WriteLine();
                        Console.WriteLine("Tu as choisi de quitter mon programme. Au revoir !");
                        sleepProgram = true;
                        Sleep();
                        break;
                    case "2" :
                        Console.WriteLine();
                        Console.WriteLine("Tu as choisi de recommencer le programme. C'est reparti !");
                        Console.WriteLine("****************************************************************************************");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        RunProgram();
                        break;
                    case "3" :
                        Console.WriteLine();
                        Console.WriteLine("Tu as choisi de compter jusqu'à 10. C'est parti !");
                        for (int i = 1; i <= 10; i++)
                        {
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine("Merci d'avoir compté avec moi. Au revoir !");
                        sleepProgram = true;
                        Sleep();
                        break;
                    case "4" :
                        Console.WriteLine();
                        Console.WriteLine("Tu as choisi de téléphoner à Tata Jacqueline. C'est parti !");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        Console.WriteLine("Messagerie de Tata Jacqueline : Bonjour je suis actuellement absente mais en général je n'aime pas que les gens me parlent alors ne m'appelle plus jamais !!!! ");
                        Thread.Sleep(5000);
                        sleepProgram = true;
                        Sleep();
                        break;

                    default:
                        Console.WriteLine("Choix invalide. Veuillez entrer un numéro entre 1 et 4.");
                        break;
                }
        
            }
        }

        public static void Sleep() 
        { 
            Thread.Sleep(3000);
            return;
        }

        public static void RunProgram()
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
                Console.Write("Donne moi ton nom de famille, vil chenapan : ");
                surname = Console.ReadLine();

                isValidSurname = !string.IsNullOrWhiteSpace(surname) && !ContainsNumbers(surname);

                if (!isValidSurname)
                {
                    Console.WriteLine("\nErreur : Veuilles entrer un nom de famille valide (sans chiffres ni espaces vides).");
                    Console.WriteLine();
                }
            } while (!isValidSurname);

            Console.WriteLine("\nNom de famille valide : " + surname);
            Console.WriteLine();

            // Vérification du prenom
            do
            {
                Console.Write("\nEt quel est ton prénom, petit galopin : ");
                name = Console.ReadLine();

                isValidName = !string.IsNullOrWhiteSpace(name) && !ContainsNumbers(name);

                if (!isValidName)
                {
                    Console.WriteLine("\nErreur : Veuilles entrer un prénom valide (sans chiffres ni espaces vides).");
                    Console.WriteLine();
                }
            } while (!isValidName);

            Console.WriteLine("\nTon prenom est aussi valide : " + name);
            Console.WriteLine();


            // Affichage du nom et du prénom avec fonction
            Console.WriteLine(NameFormat(name, surname));
            Console.ReadLine();


            // Affichage de la taille, du poids et de l'âge
            int height = RetrieveHeight();
            int weight = RetrieveWeight();
            int age = RetrieveAge();

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


            // Estimation du nombre de cheveux avec do ... while et if ... else
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Maintenant nous allons estimer le nombre de cheveux que tu as sur ta tête");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();
            Estimation();

            // Jeu du choix
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Enfin nous allons terminer avec le jeu du choix !");
            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();

        }
    }

}
