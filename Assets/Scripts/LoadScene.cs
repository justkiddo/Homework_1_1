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
    
}
