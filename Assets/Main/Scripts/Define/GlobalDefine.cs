﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalDefine
{
    public static LayerMask wallLayerMask = LayerMask.NameToLayer("WallCollider");
    public static LayerMask playerMask = LayerMask.NameToLayer("PlayerCollider");
    public static LayerMask ballMask = LayerMask.NameToLayer("ElementalBall");
}

public enum ElementType
{
    Water=0,
    Fire=1,
    Wind,
    Earth   
}
