using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class SpaceInvaders
    {
        private Player player;
        private Armory armory;

        // Constructor who calls the Init method
        public SpaceInvaders()
        {
            player = new Player("Vladimir", "Sacchetto", "Vlad");
            player = new Player("Jack", "Sparrow", "Spar");
            player = new Player("Bruce", "Wayne", "Batman");

            armory = new Armory();
            armory.Init();

            var spaceship = new Spaceship(500, 300);
            spaceship.AddWeapon(new Weapon("Laser Blaster", 50, 100, EWeaponType.Direct));
            player.DefaultSpaceship = spaceship;
        }

        public void Play()
        {
            Console.WriteLine("Bienvenue dans Space Invaders !");
            Console.WriteLine($"Joueur : {player}");
            Console.WriteLine("Armurerie :");
            armory.ViewArmory();

            Console.WriteLine("Informations sur le vaisseau du joueur :");
            var defaultSpaceship = player.DefaultSpaceship;
            Console.WriteLine($"Nom du vaisseau : {defaultSpaceship.Name}");
            Console.WriteLine($"Structure : {defaultSpaceship.MaxStructure}");
            Console.WriteLine($"Bouclier : {defaultSpaceship.MaxShield}");
            Console.WriteLine($"Armes :");
            foreach (var weapon in defaultSpaceship.Weapons)
            {
                Console.WriteLine($"  {weapon.Name}");
            }
        }
    }
}
