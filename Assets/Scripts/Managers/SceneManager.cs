using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static void ChangeScene(int numberScenes)
    {
        //PauseManager.ContinueGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene(numberScenes);
    }

    public void RestartScene()
    {
        //PauseManager.ContinueGame();
        int index = (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        ChangeScene(index);
    }

    public void NextScene()
    {
        //PauseManager.ContinueGame();
        int index = (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)+1;
        if (index < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings) ChangeScene(index);
        else Debug.Log("Индекс сцены за пределами диапазона!");
    }
}
