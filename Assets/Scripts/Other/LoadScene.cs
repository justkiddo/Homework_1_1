using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public void OpenSceneOne()
    {
        SceneManager.LoadScene("Scenes/HomeworkScenes/FirstScene");
    }
    
    public void OpenSceneTwo()
    {
        SceneManager.LoadScene("Scenes/HomeworkScenes/SecondScene");
    }

    public void OpenSceneThree()
    {
        SceneManager.LoadScene("Scenes/HomeworkScenes/ThirdScene");
    }

    public void OpenSceneFour()
    {
        SceneManager.LoadScene("Scenes/HomeworkScenes/FourthScene");
    }
    
    public void OpenSceneFive()
    {
        SceneManager.LoadScene("Scenes/HomeworkScenes/FifthScene");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
