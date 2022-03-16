using UnityEngine;
using UnityEditor;
using System.IO;


public class CharacterNameSOEditor
{
    private static string CSVPath = "Assets/ScriptableObjEditor/CSV/CharacterName/CharacterNames.csv";

    [MenuItem("Utilites/Generate CharacterName")]
    public static void GenerateCharacterName()
    {
        string[] allLines = File.ReadAllLines(CSVPath);

        for(int i=1; i<allLines.Length; ++i)
        {
            string[] splitData = allLines[i].Split('\n');

            if(splitData.Length != 1)
            {
                Debug.Log(allLines + " doee noe have 1 value");
                return ;
            }

            NarrationCharacter character = ScriptableObject.CreateInstance<NarrationCharacter>();

            character.characterName = splitData[0]; // 이름

            AssetDatabase.CreateAsset(character, $"Assets/ScriptableObjects/Narration/NarrationCharacter_{character.characterName}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
