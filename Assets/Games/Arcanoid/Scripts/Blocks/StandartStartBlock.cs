using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class StandartStartBlock : StartBlock
    {
        protected override void Awake()
        {
            BuildBlocks._standartStartBlocks.Add(gameObject);
        }
    }
}
