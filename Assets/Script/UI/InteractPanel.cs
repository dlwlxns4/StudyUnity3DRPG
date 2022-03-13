using UnityEngine;

public class InteractPanel : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel dialogueChannel;

    void Awake()
    {
        dialogueChannel.OnDialogueStart += SetOffPanel;
        dialogueChannel.OnDialogueEnd += SetOnPanel;
    }

    private void SetOffPanel(Dialogue dialogue)
    {
        gameObject.SetActive(false);
    }

    private void SetOnPanel(Dialogue dialogue)
    {
        gameObject.SetActive(true);
    }
}
