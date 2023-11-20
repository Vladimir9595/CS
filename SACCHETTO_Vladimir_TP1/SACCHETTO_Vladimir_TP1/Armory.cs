using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
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
            Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
            Weapons.Add(new Weapon("Grenade Launcher", 1, 8, EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Guided Missile", 3, 3, EWeaponType.Guided, 2));
            Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        // Method that displays the weapons in the Weapons property
        public void ViewArmory()
        {
            Console.WriteLine("Armory Contents:");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.WeaponType}, Min Damage: {weapon.MinDamage}, Max Damage: {weapon.MaxDamage}, Reload Time: {weapon.ReloadTime}");
            }
        }

        public void AddWeaponToSpaceship(Spaceship spaceship, Weapon weapon)
        {
            if (Weapons.Any(w => w.Name == weapon.Name))
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
