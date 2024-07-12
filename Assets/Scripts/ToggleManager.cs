using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Ahmet Zateroðlu

[System.Serializable]
public class ToggleManager : MonoBehaviour
{





    public Toggle muzik;
    public Toggle sesler;
    public Toggle timerses;
   

    public static int muzikackapa;
    public static int seslerackapa;
    public static int timersesackapa;

    void Start()
    {
        

    

        muzik.GetComponent<Toggle>();
        sesler.GetComponent<Toggle>();
        timerses.GetComponent<Toggle>();



        if (PlayerPrefs.HasKey("muzikackapa")) 
        {

            muzikackapa = PlayerPrefs.GetInt("muzikackapa"); 

        }
        else
        {
            PlayerPrefs.SetInt("muzikackapa", 0);

        }

        if (muzikackapa == 0)
        {

            muzik.isOn = false;

        }
        if (muzikackapa == 1)
        {

            muzik.isOn = true;

        }

        /////////////////


        if (PlayerPrefs.HasKey("seslerackapa")) 
        {

            seslerackapa = PlayerPrefs.GetInt("seslerackapa"); 

        }
        else 
        {
            PlayerPrefs.SetInt("seslerackapa", 0);

        }

        if (seslerackapa == 0)
        {

            sesler.isOn = false;

        }
        if (seslerackapa == 1)
        {

            sesler.isOn = true;

        }

        /////////////////////


        if (PlayerPrefs.HasKey("timersesackapa")) 
        {

            timersesackapa = PlayerPrefs.GetInt("timersesackapa"); 

        }
        else 
        {
            PlayerPrefs.SetInt("timersesackapa", 0);

        }

        if (timersesackapa == 0)
        {

            timerses.isOn = false;

        }
        if (timersesackapa == 1)
        {

            timerses.isOn = true;

        }
    }



    

    void Update()
    {

        MuzikAcKapa(muzik.isOn);

        SeslerAcKapa(sesler.isOn);

        TimerSesAcKapa(timerses.isOn);


    }



   
    public void MuzikAcKapa(bool deger)
    {


        if (deger == true)
        {


            muzikackapa = 1; 
            PlayerPrefs.SetInt("muzikackapa", muzikackapa);
        }
        else
        {


            muzikackapa = 0;
            PlayerPrefs.SetInt("muzikackapa", muzikackapa);
        }
    }

    public void SeslerAcKapa(bool deger)
    {


        if (deger == true)
        {
 

            seslerackapa = 1; 
            PlayerPrefs.SetInt("seslerackapa", seslerackapa);
        }
        else
        {
           

            seslerackapa = 0;
            PlayerPrefs.SetInt("seslerackapa", seslerackapa);
        }
    }

    public void TimerSesAcKapa(bool deger)
    {
    

        if (deger == true)
        {
     

            timersesackapa = 1;
            PlayerPrefs.SetInt("timersesackapa", timersesackapa);
        }
        else
        {
         

            timersesackapa = 0;
            PlayerPrefs.SetInt("timersesackapa", timersesackapa);
        }
    }





}
