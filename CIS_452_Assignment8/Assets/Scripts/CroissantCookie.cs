﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
     * (Levi Schoof)
     * (CroissantCookie)
     * (Assignment8)
     * (Implaments the FoodTemplate class and ovverides the PlaceSideC Method)
*/
public class CroissantCookie : FoodTemplate
{
    public override void PlaceSide()
    {
        itemObject = Instantiate(item, null);
        itemObject.transform.position = mainPos;
        itemObject.transform.localScale = new Vector3(2, 2, 2);
    }
}
