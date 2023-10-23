using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SACCHETTO_Vladimir_TP1
{
    public class Spaceship
    {
        public int MaxStructure { get; }
        public int MaxShield { get; }
        public int CurrentStructure { get; private set; }
        public int CurrentShield { get; private set; }

        public bool IsDestroyed => CurrentStructure == 0;

        // 6. Add a list of weapons to the Spaceship class
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public object Name { get; internal set; }

        // Constructor that initializes the properties for the Spaceship class
        public Spaceship(int maxStructure, int maxShield, object name)
        {
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentStructure = maxStructure;
            CurrentShield = maxShield;
            Name = name;
        }

        // 6. Method that adds a weapon to the Weapons property
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

        // 6. Method that removes a weapon from the Weapons property
        public void RemoveWeapon(Weapon weapon)
        {
            Weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        // 6. Method that displays the weapons in the Weapons property
        public void ViewWeapons()
        {
            Console.WriteLine("Weapons on Spaceship:");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.WeaponType}, Min Damage: {weapon.MinDamage}, Max Damage: {weapon.MaxDamage}");
            }
        }

        // 6. Method that returns the average damage of the spaceship
        public double AverageDamages()
        {
            if (Weapons.Count == 0)
            {
                return 0.0;
            }
            double totalDamages = Weapons.Sum(weapon => (weapon.MinDamage + weapon.MaxDamage) / 2.0);
            return totalDamages / Weapons.Count;
        }

        // Method that returns the damage taken by the spaceship
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Damage cannot be negative.");
            }

            if (CurrentShield > 0)
            {
                CurrentShield -= damage;
                if (CurrentShield < 0)
                {
                    CurrentStructure += CurrentShield;
                    CurrentShield = 0;
                }
            }
            else
            {
                CurrentStructure -= damage;
            }

            if (CurrentStructure < 0)
            {
                CurrentStructure = 0;
            }
        }

        // Method that returns the damage taken by the spaceship
        public void Repair(int repairAmount)
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
