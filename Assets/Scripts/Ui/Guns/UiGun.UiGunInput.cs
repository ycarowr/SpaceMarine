using System.Diagnostics.Tracing;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiGun
    {
        private class UiGunInput
        {
            public IPlayer Player => GameData.Instance.Game.Player;
            private UiGun Parent { get; }
            private float timeRate;
            
            public UiGunInput(UiGun parent)
            {
                Parent = parent;
            }
            
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
                if(isUnderRate)
                    timeRate += Time.deltaTime;
                else
                {
                    timeRate = 0;
                    Player.Shoot();
                }
            }
        }
    }
}