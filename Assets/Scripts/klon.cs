using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon : MonoBehaviour
{
    public float sagkisim = 2f;
    public float solkisim = -2f;
    public float ortakisim = 0f;
    public GameObject altin, kup;
    public Transform karakter;
    public characterCode codehero;
    void Start()
    {
        InvokeRepeating("klonla", 0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void klonla()
    {
        int sayi = Random.Range(0,100);
        
        if (sayi>0 && sayi<100)
        {
            create(altin, 1.0f);
            
        }
        if (sayi>30)
        {
            create(kup, 1.0f);
        }
    }
    public void create(GameObject nesne,float üst)
    {
        if(codehero.Isgame==true)
        {
          GameObject yeniklon = Instantiate(nesne);
        int sayi = Random.Range(0, 100);
        if (sayi>30 && sayi<100)
        {
            yeniklon.transform.position = new Vector3(sagkisim,üst,karakter.position.z+10.0f);
            
           
        }
        if (sayi>0&&sayi>33)
        {
            yeniklon.transform.position = new Vector3(solkisim, üst, karakter.position.z + 10.0f);
        }
        if (sayi>33 && sayi<66)
        {
            yeniklon.transform.position = new Vector3(ortakisim, üst, karakter.position.z + 10.0f);
        }
        Destroy(yeniklon, 5.0f);
        }
        else
        {
          
        }
       
    }
}
