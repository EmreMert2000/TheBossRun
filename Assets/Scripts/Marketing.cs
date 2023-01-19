using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Marketing : MonoBehaviour
{
    public float veripara,mrseviye;
    public Text veriparatext,durumtext,leveltext;
    public GameObject button1,durumtextt;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("para"))
        {
           
            veripara=PlayerPrefs.GetFloat("para");
            veriparatext.text = "ALTIN:" + veripara;
        }
        else
        {
            veriparatext.text = "Paranız yok.";

        }
        if(PlayerPrefs.HasKey("MrLevel"))
        {
          mrseviye=PlayerPrefs.GetFloat("MrLevel");
          leveltext.text="Level:"+mrseviye;

        }
        else
        {
            leveltext.text="Level:1";
        }
         
       
           

    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerPrefs.GetFloat("para")<1000)
        {
          button1.SetActive(false);
          durumtextt.SetActive(true);
        }
    }
    
    public void kabulet()
    {
        
        
        veripara -= 1000;
        mrseviye++;
        PlayerPrefs.SetFloat("para", veripara);
        
        PlayerPrefs.SetFloat("MrLevel",mrseviye);
        veriparatext.text = "Altın:" + PlayerPrefs.GetFloat("para", veripara);
        leveltext.text = "Level:" + PlayerPrefs.GetFloat("MrLevel", mrseviye);
        
        
    }

  
    public void menu()
    {
        SceneManager.LoadScene("mainmenu");
    }
   
}
