using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class ViperMKII : Spaceship
    {
        private bool hasUsedWeaponThisTurn = false;

        public ViperMKII() : base("ViperMKII", structure: 10, shield: 15, currentStructure: 10, maxStructure: 100, currentShield: 15, maxShield: 30)
        {
            AddWeapon(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
            AddWeapon(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
            AddWeapon(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        public override void TakeDamages(double damages)
        {
            if (damages < 0)
            {
                throw new ArgumentException("Damage cannot be negative.");
            }

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

        public override void ShootTarget(Spaceship target)
        {
            if (!hasUsedWeaponThisTurn)
            {
                // Choix d'une arme rechargée (avec un compteur de rechargement à zéro)
                var availableWeapons = Weapons.Where(weapon => weapon.IsReload).ToList();
                if (availableWeapons.Count > 0)
                {
                    // Utilisation de la première arme rechargée
                    var selectedWeapon = availableWeapons[0];
                    selectedWeapon.Shoot();
                    hasUsedWeaponThisTurn = true;
                }
            }
        }

        // Méthode pour réinitialiser le statut d'utilisation des armes à chaque tour
        public void ResetTurnStatus()
        {
            hasUsedWeaponThisTurn = false;
        }
    }

}
