using UnityEngine;
using UnityEngine.UI;

public class InteractPanel : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel dialogueChannel;
    Animator animator;
    private Text nameText;

    void Awake()
    {
        animator = GetComponent<Animator>();
        dialogueChannel.OnDialogueStart += SetOffPanel;
        dialogueChannel.OnDialogueEnd += DisableAnimation;
        nameText = GetComponentInChildren<Text>();
    }

     void OnEnable() 
    {
        animator.Play("Enable");
    }

    void OnDestroy()
    {
        dialogueChannel.OnDialogueStart -= SetOffPanel;
        dialogueChannel.OnDialogueEnd -= DisableAnimation;
    }

    private void SetOffPanel(Dialogue dialogue)
    {
        gameObject.SetActive(false);
    }

    public void DisableAnimation(Dialogue dialogue)
    {
        animator.Play("Disable");
    }

    private void SetOnPanel(Dialogue dialogue)
    {
        gameObject.SetActive(true);
    }

    public void SetText(string name)
    {
        nameText.text = name;
    }
}
