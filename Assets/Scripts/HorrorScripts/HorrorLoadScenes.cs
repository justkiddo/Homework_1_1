using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorLoadScenes : MonoBehaviour
{
    
    
    public static void OpenMainMenu()
    {
        SceneManager.LoadScene("Scenes/HorrorScenes/HorrorMainMenu");
    }
    public static void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/HorrorScenes/HorrorSceneOne");
    }
    public static void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
    
}
