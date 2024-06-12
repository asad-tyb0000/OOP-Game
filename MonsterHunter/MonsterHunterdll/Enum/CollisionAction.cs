using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedll
{
    public enum CollisionAction
    {
        IncreaseHealth,
        DecreaseHealth,
        ReverseMovement,
        DecreasePlayerHealthByBullet,
        DecreaseEnemyHealthByBullet,
        Kill
    }
}
