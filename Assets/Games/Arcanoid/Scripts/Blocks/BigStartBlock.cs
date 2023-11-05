using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class BigStartBlock : StartBlock
    {
        protected override void Awake()
        {
            BuildBlocks._bigStartBlocks.Add(gameObject);
        }
    }
}
