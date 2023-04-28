using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLoadScenes : MonoBehaviour
{
    
    
    public static void OpenMainMenu()
    {
        SceneManager.LoadScene("Scenes/TerrainScenes/MainMenuScene");
    }
    public static void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/TerrainScenes/TerrainScene");
    }
    public static void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
