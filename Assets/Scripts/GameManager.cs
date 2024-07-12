using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Ahmet Zateroğlu

public class GameManager : MonoBehaviour
{

    private Sesler Ses;  
    public GameObject sesobje; 

    public int seslerackapa;
    public int timersesackapa;
    public int timerses = 0;

    public Text soruText;  
    public Text aText;
    public Text bText;
    public Text cText;
    public Text dText;
    public Button aButton, bButton, cButton, dButton;
    public Color yesilRenk, kirmiziRenk, beyazRenk, sariRenk;

    public static int doğruCevap;
    public static int doğruCevapButonu;


    public int soruSayisi = 1;
    public int puan = 0;
    public int dogruSayisi;
    public int yanlisSayisi;

    public float sure;
    public Text puanText, soruSayisiText, sureText;
    public Text zorlukText;

    public GameObject panel, sBPanel;
    public Text panelpuan;
    public Text panelDSayisi;
    public Text panelYSayisi;

    public List<string> sorulanlar = new List<string>(); 

    void Start()
    {
        
        sorulanlar.Add("99999999"); 
        panel.SetActive(false); 
        sBPanel.SetActive(false);

        soruSayisi = 1;
        puan = 0;
        
        seslerackapa = PlayerPrefs.GetInt("seslerackapa");    
        timersesackapa = PlayerPrefs.GetInt("timersesackapa");
        Ses = sesobje.GetComponent<Sesler>();
                                               

        SoruEkle(); 
    }

    void Update()
    {

        if (sure > 0 && sure != 99)                                                                            
        {
            sure -= Time.deltaTime;
            sureText.text = sure.ToString("00");
        }

        if (sure <= 0) 
        {

            puan -= 1;
            puanText.text = puan.ToString();
            soruSayisi++; 
            SoruEkle();

        }

        if (timersesackapa == 1 && sure < 5 && timerses==0)
        {

            Invoke("TimerSes", 0.1f);  
            timerses = 1;
        }

    }



