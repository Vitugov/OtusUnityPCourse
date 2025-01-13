using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public interface IBackgroundParameters
    {
        float StartPositionY { get; }
        float EndPositionY { get; }
        float MovingSpeedY { get; }
    }
}
