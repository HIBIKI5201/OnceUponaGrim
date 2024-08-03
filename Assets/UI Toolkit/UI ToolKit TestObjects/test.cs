using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : VisualElement
{
    private Label _characterName;
    private Label _description;
    private VisualElement _thumbnail;

    StorySystem _storySystem;

    private string CharacterName => _characterName?.text;
    private string Description => _description?.text;

    public new class UxmlFactory : UxmlFactory<Test, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        public UxmlStringAttributeDescription characterName = new UxmlStringAttributeDescription { name = "character-name", defaultValue = "Name" };
        public UxmlStringAttributeDescription description = new UxmlStringAttributeDescription { name = "description", defaultValue = "Description" };
        public UxmlAssetAttributeDescription<Texture2D> thumbnail = new UxmlAssetAttributeDescription<Texture2D> { name = "thumbnail" };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var card = ve as Test;

            card._characterName.text = characterName.GetValueFromBag(bag, cc);
            card._description.text = description.GetValueFromBag(bag, cc);
            card._thumbnail.style.backgroundImage = thumbnail.GetValueFromBag(bag, cc);
        }
    }

    public Test()
    {
        var treeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/UI ToolKit TestObjects/Test.uxml");
        var container = treeAsset.Instantiate();
        hierarchy.Add(container);

        _characterName = container.Q<Label>("Name");
        _description = container.Q<Label>("Description");
        _thumbnail = container.Q<VisualElement>("Thumbnail");

        var card = container.Q<VisualElement>("Root");
        card.AddManipulator(new Clickable(() => OnClick()));
    }

    public void OnClick()
    {
        if (_storySystem == null)
        {
            _storySystem = GameObject.FindAnyObjectByType<StorySystem>();
        }
        
        _storySystem.NextText();
    }
}
