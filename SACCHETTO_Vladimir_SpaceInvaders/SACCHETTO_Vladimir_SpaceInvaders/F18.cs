using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class F18 : Spaceship, IAbility
    {
        public F18() : base("F18", structure: 15, shield: 0, currentStructure: 15, maxStructure: 100, currentShield: 0, maxShield: 30)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            Console.WriteLine($"{Name} is using its special ability!");
            ExplodeOnContact(spaceships);
        }

        private void ExplodeOnContact(List<Spaceship> spaceships)
        {
     
            if (spaceships.IndexOf(this) == 0 || spaceships.IndexOf(this) == 2)
            {
                Console.WriteLine($"{Name} is in position 0 or 2 and is exploding!");

   
                foreach (var spaceship in spaceships)
                {
                    if (spaceship != this)
                    {
                        spaceship.TakeDamages(10);
                    }
                }
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine($"{Name} does not have weapons and cannot shoot.");
        }

        public override void TakeDamages(double damages)
        {
            // Le F-18 n'est pas affecté par les dégâts entrants, car il n'a pas de bouclier ni de structure
            // Le F-18 inflige des dégâts lorsqu'il explose sur un vaisseau voisin (gestion dans la méthode ExplodeOnContact)
        }
    }
}
