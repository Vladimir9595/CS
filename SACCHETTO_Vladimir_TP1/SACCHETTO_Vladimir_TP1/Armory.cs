using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class Armory
    {
        // A list of weapons stored in the Weapons property
        public List<Weapon> Weapons { get; } = new List<Weapon>();

        // Constructor that calls the Init() method
        public Armory()
        {
            Init();
        }

        // Method that adds weapons to the Weapons property
        public void Init()
        {
            Weapons.Add(new Weapon("Blaster", 10, 20, EWeaponType.Direct));
            Weapons.Add(new Weapon("Grenade Launcher", 15, 25, EWeaponType.Explosive));
            Weapons.Add(new Weapon("Guided Missile", 20, 30, EWeaponType.Guided));
        }

        // Method that displays the weapons in the Weapons property
        public void ViewArmory()
        {
            Console.WriteLine("Armory Contents:");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.WeaponType}, Min Damage: {weapon.MinDamage}, Max Damage: {weapon.MaxDamage}");
            }
        }

        public void AddWeaponToSpaceship(Spaceship spaceship, Weapon weapon)
        {
            if (Weapons.Contains(weapon))
            {
                spaceship.AddWeapon(weapon);
            }
            else
            {
                throw new ArmoryException("This weapon is not linked to the armory.");
            }
        }
    }
}
