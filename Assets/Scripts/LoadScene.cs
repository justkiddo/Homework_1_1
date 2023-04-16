using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public void OpenSceneOne()
    {
        SceneManager.LoadScene("Scenes/FirstScene");
    }
    
    public void OpenSceneTwo()
    {
        SceneManager.LoadScene("Scenes/SecondScene");
    }

    public void OpenSceneThree()
    {
        SceneManager.LoadScene("Scenes/ThirdScene");
    }

    public void OpenSceneFour()
    {
        SceneManager.LoadScene("Scenes/FourthScene");
    }
    
    public void OpenSceneFive()
    {
        SceneManager.LoadScene("Scenes/FifthScene");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
