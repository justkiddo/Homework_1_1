using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public void OpenSceneOne()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OpenSceneTwo()
    {
        SceneManager.LoadScene(1);
    }
    
}
