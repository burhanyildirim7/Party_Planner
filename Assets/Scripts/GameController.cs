using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("OyunSonundaErisilecekler")]
    GameObject[] araba;
    GameObject kamera;
    GameObject arabalar;

    [Header("ParaBelirtmekIcin")]
    public static int para;
    [SerializeField] Text paraYazi;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.6f);



    [HideInInspector] public int score;

    [HideInInspector] public bool isContinue;  // ayrintilar icin beni oku 19. satirdan itibaren bak
    public static GameController instance; // singleton yapisi icin gerekli ornek ayrintilar icin BeniOku 22. satirdan itibaren bak.


    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ParayiSifirla()
    {
        para = 0;
        paraYazi.text = para.ToString() + " $";
    }

    void Start()
    {
        isContinue = false;

        kamera = GameObject.FindWithTag("MainCamera");
        arabalar = GameObject.FindWithTag("Arabalar");

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Time.frameCount % 15 == 0)
        {
            System.GC.Collect();
        }
    }


    public void SetMoney(int eklenecekPara)
    {
        if(para + eklenecekPara < 0)
        {
            isContinue = false;
            GameObject.FindWithTag("Player").GetComponent<AnimationController>().KosuPasif();
            UIController.instance.ActivateLooseScreen();
        }
        else
        {
            para += eklenecekPara;
            paraYazi.text = para.ToString() + " $";
        }
    }

    public void SetScore(int sayi) //parti icin verilecek yildiz sayisini belirlemede kullanilacaktir
    {

    }


    //Burdan sonrasi oyun sonundaki olaylarýn olmasýný saglar
    public void OyunSonu()
    {
        araba = GameObject.FindGameObjectsWithTag("Araba");
        kamera.GetComponent<CameraMovement>().KameraOyunSonuKontrolAyarlari();
        arabalar.GetComponent<ArabayaDoldurucu>().EsyaOyunSonuAyarlayici();
        GameObject.FindWithTag("finish").GetComponent<BolumSonuEfekt>().EfektleriBaslat();

        for (int i = 0; i < araba.Length; i++)
        {
            araba[i].GetComponent<Arabalar>().ArabalariDurdur();
        }
    }

    
}
