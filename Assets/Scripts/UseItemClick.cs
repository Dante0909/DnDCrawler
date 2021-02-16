using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseItemClick : MonoBehaviour
{
    public ConsumableItemA ci;
    public void Dumb()//dumb function to call the delegate
    {
        ci.OnConsumed();
    }
}
