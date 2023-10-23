using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; }
        public int MaxDamage { get; }
        public EWeaponType WeaponType { get; }

        // Constructor that initializes the properties for the Weapon class
        public Weapon(string name, int minDamage, int maxDamage, EWeaponType weaponType)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponType = weaponType;
        }
    }
}
