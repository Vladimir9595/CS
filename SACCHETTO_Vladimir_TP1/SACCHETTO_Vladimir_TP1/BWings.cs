using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class BWings : Spaceship
    {
        public BWings() : base("BWings", structure: 30, shield: 0, currentStructure: 30, maxStructure: 100, currentShield: 0, maxShield: 30)
        {
            Weapon hammer = new("Hammer", 1, 8, EWeaponType.Explosive, 1.5);
            AddWeapon(hammer);
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

            double reducedDamages = damages * 0.8; // 80% de réduction de dégâts

            if (CurrentStructure > 0)
            {
                CurrentStructure -= reducedDamages;

                if (CurrentStructure < 0)
                {
                    CurrentStructure = 0;
                }
            }
        }
    }

}
