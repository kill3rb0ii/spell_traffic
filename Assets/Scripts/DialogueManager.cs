using UnityEngine;
using TMPro;
using Ink.Runtime;
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject cue;

    private Story currentStory;

    public bool dialogueIsPlaying;



    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one dialog manager instances");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Update() {
        if (!dialogueIsPlaying) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ContinueDialogue();
        }
    }

    private void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    public void EnterDialogueMode(TextAsset INKjson) {
        cue.SetActive(false);
        currentStory = new Story(INKjson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueDialogue();
    }

    private void ContinueDialogue() {
        if (currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
        }

        else {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        cue.SetActive(true);
    }

}
