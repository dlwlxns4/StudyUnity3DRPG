using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnInteraction;
    [SerializeField]
    private int objectID;

    public void DoInteraction()
    {
        QuestManager.Instace.latestInteractObjectID = objectID;
        OnInteraction.Invoke();
    }
}
