using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SACCHETTO_Vladimir_SpaceInvaders.Spaceship;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public interface IPlayer
    {
        Spaceship BattleShip { get; set; }
        string PlayerName { get; }
        string PlayerAlias { get; }
    }
}
