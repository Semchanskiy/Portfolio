using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class StandartBlock : Block
    {
        protected override void Specifications()
        {
            base.Specifications();
            _score = 3;
        }
    }
}
