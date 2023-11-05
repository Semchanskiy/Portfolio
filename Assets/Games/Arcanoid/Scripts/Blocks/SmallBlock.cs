using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class SmallBlock : Block
    {
        protected override void Specifications()
        {
            base.Specifications();
            _score = 1;
        }
    }
}
