using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

// Ahmet Zateroðlu



public class MainMenu : MonoBehaviour
{

    public static string islem = "toplama"; 
    public static int toplamaZorluk = 1; 
    public static int cikarmaZorluk = 1;
    public static int carpmaZorluk = 1;
    public static int bolmeZorluk = 1;
    public static int seviyeb = 1;  

    public GameObject ayarlarpanel;

    public GameObject puanpanel;

    public GameObject toplamaSeviyeButton, toplamaButton, cikarmaSeviyeButton, cikarmaButton, carpmaSeviyeButton, carpmaButton, bolmeSeviyeButton, bolmeButton;



    public Text totalpuantext;     


    public static int totalpuan;

    public static int toplamSoru;
    public static int toplamDogru;
    public static int toplamYanlis;

    public Text toplamSoruText;
    public Text toplamDogruText;
    public Text toplamYanlisText;


    public Text tZorluk, cZorluk, carpZorluk, bZorluk;



    void Start()
    {
  

        ayarlarpanel.SetActive(false);
        puanpanel.SetActive(false);
        


        if (PlayerPrefs.HasKey("toplamaZorluk")) 
        {
            toplamaZorluk = PlayerPrefs.GetInt("toplamaZorluk"); 
        }
        else 
        {
            PlayerPrefs.SetInt("toplamaZorluk", 1); 
        }

        if (PlayerPrefs.HasKey("cikarmaZorluk")) 
        {
            cikarmaZorluk = PlayerPrefs.GetInt("cikarmaZorluk"); 
        }
        else 
        {
            PlayerPrefs.SetInt("cikarmaZorluk", 1);
        }

        if (PlayerPrefs.HasKey("carpmaZorluk"))
        {
            carpmaZorluk = PlayerPrefs.GetInt("carpmaZorluk");
        }
        else
        {
            PlayerPrefs.SetInt("carpmaZorluk", 1);
        }

        if (PlayerPrefs.HasKey("bolmeZorluk"))
        {
            bolmeZorluk = PlayerPrefs.GetInt("bolmeZorluk");
        }
        else
        {
            PlayerPrefs.SetInt("bolmeZorluk", 1);
        }

        tZorluk.text = toplamaZorluk.ToString();
        cZorluk.text = cikarmaZorluk.ToString();
        carpZorluk.text = carpmaZorluk.ToString();
        bZorluk.text = bolmeZorluk.ToString();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        if (toplamaZorluk > 1)
        {
            toplamaSeviyeButton.SetActive(false);
            toplamaButton.SetActive(true);
        }
        else
        {
            toplamaSeviyeButton.SetActive(true);
            toplamaButton.SetActive(false);
        }

        if (cikarmaZorluk > 1)
        {
            cikarmaSeviyeButton.SetActive(false);
            cikarmaButton.SetActive(true);
        }
        else
        {
            cikarmaSeviyeButton.SetActive(true);
            cikarmaButton.SetActive(false);
        }

        if (carpmaZorluk > 1)
        {
            carpmaSeviyeButton.SetActive(false);
            carpmaButton.SetActive(true);
        }
        else
        {
            carpmaSeviyeButton.SetActive(true);
            carpmaButton.SetActive(false);
        }

        if (bolmeZorluk > 1)
        {
            bolmeSeviyeButton.SetActive(false);
            bolmeButton.SetActive(true);
        }
        else
        {
            bolmeSeviyeButton.SetActive(true);
            bolmeButton.SetActive(false);
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        if (PlayerPrefs.HasKey("totalpuan"))
        {

            totalpuan = PlayerPrefs.GetInt("totalpuan"); 
            totalpuantext.text = totalpuan.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("totalpuan", 0);
            totalpuantext.text = PlayerPrefs.GetInt("totalpuan").ToString();
        }


        if (PlayerPrefs.HasKey("toplamSoru")) 
        {
            toplamSoru = PlayerPrefs.GetInt("toplamSoru");
            toplamSoruText.text = toplamSoru.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("toplamSoru", 0);
            toplamSoruText.text = PlayerPrefs.GetInt("toplamSoru").ToString();
        }

        if (PlayerPrefs.HasKey("toplamDogru")) 
        {
            toplamDogru = PlayerPrefs.GetInt("toplamDogru"); 
            toplamDogruText.text = toplamDogru.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("toplamDogru", 0);
            toplamDogruText.text = PlayerPrefs.GetInt("toplamDogru").ToString();
        }

        if (PlayerPrefs.HasKey("toplamYanlis")) 
        {
            toplamYanlis = PlayerPrefs.GetInt("toplamYanlis"); 
            toplamYanlisText.text = toplamYanlis.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("toplamYanlis", 0);
            toplamYanlisText.text = PlayerPrefs.GetInt("toplamYanlis").ToString();
        }





    }


    void Update()
    {
        


    }


 
    public void SeviyeSifirla()  
    {
        PlayerPrefs.SetInt("totalpuan", 0);
        PlayerPrefs.SetInt("rekabetcipuan", 0);
        PlayerPrefs.SetInt("toplamSoru", 0);
        PlayerPrefs.SetInt("toplamDogru", 0);
        PlayerPrefs.SetInt("toplamYanlis", 0);
        PlayerPrefs.SetInt("toplamaZorluk", 1);
        PlayerPrefs.SetInt("cikarmaZorluk", 1);
        PlayerPrefs.SetInt("carpmaZorluk", 1);
        PlayerPrefs.SetInt("bolmeZorluk", 1);

        Start();
    }

    public void SeviyeBelirleme(int deger)
    {
        if (deger == 0)
        {
            seviyeb = 0;
        
        }
        if (deger == 1)
        {
            seviyeb = 1;
        }

    }


    public void IslemSec(string islemsec)
    {
        islem = islemsec;
    }


    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() 
    {
        Debug.Log("Çýktýk");
        Application.Quit(); 
    }


    public void PanelAyarlari(int x)  
    {
        if (x == 0)
        {
            ayarlarpanel.SetActive(true);

        }
        if (x == 1)
        {
            ayarlarpanel.SetActive(false);
        }
      
        if (x == 4)
        {
            puanpanel.SetActive(true);
        }
        if (x == 5)
        {
            puanpanel.SetActive(false);
        }

    }




}
