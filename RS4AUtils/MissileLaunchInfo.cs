using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace RS4A.RS4AUtils
{
    public class MissileLaunchInfo(int timer, Point16 siloLocation, Vector2 target)
    {
        public int timer = timer;
        public readonly Point16 siloLocation = siloLocation;
        public readonly Vector2 target = target;
    }
}
