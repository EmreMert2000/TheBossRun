using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    
   
   public void tekraroyna()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
    
 
   
    public void quitscene()
    {
        Application.Quit();
    }
}
