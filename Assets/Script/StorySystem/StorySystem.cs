using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text textBox;

    public enum CharacterKind
    {
        Player,
        Palpal,
        other1,
        other2,
        other3,
    }

    [Header("オブジェクト")]
    [SerializeField]
    public List<StoryCharacterList> characterList = new() 
    {
        new StoryCharacterList {characterKind = CharacterKind.Player , characterName = MainSystem._playerName}
    };

    [SerializeField]
    List<StoryTextList> textList = new();

    public Dictionary<CharacterKind, string> CharacterNames = new();


    int textNumber;

    private void Start()
    {
        foreach (var character in characterList)
        {
            CharacterNames.Add(character.characterKind, character.characterName);
        }
    }

    public void NextText()
    {
        Debug.Log(CharacterNames[textList[textNumber].characterType]);

        if (int.TryParse(textList[textNumber].text, out int intValue))
        {
            switch (intValue)
            {
                case 1:
                    Debug.Log("一番");
                    break;
            }
        }
        else
        {
            Debug.Log(textList[textNumber].text);
            //textBox.text = text[textNumber];
        }


        textNumber++;
    }


}
