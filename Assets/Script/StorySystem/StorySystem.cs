using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text _textBox;

    [Header("�I�u�W�F�N�g")]
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
        //CharacterNames�����Z�b�g����
        _characterNames.Clear();
        foreach (var character in _characterList)
        {
            _characterNames.Add(Array.IndexOf(_characterList.ToArray(), character), character.characterName);
        }

        //Animators�����Z�b�g����
        _animators.Clear();
        foreach (var character in _characterList)
        {
            if (character.gameObject)
            {
                if (character.gameObject.TryGetComponent<Animator>(out Animator animetor))
                {
                    _animators.Add(Array.IndexOf(_characterList.ToArray(), character), animetor);
                }
                else { Debug.LogWarning($"{character.gameObject.name}��Animator���A�^�b�`���Ă�������"); }
            }
            else { Debug.LogWarning($"{character}�ɃI�u�W�F�N�g���A�T�C�����Ă�������"); }
        }

        if (_textBox == null) { Debug.LogWarning("�e�L�X�g�{�b�N�X���A�T�C�����Ă�������"); }
    }

    public void NextText()
    {
        // �����Ă���L�����N�^�[�̖��O���擾
        Debug.Log(_characterNames[_textList[_textNumber].characterType]);

        //textList��kind�ɉ����ē�����ς���
        switch (_textList[_textNumber].kind)
        {
            case StoryTextList.TextKind.text:

                //|�������Ɖ��s����
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

                //�Ώۂ�Animator��Play���\�b�h�𑗂�\��
                _animators[_textList[_textNumber].characterType].Play(_textList[_textNumber].text);

                break;


            case StoryTextList.TextKind.effect:

                //������

                break;
        }

        //���̃e�L�X�g�ɂ���
        if (_textList.Count - 1 > _textNumber)
        {
            _textNumber++;
        }
        else { Debug.LogWarning("�e�L�X�g�͏I�����܂���"); }
    }
}
