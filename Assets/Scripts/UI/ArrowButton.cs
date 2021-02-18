using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Sprite[] arrowList;

    public void ChangeArrowSpriteOnSelect()
    {
        button.image.sprite = arrowList[1];
    }
    public void ChangeArrowSpriteOnMouseUp()
    {
        button.image.sprite = arrowList[0];
    }
}
