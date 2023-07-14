using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlock : Block
{
    protected override void Specifications()
    {
        base.Specifications();
        _score = 7;
    }
}
