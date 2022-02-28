using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public interface IFlyable
    {
        void FlyTo(Coordinate point);
        float GetFlyTime(Coordinate point, out float distance);
    }
}
