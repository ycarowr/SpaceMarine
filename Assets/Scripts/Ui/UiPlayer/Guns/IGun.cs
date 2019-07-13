using System.Collections;
using System.Collections.Generic;

namespace SpaceMarine
{
    public interface IGun
    {
        GunData Data { get; }
        void SetGunData(GunData data);
        void Update();
    }
}