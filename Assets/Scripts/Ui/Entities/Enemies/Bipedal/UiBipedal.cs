using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using SpaceMarine.Model;


namespace SpaceMarine
{
    public partial class UiBipedal : UiEnemy
    {

        //--------------------------------------------------------------------------------------------------------------

        public BipedalData Data;
        
        [Button]
        public void Test()
        {
            Enemy = new Bipedal(Data);
        }
    }
}
