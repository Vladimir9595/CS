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
        private readonly Player player1;
        private readonly Player player2;
        private readonly Player player3;
        private readonly Armory armory;

        // Constructor who calls the Init method
        public SpaceInvaders()
        {
            player1 = new Player("Vladimir", "Sacchetto", "Vlad");
            player2 = new Player("Jack", "Sparrow", "Spar");
            player3 = new Player("Bruce", "Wayne", "Batman");

            armory = new Armory();

            var spaceship1 = new Spaceship("First Vessel", 500, 300, 500, 600, 300, 600);
            var spaceship2 = new Spaceship("Second Vessel", 400, 250, 400, 600, 250, 600);
            var spaceship3 = new Spaceship("Third Vessel", 700, 400, 700, 600, 400, 600);
            var spaceship4 = new Spaceship("Fourth Vessel", 500, 300, 500, 600, 300, 600);
            var spaceship5 = new Spaceship("Fifth Vessel", 400, 250, 400, 600, 250, 600);
            var spaceship6 = new Spaceship("Sixth Vessel", 700, 400, 700, 600, 400, 600);
            Weapon laser = new("Laser", 2, 3, EWeaponType.Direct, 2);
            Weapon grenadeLauncher = new("Grenade Launcher", 1, 8, EWeaponType.Explosive, 1.5);
            Weapon guidedMissile = new("Guided Missile", 3, 3, EWeaponType.Guided, 2);
            Weapon machineGun = new("Mitrailleuse", 6, 8, EWeaponType.Direct, 1);
            Weapon emg = new("EMG", 1, 7, EWeaponType.Explosive, 1.5);
            Weapon missile = new("Missile", 4, 100, EWeaponType.Guided, 4);
            spaceship1.AddWeapon(laser);
            spaceship2.AddWeapon(grenadeLauncher);
            spaceship3.AddWeapon(guidedMissile);
            spaceship4.AddWeapon(machineGun);
            spaceship5.AddWeapon(emg);
            spaceship6.AddWeapon(missile);

            player1.DefaultSpaceship = spaceship1;
            player2.DefaultSpaceship = spaceship2;
            player3.DefaultSpaceship = spaceship3;

        }

        public void Play()
        {
            Console.WriteLine("Welcome in Space Invaders !");
            Console.WriteLine($"First player : {player1}");
            Console.WriteLine($"Second player : {player2}");
            Console.WriteLine($"Third player : {player3}");
            Console.WriteLine();
            armory.ViewArmory();
            Console.WriteLine();

            Console.WriteLine("Informations about the player's ship :");
            DisplaySpaceshipInfo(player1.DefaultSpaceship);
            DisplaySpaceshipInfo(player2.DefaultSpaceship);
            DisplaySpaceshipInfo(player3.DefaultSpaceship);
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

        public static void Main()
        {
            SpaceInvaders game = new();

            game.Play();
        }
    }
}
