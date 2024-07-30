using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text textBox;

    [Header("オブジェクト")]
    [SerializeField]
    public List<StoryCharacterList> characterList = new() 
    {
        new StoryCharacterList {characterType = "player", characterName = MainSystem._playerName}
    };

    [SerializeField]
    List<StoryTextList> textList = new();

    public Dictionary<string, string> CharacterNames = new();
    int textNumber;

    private void Start()
    {
        foreach (var character in characterList)
        {
            CharacterNames.Add(character.characterType, character.characterName);
        }
    }

    public void NextText()
    {
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
