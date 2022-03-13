using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string _characterName;
    public string characterName
    {
        get
        {
            return _characterName;
        }
        set
        {
            _characterName=value;
        }
    }
}
