using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_SpaceInvaders
{
    public interface IWeapon
    {
        string Name { get; set; }
        EWeaponType WeaponType { get; set; }
        double MinDamage { get; set; }
        double MaxDamage { get; set; }
        double AverageDamage { get; }
        double ReloadTime { get; set; }
        double TimeBeforeReload { get; set; }
        bool IsReload { get; }
        double Reload();
        double Shoot();
    }
}
