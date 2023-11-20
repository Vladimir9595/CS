using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class Rocinante : Spaceship
    {
        public Rocinante() : base("Rocinante", structure: 3, shield: 5, currentStructure: 3, maxStructure: 100, currentShield: 5, maxShield: 30)
        {
            AddWeapon(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        }
        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons.Where(w => w.WeaponType == EWeaponType.Explosive))
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

            damages /= 2;

            if (CurrentShield > 0)
            {
                CurrentShield -= damages;
                if (CurrentShield < 0)
                {
                    CurrentStructure += CurrentShield;
                    CurrentShield = 0;
                }
            }
            else
            {
                CurrentStructure -= damages;
            }

            if (CurrentStructure < 0)
            {
                CurrentStructure = 0;
            }
        }
    }

}
