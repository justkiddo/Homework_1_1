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
    
}
