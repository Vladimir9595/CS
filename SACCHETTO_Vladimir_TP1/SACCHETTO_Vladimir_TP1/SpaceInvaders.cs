using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class SpaceInvaders
    {
        private readonly Player player;
        private readonly List<Spaceship> enemies;
        private readonly Armory armory;


        public SpaceInvaders()
        {
            player = new Player("Vladimir", "Sacchetto", "Vlad");
            enemies = new List<Spaceship>();
            armory = new Armory();

            var playerSpaceship = new Dart();
            Weapon laser = new("Laser", 2, 3, EWeaponType.Direct, 2);
            playerSpaceship.AddWeapon(laser);
            player.DefaultSpaceship = playerSpaceship;

            InitEnemies();

            DisplayGameState();

        }

        private void InitEnemies()
        {
            enemies.Add(new Dart());
            enemies.Add(new BWings());
            enemies.Add(new Rocinante());
            enemies.Add(new ViperMKII());
            enemies.Add(new F18());
            enemies.Add(new Tardis());
        }

        private void DisplayGameState()
        {
            Console.WriteLine("\nCurrent Game State:");

            // Display player's spaceship information
            Console.WriteLine("Player's Spaceship:");
            DisplaySpaceshipInfo(player.DefaultSpaceship);

            // Display enemies' information
            Console.WriteLine("\nEnemies:");
            foreach (var enemy in enemies)
            {
                DisplaySpaceshipInfo(enemy);
            }
        }

        private static void DisplaySpaceshipInfo(Spaceship? spaceship)
        {
            if (spaceship != null)
            {
                Console.WriteLine($"{spaceship.Name}");
                Console.WriteLine($"  Structure: {spaceship.CurrentStructure}");
                Console.WriteLine($"  Shield: {spaceship.CurrentShield}");

                Console.WriteLine($"  Weapons:");
                foreach (var weapon in spaceship.Weapons)
                {
                    Console.WriteLine($"    {weapon.Name}");
                }

                Console.WriteLine();
            }
        }

        public void Play()
        {
            Console.WriteLine("Welcome in Space Invaders !");
            Console.WriteLine($"First player : {player}");

            Console.WriteLine();
            armory.ViewArmory();
            Console.WriteLine();

            Console.WriteLine("Informations about the player's ship :");
            DisplaySpaceshipInfo(player.DefaultSpaceship);

            Console.WriteLine();
            Console.WriteLine("Game Started!");

            while (!IsGameOver())
            {
                PlayRound();
            }

            Console.WriteLine("Game Over!");

        }

        private void PlayRound()
        {
            // Player's turn
            Console.WriteLine("\nPlayer's Turn:");
            PlayPlayerTurn();

            // Enemies' turns
            Console.WriteLine("\nEnemies' Turns:");
            foreach (var enemy in enemies)
            {
                PlayEnemyTurn(enemy);
            }
        }

        private void PlayPlayerTurn()
        {
            Console.WriteLine("Choose an enemy to attack:");
            DisplayEnemies();
            int selectedEnemyIndex = GetValidEnemyIndex();

            if (player.DefaultSpaceship != null)
            {
                player.DefaultSpaceship.ShootTarget(enemies[selectedEnemyIndex]);
            }
            else
            {
                Console.WriteLine("Player's spaceship is null. Cannot attack.");
            }

            DisplayGameState();
        }

        private int GetValidEnemyIndex()
        {
            int selectedEnemyIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out selectedEnemyIndex) &&
                    selectedEnemyIndex >= 0 && selectedEnemyIndex < enemies.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid enemy index.");
                }
            }
            return selectedEnemyIndex;
        }

        private void PlayEnemyTurn(Spaceship enemy)
        {
            if (player.DefaultSpaceship != null)
            {
                enemy.ShootTarget(player.DefaultSpaceship);

                DisplayGameState();
            }
            else
            {
                Console.WriteLine("Player's spaceship is null. Enemy cannot attack.");
            }
        }

        private void DisplayEnemies()
        {
            Console.WriteLine("Enemies:");
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{i}. {enemies[i].Name} - Structure: {enemies[i].CurrentStructure}");
            }
        }

        private bool IsGameOver()
        {
            if (player.DefaultSpaceship != null && player.DefaultSpaceship.IsDestroyed)
            {
                Console.WriteLine("Game over! Player's spaceship is destroyed.");
                return true;
            }

            if (enemies.All(enemy => enemy.IsDestroyed))
            {
                Console.WriteLine("Congratulations! All enemies are destroyed. You win!");
                return true;
            }

            return false;
        }



        public static void Main()
        {
            SpaceInvaders game = new();

            game.Play();
        }
    }
}
