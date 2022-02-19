using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public BolumTuru bolumTuru;

    [Header("OyunSonundaErisilecekler")]
    GameObject[] araba;
    GameObject kamera;
    GameObject arabalar;

    [Header("OyunSonuEfektler")]
    [SerializeField] ParticleSystem[] efektler;

    [Header("ParaBelirtmekIcin")]
    public static int dolar; 
    [SerializeField] Text paraYazi;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.6f);



    [HideInInspector] public int score;

    [HideInInspector] public bool isContinue;  // ayrintilar icin beni oku 19. satirdan itibaren bak
    public static GameController instance; // singleton yapisi icin gerekli ornek ayrintilar icin BeniOku 22. satirdan itibaren bak.


    private void Awake()
	{
        if (instance == null) instance = this;
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


    public void SetMoney(int eklenecekScore)
    {
        dolar += eklenecekScore;
        paraYazi.text = dolar.ToString() + " $";
    }

    public void SetScore(int sayi) //parti icin verilecek yildiz sayisini belirlemede kullanilacaktir
    {

    }


    //Burdan sonrasi oyun sonundaki olaylarýn olmasýný saglar
    public void OyunSonu()
    {
        araba = GameObject.FindGameObjectsWithTag("Araba");
        kamera.GetComponent<CameraMovement>().KameraOyunSonuKontrolAyarlari();
        arabalar.GetComponent<ArabayaDoldurucu>().MeyveOyunSonuAyarlayici();

        for (int i = 0; i < araba.Length; i++)
        {
            araba[i].GetComponent<Arabalar>().ArabalariDurdur();
        }

        StartCoroutine(OyunSonuEfektleriAyarla());
    }

    IEnumerator OyunSonuEfektleriAyarla()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < efektler.Length / 2; i++)
        {
            efektler[i * 2].Play();
            efektler[i * 2 + 1].Play();
            yield return beklemeSuresi;
        }
    }
}
