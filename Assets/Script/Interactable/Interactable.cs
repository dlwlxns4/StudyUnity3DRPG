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
        Debug.Log(this.gameObject.name + " 과 상호작용!");
        OnInteraction.Invoke();
        QuestManager.Instace.latestInteractObjectID = objectID;
    }
}
