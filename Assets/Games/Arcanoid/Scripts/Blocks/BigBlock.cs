using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class BigBlock : Block
    {
        protected override void Specifications()
        {
            base.Specifications();
            _score = 7;
        }
    }
}