    public void SoruEkle() 
    {
    

        if (MainMenu.seviyeb == 1) 
        {          
            if (soruSayisi <= 5)
            {
                soruSayisiText.text = soruSayisi.ToString() + " / 5"; 
                SoruUret(); 
            }
            else
            {
                SBZorlukAyarla();  
                sorulanlar.Clear();  
            }
        }
        else
        {
            if (soruSayisi <= 10)
            {
                soruSayisiText.text = soruSayisi.ToString() + " / 10";  
                SoruUret();
            }
            else
            {

                sure = 99; 
                Debug.Log("Tebrikler Bitti");

                panel.SetActive(true);  
                panelDSayisi.text = dogruSayisi.ToString();
                panelYSayisi.text = yanlisSayisi.ToString();
                panelpuan.text = puan.ToString();

                MainMenu.totalpuan += puan; 
                PlayerPrefs.SetInt("totalpuan", MainMenu.totalpuan); 
                MainMenu.toplamSoru += dogruSayisi + yanlisSayisi; 
                PlayerPrefs.SetInt("toplamSoru", MainMenu.toplamSoru);
                MainMenu.toplamDogru += dogruSayisi;  
                PlayerPrefs.SetInt("toplamDogru", MainMenu.toplamDogru);
                MainMenu.toplamYanlis += yanlisSayisi;  
                PlayerPrefs.SetInt("toplamYanlis", MainMenu.toplamYanlis);


                ZorlukAyarla();  
                sorulanlar.Clear();

            }


        }


        if (MainMenu.islem == "toplama")  
        {
            zorlukText.text = (MainMenu.toplamaZorluk).ToString();
        }
        else if (MainMenu.islem == "cikarma")
        {
            zorlukText.text = (MainMenu.cikarmaZorluk).ToString();
        }
        else if (MainMenu.islem == "carpma")
        {
            zorlukText.text = (MainMenu.carpmaZorluk).ToString();
        }
        else if (MainMenu.islem == "bolme")
        {
            zorlukText.text = (MainMenu.bolmeZorluk).ToString();
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void ZorlukAyarla()
    {

        if(MainMenu.islem== "toplama")  // İşleme göre zorluk ayarlanacak
        {
            if (dogruSayisi >= 8 && MainMenu.toplamaZorluk < 6)
            {
                MainMenu.toplamaZorluk += 1;
                PlayerPrefs.SetInt("toplamaZorluk", MainMenu.toplamaZorluk);
            }
            if (yanlisSayisi >= 5 && MainMenu.toplamaZorluk > 1)
            {
                MainMenu.toplamaZorluk -= 1;
                PlayerPrefs.SetInt("toplamaZorluk", MainMenu.toplamaZorluk);
            }
            Debug.Log("toplamaZorluk= " + MainMenu.toplamaZorluk);
        }
        else if(MainMenu.islem == "cikarma")
        {
            if (dogruSayisi >= 8 && MainMenu.cikarmaZorluk < 6)
            {
                MainMenu.cikarmaZorluk += 1;
                PlayerPrefs.SetInt("cikarmaZorluk", MainMenu.cikarmaZorluk);
            }
            if (yanlisSayisi >= 5 && MainMenu.cikarmaZorluk > 1)
            {
                MainMenu.cikarmaZorluk -= 1;
                PlayerPrefs.SetInt("cikarmaZorluk", MainMenu.cikarmaZorluk);
            }
            Debug.Log("cikarmaZorluk= " + MainMenu.cikarmaZorluk);
        }
        else if (MainMenu.islem == "carpma")
        {
            if (dogruSayisi >= 8 && MainMenu.carpmaZorluk < 6)
            {
                MainMenu.carpmaZorluk += 1;
                PlayerPrefs.SetInt("carpmaZorluk", MainMenu.carpmaZorluk);
            }
            if (yanlisSayisi >= 5 && MainMenu.carpmaZorluk > 1)
            {
                MainMenu.carpmaZorluk -= 1;
                PlayerPrefs.SetInt("carpmaZorluk", MainMenu.carpmaZorluk);
            }
            Debug.Log("carpmaZorluk= " + MainMenu.carpmaZorluk);
        }
        else if (MainMenu.islem == "bolme")
        {
            if (dogruSayisi >= 8 && MainMenu.bolmeZorluk < 6)
            {
                MainMenu.bolmeZorluk += 1;
                PlayerPrefs.SetInt("bolmeZorluk", MainMenu.bolmeZorluk);
            }
            if (yanlisSayisi >= 5 && MainMenu.bolmeZorluk > 1)
            {
                MainMenu.bolmeZorluk -= 1;
                PlayerPrefs.SetInt("bolmeZorluk", MainMenu.bolmeZorluk);
            }
            Debug.Log("bolmeZorluk= " + MainMenu.bolmeZorluk);
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void SBZorlukAyarla()
    {
        if (MainMenu.islem == "toplama") 
        {
            if (dogruSayisi >= 4 && MainMenu.toplamaZorluk < 6)  
            {
                MainMenu.toplamaZorluk++;
                PlayerPrefs.SetInt("toplamaZorluk", MainMenu.toplamaZorluk);
                soruSayisi = 1;
                dogruSayisi = 0;
                SoruEkle();
            }
            else
            {
                sure = 99; 
                Debug.Log("Tebrikler Bitti");

                sBPanel.SetActive(true);  

                MainMenu.totalpuan += puan;  
                PlayerPrefs.SetInt("totalpuan", MainMenu.totalpuan); 
                MainMenu.toplamSoru += dogruSayisi + yanlisSayisi;   
                PlayerPrefs.SetInt("toplamSoru", MainMenu.toplamSoru);
                MainMenu.toplamDogru += dogruSayisi;  
                PlayerPrefs.SetInt("toplamDogru", MainMenu.toplamDogru);
                MainMenu.toplamYanlis += yanlisSayisi;  
                PlayerPrefs.SetInt("toplamYanlis", MainMenu.toplamYanlis);


            }                                       
        }
        else if (MainMenu.islem == "cikarma")
        {
            if (dogruSayisi >= 4 && MainMenu.cikarmaZorluk < 6)  
            {
                MainMenu.cikarmaZorluk++;
                PlayerPrefs.SetInt("cikarmaZorluk", MainMenu.cikarmaZorluk);
                soruSayisi = 1;
                dogruSayisi = 0;
                SoruEkle();
            }
            else
            {
                sure = 99; 
                Debug.Log("Tebrikler Bitti");
                sBPanel.SetActive(true);  
            }                  
        }
        else if (MainMenu.islem == "carpma")
        {
            if (dogruSayisi >= 4 && MainMenu.carpmaZorluk < 6) 
            {
                MainMenu.carpmaZorluk++;
                PlayerPrefs.SetInt("carpmaZorluk", MainMenu.carpmaZorluk);
                soruSayisi = 1;
                dogruSayisi = 0;
                SoruEkle();
            }
            else
            {
                sure = 99; 
                Debug.Log("Tebrikler Bitti");
                sBPanel.SetActive(true); 
            }
        }
        else if (MainMenu.islem == "bolme")
        {
            if (dogruSayisi >= 4 && MainMenu.bolmeZorluk < 6)  
            {
                MainMenu.bolmeZorluk++;
                PlayerPrefs.SetInt("bolmeZorluk", MainMenu.bolmeZorluk);
                soruSayisi = 1;
                dogruSayisi = 0;
                SoruEkle();
            }
            else
            {
                sure = 99;
                Debug.Log("Tebrikler Bitti");
                sBPanel.SetActive(true); 
            }         
        }
    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void SoruUret() 
    {             
        Random.InitState(Random.Range(1, 99999999));  

        int a = 0, b = 0, yanlis1 = 0, yanlis2 = 0, yanlis3 = 0;  
        string sorulacaksoru = "";


        if (MainMenu.islem == "toplama")
        {
            if (MainMenu.toplamaZorluk == 1)
            {

                a = Random.Range(2, 10);
                b = Random.Range(4, 12);  
                soruText.text = (a + " + " + b).ToString();  
                doğruCevap = a + b;                       

                do 
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 5);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 25;

            }
            else if (MainMenu.toplamaZorluk == 2)
            {
                a = Random.Range(8, 16);
                b = Random.Range(6, 15);
                soruText.text = (a + " + " + b).ToString();
                doğruCevap = a + b;

                do 
                {

                    int d = Random.Range(1, 3); 
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 4); 
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 4);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 22;

            }
            else if (MainMenu.toplamaZorluk == 3)
            {
                a = Random.Range(25, 50);
                b = Random.Range(20, 60);
                soruText.text = (a + " + " + b).ToString();
                doğruCevap = a + b;

                do 
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 35) / 10) * 10;                                                                                                                               
                    else                                                          
                        yanlis1 = doğruCevap - (Random.Range(10, 35) / 10) * 10;  

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);  
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 25) / 10) * 10; 
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 25) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 20;

            }
            else if (MainMenu.toplamaZorluk == 4)
            {
                a = Random.Range(50, 100);
                b = Random.Range(45, 90);
                soruText.text = (a + " + " + b).ToString();
                doğruCevap = a + b;

                do 
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 33) / 10) * 10;
                                                                                
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 33) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 24) / 10) * 10; 
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 24) / 10) * 10;


                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 18;

            }
            else if (MainMenu.toplamaZorluk == 5)
            {
                a = Random.Range(96, 250);
                b = Random.Range(90, 270);
                soruText.text = (a + " + " + b).ToString();
                doğruCevap = a + b;

                do 
                {

                    int d = Random.Range(1, 3); 
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 32) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;  
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 32) / 10) * 10 + (Random.Range(10, 22) / 10) * 100; 

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100; 
                    else
                        yanlis2 = doğruCevap - 100;  

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 26) / 10) * 10 + (Random.Range(10, 23) / 10) * 100; 
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 26) / 10) * 10 - (Random.Range(10, 23) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 17;
            }
            else if (MainMenu.toplamaZorluk == 6)
            {
                a = Random.Range(260, 500);
                b = Random.Range(250, 500);
                soruText.text = (a + " + " + b).ToString();
                doğruCevap = a + b;

                do 
                {

                    int d = Random.Range(1, 3); 
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 31) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;  

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + (Random.Range(10, 31) / 10) * 10;  
                    else
                        yanlis2 = doğruCevap - (Random.Range(10, 31) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 23) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 23) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 15;

            }

        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
   


        if (MainMenu.islem == "cikarma")
        {
            if (MainMenu.cikarmaZorluk == 1)
            {

                do
                {
                    a = Random.Range(5, 20);
                    b = Random.Range(4, 15);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b; ;

                do
                {
                    int d = Random.Range(1, 3); 
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 5);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 25;

            }
            else if (MainMenu.cikarmaZorluk == 2)
            {
                do 
                {
                    a = Random.Range(25, 40);
                    b = Random.Range(5, 35);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b;

                do
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 4);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 22;

            }
            else if (MainMenu.cikarmaZorluk == 3)
            {
                do  
                {
                    a = Random.Range(45, 99);
                    b = Random.Range(15, 69);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b;

                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 35) / 10) * 10;                                                                                                                               
                    else                                                         
                        yanlis1 = doğruCevap - (Random.Range(10, 35) / 10) * 10; 

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);  
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 25) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 25) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);
                
                sure = 20;

            }
            else if (MainMenu.cikarmaZorluk == 4)
            {
                do  
                {
                    a = Random.Range(69, 200);
                    b = Random.Range(39, 150);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b;


                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 33) / 10) * 10;

                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 33) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 24) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 24) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 18;
            }
            else if (MainMenu.cikarmaZorluk == 5)
            {
                do  
                {
                    a = Random.Range(350, 699);
                    b = Random.Range(150, 399);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b;

                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 32) / 10) * 10 - (Random.Range(10, 26) / 10) * 100;  
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 32) / 10) * 10 + (Random.Range(10, 26) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100; 
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 31) / 10) * 10 + (Random.Range(10, 25) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 25) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 16;

            }
            else if (MainMenu.cikarmaZorluk == 6)
            {
                do  
                {
                    a = Random.Range(450, 999);
                    b = Random.Range(300, 599);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                doğruCevap = a - b;


                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 32) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 32) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100;
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 25) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 25) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 12;

            }
                    
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        if (MainMenu.islem == "carpma")
        {
            if (MainMenu.carpmaZorluk == 1)
            {
                a = Random.Range(1, 6);
                b = Random.Range(1, 6);
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;


                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 5);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 25;
            }
            else if (MainMenu.carpmaZorluk == 2)
            {

                a = Random.Range(1, 11);
                b = Random.Range(1, 11);
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;

               

                do
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 4);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 22;

            }
            else if (MainMenu.carpmaZorluk == 3)
            {
                a = Random.Range(12, 21);
                b = Random.Range(6, 15);
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;

               

                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 35) / 10) * 10;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 35) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 25) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 25) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 20;

            }
            else if (MainMenu.carpmaZorluk == 4)
            {
                a = Random.Range(18, 30);
                b = Random.Range(14, 25);  
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;

               
                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 33) / 10) * 10;

                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 33) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 24) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 24) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 18;
            }
            else if (MainMenu.carpmaZorluk == 5)
            {
                a = Random.Range(25, 60);
                b = Random.Range(15, 45);  
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;

                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 32) / 10) * 10 - (Random.Range(10, 26) / 10) * 100;  
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 32) / 10) * 10 + (Random.Range(10, 26) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100; 
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 31) / 10) * 10 + (Random.Range(10, 25) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 25) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 16;

            }
            else if (MainMenu.carpmaZorluk == 6)
            {
                a = Random.Range(35, 65);
                b = Random.Range(25, 45); 
                soruText.text = (a + " x " + b).ToString();
                doğruCevap = a * b;


                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 31) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100;
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 23) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 23) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 12;

            }

        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        if (MainMenu.islem == "bolme")
        {
            if (MainMenu.bolmeZorluk == 1)
            {

                do  
                {
                    a = Random.Range(15, 61);
                    b = Random.Range(2, 7);
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;

                


                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 5);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 5);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 5);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 25;

            }
            else if (MainMenu.bolmeZorluk == 2)
            {

                do  
                {
                    a = Random.Range(24, 101);
                    b = Random.Range(2, 10); 
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;

               

                do
                {

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + Random.Range(1, 4);
                    else
                        yanlis3 = doğruCevap - Random.Range(1, 4);

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 22;

            }
            else if (MainMenu.bolmeZorluk == 3)
            {
                do 
                {
                    a = Random.Range(110, 488);
                    b = Random.Range(4, 25);  
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;

                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 35) / 10) * 10;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 35) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 25) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 25) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 20;

            }
            else if (MainMenu.bolmeZorluk == 4)
            {
                do  
                {
                    a = Random.Range(180, 588);
                    b = Random.Range(4, 23); 
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;


                do
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 33) / 10) * 10;

                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 33) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + Random.Range(1, 7);
                    else
                        yanlis2 = doğruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(10, 24) / 10) * 10;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 24) / 10) * 10;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 18;
            }
            else if (MainMenu.bolmeZorluk == 5)
            {
                do  
                {
                    a = Random.Range(250, 688);
                    b = Random.Range(5, 20);  
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;

                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 32) / 10) * 10 - (Random.Range(10, 26) / 10) * 100;  
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 32) / 10) * 10 + (Random.Range(10, 26) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100; 
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 31) / 10) * 10 + (Random.Range(10, 25) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 25) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 16;

            }
            else if (MainMenu.bolmeZorluk == 6)
            {
                do  
                {
                    a = Random.Range(399, 988);
                    b = Random.Range(6, 26);  
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                doğruCevap = a / b;


                do 
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = doğruCevap + (Random.Range(10, 31) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis1 = doğruCevap - (Random.Range(10, 31) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = doğruCevap + 100;
                    else
                        yanlis2 = doğruCevap - 100;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = doğruCevap + (Random.Range(12, 23) / 10) * 10 + (Random.Range(10, 22) / 10) * 100;
                    else
                        yanlis3 = doğruCevap - (Random.Range(10, 23) / 10) * 10 - (Random.Range(10, 22) / 10) * 100;

                } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

                sure = 12;

            }

        }


        sorulacaksoru += a.ToString();
        sorulacaksoru += b.ToString();

        KontrolEt(sorulacaksoru);  

        SecenekleriYazdirma(yanlis1, yanlis2, yanlis3);


    }




     


    public void KontrolEt(string sorulacaksoru) 
    {

        if(sorulanlar.Count<=10)  
        {
            for (int i = 0; i < (sorulanlar.Count); i++) 
            {
                if (sorulacaksoru == sorulanlar[i])
                {
                    Debug.Log("Bu soru Var");
                    SoruUret();
                }

            }
            sorulanlar.Add(sorulacaksoru);  
        }
        else
        {
            sorulanlar.Clear();
        }
        
    }


    public void SecenekleriYazdirma(int yanlis1, int yanlis2, int yanlis3)
    {


        int c = Random.Range(1, 5);
        if (c == 1)
        {
            doğruCevapButonu = 1;
            aText.text = doğruCevap.ToString();
            bText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 2)
        {
            doğruCevapButonu = 2;
            bText.text = doğruCevap.ToString();
            aText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 3)
        {
            doğruCevapButonu = 3;
            cText.text = doğruCevap.ToString();
            bText.text = yanlis1.ToString();
            aText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 4)
        {
            doğruCevapButonu = 4;
            dText.text = doğruCevap.ToString();
            bText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            aText.text = yanlis3.ToString();
        }


        aButton.enabled = true; 
        bButton.enabled = true;
        cButton.enabled = true;
        dButton.enabled = true;

        aButton.image.color = beyazRenk; 
        bButton.image.color = beyazRenk;
        cButton.image.color = beyazRenk;
        dButton.image.color = beyazRenk;

        timerses = 0;




    }





    public void VerilenCevap(string x)
    {
        if (sure != 99) 
        {

            if (timersesackapa == 1) 
            {
                Ses.TimerSesiKapa(); 
                CancelInvoke();
                                

            }

            string a = aText.text;  
            string b = bText.text;
            string c = cText.text;
            string d = dText.text;
            int verilenCevap;

           

            if (x == "a") 
            {
                aButton.enabled = false; 
                bButton.enabled = false;
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(a);  

                if (verilenCevap == doğruCevap)
                {
                    if (seslerackapa == 1) 
                    {
                        Ses.DogruSesiCal();
                    }

                    aButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    aButton.image.color = kirmiziRenk;

                    if (doğruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();

                }
                sure = 99;
                
                    Invoke("SoruEkle", (float)1.2);              
                              

            }
            if (x == "b")
            {
                aButton.enabled = false; 
                bButton.enabled = false;
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(b);
                if (verilenCevap == doğruCevap)
                {
                    if (seslerackapa == 1) 
                    {
                        Ses.DogruSesiCal(); 
                    }

                    bButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    bButton.image.color = kirmiziRenk;

                    if (doğruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
              
               
                   Invoke("SoruEkle", (float)1.2);  
               
            }
            if (x == "c")
            {
                aButton.enabled = false; 
                bButton.enabled = false;
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(c);
                if (verilenCevap == doğruCevap)
                {
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal();
                    }

                    cButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    cButton.image.color = kirmiziRenk;
                    if (doğruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
             
             
                    Invoke("SoruEkle", (float)1.2); 
              
            }
            if (x == "d")
            {
                aButton.enabled = false;
                bButton.enabled = false;
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(d);
                if (verilenCevap == doğruCevap)
                {
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal();
                    }

                    dButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    dButton.image.color = kirmiziRenk;
                    if (doğruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (doğruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
               
                    Invoke("SoruEkle", (float)1.2); 
                
            }
        }


        soruSayisi++; 
     
    }

 

    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);

    }

    public void YeniTest()
    {
        SceneManager.LoadScene(1);
        
    }

    public void TimerSes()
    {

        Ses.TimerSesiCal();
    }





}
