using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLoadScenes : MonoBehaviour
{
    
    
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Scenes/TerrainScenes/MainMenuScene");
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/TerrainScenes/TerrainScene");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
