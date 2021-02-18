using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "IntersectionDialogue")]
public class IntersectionDialogue : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField]private string storyText;

    [SerializeField] private IntersectionDialogue[] nextDialogues;
    

   
    public IntersectionDialogue[] NextDialogues { get => nextDialogues;}
    public string StoryText { get => storyText; }
  
}
