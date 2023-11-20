using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class Dart : Spaceship
    {
        public Dart() : base("Dart", structure: 10, shield: 3, currentStructure: 10, maxStructure: 100, currentShield: 3, maxShield: 30)
        {
            Weapon laser = new("Laser", 2, 3, EWeaponType.Direct, 2);
            AddWeapon(laser);
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons.Where(w => w.WeaponType == EWeaponType.Direct))
            {
                weapon.Shoot();
            }
        }
        public override void TakeDamages(double damages)
        {
            if (damages < 0)
            {
                throw new ArgumentException("Damage cannot be negative.");
            }

            // Dart ignore complètement le bouclier et réduit directement la structure
            CurrentStructure -= damages;

            if (CurrentStructure < 0)
            {
                CurrentStructure = 0;
            }
        }


    }
}
