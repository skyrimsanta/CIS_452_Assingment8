using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     * (Levi Schoof)
     * (CroissantPie)
     * (Assignment8)
     * (Implaments the FoodTemplate class and ovverides the PlaceSideC Method)
*/

public class CroissantPie : FoodTemplate
{
    public override void PlaceSide()
    {
        itemObject = Instantiate(item, null);
        itemObject.transform.position = mainPos;
        itemObject.transform.localScale = new Vector3(2, 2, 2);
    }
}
