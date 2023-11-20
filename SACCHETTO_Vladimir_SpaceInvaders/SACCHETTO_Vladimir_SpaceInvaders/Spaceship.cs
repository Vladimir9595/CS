using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public abstract class Spaceship : ISpaceship
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public int MaxWeapons { get; }
        public int MaxStructure { get; }
        public int MaxShield { get; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public double AverageDamages => GetAverageDamages();
        public bool BelongsPlayer { get; }


        public bool IsDestroyed => CurrentStructure == 0;

        
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public Spaceship(string name, double structure, double shield, double currentStructure, int maxStructure, double currentShield, int maxShield)
        {
            Structure = structure;
            Shield = shield;
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentStructure = currentStructure;
            CurrentShield = currentShield;
            Name = name;
        }

        
        public void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count < 3)
            {
                Weapons.Add(weapon);
            }
            else
            {
                Console.WriteLine("Spaceship can't carry more than three weapons.");
            }
        }

        
        public void RemoveWeapon(Weapon weapon)
        {
            Weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        public void ReloadWeapons()
        {
            foreach (var weapon in Weapons)
            {
                weapon.Reload();
            }
        }
        
        public void ViewWeapons()
        {
            Console.WriteLine("Weapons on Spaceship:");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.WeaponType}, Min Damage: {weapon.MinDamage}, Max Damage: {weapon.MaxDamage}, Reload Time: {weapon.ReloadTime}");
            }
        }

        public void ViewShip()
        {
            Console.WriteLine($"Name: {Name}, Structure: {Structure}, Shield: {Shield}");
        }

        public void RepairShield(double repair)
        {
            CurrentShield += (int)repair;
            if (CurrentShield > MaxShield)
            {
                CurrentShield = MaxShield;
            }
        }

        public abstract void TakeDamages(double damages);

        public abstract void ShootTarget(Spaceship target);

        public double GetAverageDamages()
        {
            if (Weapons.Count == 0)
            {
                return 0.0;
            }
            double totalDamages = Weapons.Sum(weapon => (weapon.MinDamage + weapon.MaxDamage) / 2.0);
            return totalDamages / Weapons.Count;
        }

        public void RepairAmount(int repairAmount)
        {
            if (repairAmount < 0)
            {
                throw new ArgumentException("Repair value cannot be negative.");
            }

            CurrentStructure += repairAmount;
            if (CurrentStructure > MaxStructure)
            {
                CurrentStructure = MaxStructure;
            }
        }
    }
}
