using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class SpaceInvaders
    {
        private Player player1;
        private Player player2;
        private Player player3;
        private Armory armory;

        // Constructor who calls the Init method
        public SpaceInvaders()
        {
            player1 = new Player("Vladimir", "Sacchetto", "Vlad");
            player2 = new Player("Jack", "Sparrow", "Spar");
            player3 = new Player("Bruce", "Wayne", "Batman");

            armory = new Armory();
            armory.Init();

            var spaceship1 = new Spaceship(500, 300);
            var spaceship2 = new Spaceship(400, 250);
            var spaceship3 = new Spaceship(700, 400);
            spaceship1.AddWeapon(new Weapon("Blaster", 50, 100, EWeaponType.Direct));
            spaceship2.AddWeapon(new Weapon("Grenade Launcher", 15, 25, EWeaponType.Explosive));
            spaceship3.AddWeapon(new Weapon("Guided Missile", 20, 30, EWeaponType.Guided));
            player1.DefaultSpaceship = spaceship1;
            player2.DefaultSpaceship = spaceship2;
            player3.DefaultSpaceship = spaceship3;
        }

        public void Play()
        {
            Console.WriteLine("Welcome in Space Invaders !");
            Console.WriteLine($"Player : {player1}");
            Console.WriteLine($"Player : {player2}");
            Console.WriteLine($"Player : {player3}");
            Console.WriteLine("Armurerie :");
            armory.ViewArmory();

            Console.WriteLine("Information about the player's ship :");
            var defaultSpaceship1 = player1.DefaultSpaceship;
            var defaultSpaceship2 = player2.DefaultSpaceship;
            var defaultSpaceship3 = player3.DefaultSpaceship;
            Console.WriteLine($"Vessel name : {defaultSpaceship1.Name}");
            Console.WriteLine($"Vessel name : {defaultSpaceship2.Name}");
            Console.WriteLine($"Vessel name : {defaultSpaceship3.Name}");

            Console.WriteLine($"Structure : {defaultSpaceship1.MaxStructure}");
            Console.WriteLine($"Structure : {defaultSpaceship2.MaxStructure}");
            Console.WriteLine($"Structure : {defaultSpaceship3.MaxStructure}");

            Console.WriteLine($"Shield : {defaultSpaceship1.MaxShield}");
            Console.WriteLine($"Shield : {defaultSpaceship2.MaxShield}");
            Console.WriteLine($"Shield : {defaultSpaceship3.MaxShield}");

            Console.WriteLine($"Weapons :");
            foreach (var weapon in defaultSpaceship1.Weapons)
            {
                Console.WriteLine($"  {weapon.Name}");
            }
            Console.WriteLine($"Weapons :");
            foreach (var weapon in defaultSpaceship2.Weapons)
            {
                Console.WriteLine($"  {weapon.Name}");
            }
            Console.WriteLine($"Weapons :");
            foreach (var weapon in defaultSpaceship3.Weapons)
            {
                Console.WriteLine($"  {weapon.Name}");
            }
        }
    }
}
