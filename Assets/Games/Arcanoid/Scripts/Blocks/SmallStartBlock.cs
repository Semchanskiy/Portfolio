using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class SmallStartBlock : StartBlock
    {
        protected override void Awake()
        {
            BuildBlocks._smallStartBlocks.Add(gameObject);
        }
    }
}
