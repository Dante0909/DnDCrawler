using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIDialogue : MonoBehaviour
{

    public static UIDialogue instance = null;


    private GameManager gameManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueLeft;
    [SerializeField] private TextMeshProUGUI dialogueMiddle;
    [SerializeField] private TextMeshProUGUI dialogueRight;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    void Start()
    {
        gameManager = GameManager.instance;

        if (gameManager != null)
        {
            gameManager.dialogueState.OnDialogueStateEnter+=DialogueUIOnStart;
            gameManager.dialogueState.OnDialogueStateExit += DialogueUIOnEnd;
        }
    }
    public TextMeshProUGUI DialogueLeft { get => dialogueLeft;}
    public TextMeshProUGUI DialogueMiddle { get => dialogueMiddle;  }
    public TextMeshProUGUI DialogueRight { get => dialogueRight; }

    private void OnEnable()
    {
        
    }
    private void TurnOnDialogue()
    {
        panel.SetActive(true);
    }

    private void TurnOffDialogue()
    {
        panel.SetActive(false);
    }
    private void DialogueUIOnStart(object sender, System.EventArgs e)
    {
        TurnOnDialogue();
    }
    private void DialogueUIOnEnd(object sender, System.EventArgs e)
    {
        TurnOffDialogue();
    }

}
