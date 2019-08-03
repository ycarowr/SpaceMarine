using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiGun
    {
        class UiGunInput
        {
            float timeRate;

            public UiGunInput(UiGun parent)
            {
                Parent = parent;
            }

            public IPlayer Player => GameData.Instance.Game.Player;
            UiGun Parent { get; }

            public void TryEquip(GunData data)
            {
                Player.Equip(data);
            }

            public void Update()
            {
                TryShoot();
            }

            void TryShoot()
            {
                if (Parent.GunData == null)
                    return;

                //has input
                if (!Parent.UiPlayer.Input.IsShootPressed)
                {
                    timeRate = Parent.GunData.Rate;
                    return;
                }

                var isUnderRate = timeRate < 1f / Parent.GunData.Rate;

                //has fire rate
                if (isUnderRate)
                {
                    timeRate += Time.deltaTime;
                }
                else
                {
                    timeRate = 0;
                    Player.Shoot();
                }
            }
        }
    }
}