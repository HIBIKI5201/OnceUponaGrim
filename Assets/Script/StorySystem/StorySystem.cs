using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text _textBox;

    [Header("オブジェクト")]
    public List<StoryCharacterList> _characterList = new()
    {
        new StoryCharacterList { characterName = MainSystem._playerName},
        new StoryCharacterList { characterName = "Grim" },
    };

    [SerializeField]
    List<StoryTextList> _textList = new();

    readonly Dictionary<int, string> _characterNames = new();
    readonly Dictionary<int, Animator> _animators = new();

    int _textNumber;

    private void Start()
    {
        //CharacterNamesをリセットする
        _characterNames.Clear();
        foreach (var character in _characterList)
        {
            _characterNames.Add(Array.IndexOf(_characterList.ToArray(), character), character.characterName);
        }

        //Animatorsをリセットする
        _animators.Clear();
        foreach (var character in _characterList)
        {
            if (character.gameObject)
            {
                if (character.gameObject.TryGetComponent<Animator>(out Animator animetor))
                {
                    _animators.Add(Array.IndexOf(_characterList.ToArray(), character), animetor);
                }
                else { Debug.LogWarning($"{character.gameObject.name}にAnimatorをアタッチしてください"); }
            }
            else { Debug.LogWarning($"{character}にオブジェクトをアサインしてください"); }
        }

        if (_textBox == null) { Debug.LogWarning("テキストボックスをアサインしてください"); }
    }

    public void NextText()
    {
        // 喋っているキャラクターの名前を取得
        Debug.Log(_characterNames[_textList[_textNumber].characterType]);

        //textListのkindに応じて動きを変える
        switch (_textList[_textNumber].kind)
        {
            case StoryTextList.TextKind.text:

                //|を書くと改行する
                string[] texts = _textList[_textNumber].text.Split('|');
                string text = "";

                foreach (var oneText in texts)
                {
                    text += oneText;
                    text += "\n";
                }

                Debug.Log(text);
                if (_textBox)
                {
                    _textBox.text = text;
                }

                break;


            case StoryTextList.TextKind.move:

                //対象のAnimatorにPlayメソッドを送る予定
                _animators[_textList[_textNumber].characterType].Play(_textList[_textNumber].text);

                break;


            case StoryTextList.TextKind.effect:

                //未完成

                break;
        }

        //次のテキストにする
        if (_textList.Count - 1 > _textNumber)
        {
            _textNumber++;
        }
        else { Debug.LogWarning("テキストは終了しました"); }
    }
}
