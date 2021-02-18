using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class IntersectionUi : MonoBehaviour
{
    [SerializeField]private RectTransform[] doorPanels;
    [SerializeField] private IntersectionManager interM;
    private List<RoomEffectsA>[] roomEffects;
    private void Start()
    {
        doorPanels = transform.GetComponentsInChildren<RectTransform>().Where(x => x != this.GetComponent<RectTransform>()).ToArray();
        interM.arrivedAtIntersection += OnArriveEvent;
    }
    private void OnArriveEvent(List<IntersectionData> interData)
    {
        roomEffects = interData.Select(x => x.lre).ToArray();
        DisplayUi();
    }
    private string CreateString(int index)
    {
        string text = "";
        for(int i = 0; i < roomEffects[index].Count; ++i)
        {
            text += roomEffects[index][i].GetDescription();
        }

        return text;
    }

    private void DisplayUi()
    {
        for (int i = 0; i < roomEffects.Length; ++i)
        {
            doorPanels[i].GetComponent<TextMeshProUGUI>().SetText(CreateString(i));
        }
    }
}
