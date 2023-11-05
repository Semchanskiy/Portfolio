using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class CranchBlock : Block
    {
        protected override void Specifications()
        {
            _lives = 3;
        }
    }
}
