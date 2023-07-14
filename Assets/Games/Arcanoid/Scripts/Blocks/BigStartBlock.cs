using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStartBlock : StartBlock
{
    protected override void Awake()
    {
        BuildBlocks._bigStartBlocks.Add(gameObject);
    }
}
