using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class DimondBlock : Block
    {
        private GameObject obj;

        public override void Punch()
        {
            obj = GameObject.FindGameObjectWithTag("Enemy");
            //obj.Damage();
            base.Punch();

        }
    }
}
