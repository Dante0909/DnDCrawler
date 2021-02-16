using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    public Sprite manaPotionSprite;
    public Sprite healthPotionSprite;
    public Sprite keySprite;
    private void Awake()
    {
        Instance = this;
    }
}
