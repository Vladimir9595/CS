using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public EWeaponType WeaponType { get; set; }
        public double AverageDamage { get; }
        public double ReloadTime { get; set; }
        public double TimeBeforeReload { get; set; }
        public bool IsReload => TimeBeforeReload > 0;

        // Constructor that initializes the properties for the Weapon class
        public Weapon(string name, int minDamage, int maxDamage, EWeaponType weaponType, double reloadTime)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponType = weaponType;
            ReloadTime = reloadTime;
            TimeBeforeReload = reloadTime;
        }

        // Method to simulate reloading and decrement the reload counter
        public double Reload()
        {
            if (IsReload)
            {
                TimeBeforeReload--;
            }
            return TimeBeforeReload;
        }

        // Method to simulate shooting
        public double Shoot()
        {
            if (IsReload)
            {
                Console.WriteLine($"{Name} is reloading. Cannot shoot.");
                return 0;
            }

            double damage;

            switch (WeaponType)
            {
                case EWeaponType.Direct:
                    // 1 chance sur 10 de rater
                    if (new Random().Next(1, 11) == 1)
                    {
                        Console.WriteLine($"{Name} missed the target!");
                        return 0;
                    }
                    damage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
                    break;
                case EWeaponType.Explosive:
                    // 1 chance sur 4 de rater
                    if (new Random().Next(1, 5) == 1)
                    {
                        Console.WriteLine($"{Name} missed the target!");
                        return 0;
                    }
                    damage = new Random().Next((int)MinDamage, (int)MaxDamage + 1) * 2; // Multiplier par 2 pour le type explosif
                    break;
                case EWeaponType.Guided:
                    // Toujours toucher avec les dégâts minimums
                    damage = MinDamage;
                    break;
                default:
                    throw new InvalidOperationException("Invalid weapon type.");
            }

            TimeBeforeReload = ReloadTime; // Réinitialiser le compteur de rechargement
            return damage;
        }
    }
}
