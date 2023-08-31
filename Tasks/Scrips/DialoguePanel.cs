using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField] GameObject QuestionPanel;
    [SerializeField] Task OferredTask;
    [SerializeField] string[] Dialogues;
    [SerializeField] TextMeshProUGUI DialogueText;
    int ActiveDialogue;

    private void Start()
    {
        ActiveDialogue = 0;
        DialogueText.text = Dialogues[ActiveDialogue];
    }
    // Update is called once per frame
    
    public void NextDialogue()
    {
        QuestionPanel.GetComponent<RequestTaskPanel>().RequestedTask = OferredTask;
        if (ActiveDialogue == Dialogues.Length - 1) {
            gameObject.SetActive(false);
            QuestionPanel.SetActive(true);
        }
        else
        {
            ActiveDialogue++;
            DialogueText.text = Dialogues[ActiveDialogue];
        }
    }
}
