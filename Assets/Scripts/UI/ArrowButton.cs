using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    private IntersectionManager interM;
    [SerializeField] private Button button;
    [SerializeField] private Sprite[] arrowList;
    private void Start()
    {
        interM = IntersectionManager.instance;
    }
    public void ChangeArrowSpriteOnSelect()
    {
        button.image.sprite = arrowList[1];
    }
    public void ChangeArrowSpriteOnMouseUp()
    {
        button.image.sprite = arrowList[0];
    }
    public void OnClick(string direction)
    {
        switch (direction)
        {
            case "left":
                {

                }break;
            case "up":
                {

                }break;
            case "right":
                {

                }break;
        }
    }
}
