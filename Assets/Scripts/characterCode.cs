using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class characterCode : MonoBehaviour
{
    
    public Rigidbody rg;
    public  bool sol, sag, Isgame,place;
    public float hiz;
    public GameObject gameoverscene,firstscene,btn1;
    public Animator anim;
    public Transform yol1, yol2;
    public Text scoretext;
    public AudioSource coinsound, agreesound;
    public float datagold,datalevel;
    public Text startext,leveltext,veriparatext;
    
    public float starnumber;
    
    void Start()
    {
        veriparatext.text = "Altın:" + PlayerPrefs.GetFloat("gold", datagold);
        leveltext.text = "Level:" + PlayerPrefs.GetFloat("WhichLevel", datalevel);
        if (PlayerPrefs.HasKey("gold"))
        {
            datagold = PlayerPrefs.GetFloat("gold");
            
         
            
        }
        else
        {
            PlayerPrefs.SetFloat("gold", 0);
            
        }
        if(PlayerPrefs.HasKey("WhichLevel"))
        {
          datalevel=PlayerPrefs.GetFloat("WhichLevel");
          leveltext.text="Level:"+datalevel;

        }
        else
        {
            leveltext.text="Level:1";
        }
    }
 

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="wayone")
        {
            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z+40);
            
        }
        if (other.gameObject.tag == "waytwo")
        {
            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 40);
            int randomsayi=Random.Range(0,5);
            
        } 
        if (other.gameObject.tag=="Altin")
        {
            
           starnumber += Random.Range(5,40);
            
            Destroy(other.gameObject);
            coinsound.Play();

        }
        if (other.gameObject.tag=="engel")
        {
            
           Isgame=false;
            //Time.timeScale= 0.0f;
            gameoverscene.SetActive(true);
            scoretext.text = starnumber + " Altın Kazandın Patron!";
             anim.SetBool("victory", true);
             
            firstscene.SetActive(true);
            datagold += starnumber;
            
            PlayerPrefs.SetFloat("gold", datagold);
           
            // agreesound.Play();
           
           
        }
      
       
        
       
    }
   


    void Update()
    {
        
        leveldesign();
        Movement();
        starCount();
        if(datagold<1000)
            {
                btn1.SetActive(false);
                
            }
           else{
            btn1.SetActive(true);
           }
       
    }
    void Movement()
    {
         if (Isgame==true)
        {
            transform.Translate(0, 0, hiz * Time.deltaTime);
            Vector3 sagit = new Vector3(2f, transform.position.y, transform.position.z);
            Vector3 solgit = new Vector3(-2f, transform.position.y, transform.position.z);
            if (Input.touchCount > 0)
            {
                
                Touch parmak = Input.GetTouch(0);
                if (parmak.deltaPosition.x > 15.0f)
                {
                    sag = true;
                    sol = false;
                }
                if (parmak.deltaPosition.x < -15.0f)
                {
                    sag = false;
                    sol = true;
                }
                if (sag == true)
                {
                    transform.position = Vector3.Lerp(transform.position, sagit, 2 * Time.deltaTime);
                }
                if (sol == true)
                {
                    transform.position = Vector3.Lerp(transform.position, solgit, 2* Time.deltaTime);
                }
            }
        }
        
        else 
        {
           
        }
    }
    void leveldesign()
    {

        if(Isgame)
       {
if (starnumber<200)
        {
            transform.Translate(0, 0, 3 * Time.deltaTime);
            
        }
        else if (starnumber<500)
        {
            transform.Translate(0, 0, 5 * Time.deltaTime);
        }
        else if (starnumber<1000)
        {
            transform.Translate(0, 0, 6 * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
       }
         
       
    } 
    void starCount()
    {
        startext.text = "ALTIN " + starnumber;
    }
    public void levelarttir()
    {
       
        datagold -= 1000;
        datalevel++;

        PlayerPrefs.SetFloat("gold", datagold);
         veriparatext.text = "Altın:" + PlayerPrefs.GetFloat("gold", datagold);
       
        PlayerPrefs.SetFloat("WhichLevel",datalevel);
         leveltext.text = "Level:" + PlayerPrefs.GetFloat("WhichLevel", datalevel);
        
       
        
        
        
       
       
        
    }
}
  
    

