using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis() : base("Tardis", structure: 1, shield: 0, currentStructure: 1, maxStructure: 100, currentShield: 0, maxShield: 30)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            if (spaceships.Count > 1)
            {
                int indexToMove = new Random().Next(spaceships.Count);
                int newIndex = new Random().Next(spaceships.Count);

                Spaceship spaceshipToMove = spaceships[indexToMove];
                spaceships.RemoveAt(indexToMove);
                spaceships.Insert(newIndex, spaceshipToMove);

                Console.WriteLine($"{Name} has teleported a spaceship.");
            }
            else
            {
                Console.WriteLine($"{Name} cannot use its ability as there are not enough spaceships.");
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine($"{Name} cannot shoot, as it has no weapons.");
        }

        public override void TakeDamages(double damages)
        {
            // Le Tardis n'est pas affecté par les dégâts entrants, car il n'a pas de bouclier ni de structure
            // Le Tardis ne peut pas être endommagé
        }
    }
}
