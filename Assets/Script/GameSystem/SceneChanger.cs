using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public enum SceneKind
    {
        Title,
        Home,
        Shop,
        Battle,
        Story,
    }

    public static readonly Dictionary<SceneKind, string> _sceneNames = new()
    {
        {SceneKind.Title, "Title" },
        {SceneKind.Home, "Home" },
        {SceneKind.Shop, "Shop" },
        {SceneKind.Battle, "Battle" },
        {SceneKind.Story, "Story" },

    };

    public static void SceneChange(SceneKind sceneKind)
    {
        SceneManager.LoadScene(_sceneNames[sceneKind]);
    }
}
