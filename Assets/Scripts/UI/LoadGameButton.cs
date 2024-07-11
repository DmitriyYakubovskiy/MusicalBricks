using Assets.Scripts;
using TMPro;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    public void LoadGame()
    {
        CurrentMap.Name=inputField.text;
        CurrentMap.MusicName=inputField.text;
        SceneManager.ChangeScene(1);
    }
}
