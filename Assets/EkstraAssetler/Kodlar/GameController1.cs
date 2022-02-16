using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController1 : MonoBehaviour
{
    [Header("OyunSonundaErisilecekler")]
    GameObject[] araba;
    GameObject kamera;
    GameObject arabalar;

    [Header("OyunSonuEfektler")]
    [SerializeField] ParticleSystem[] efektler;

    [Header("ParaBelirtmekIcin")]
    float paraMiktari;
    [SerializeField] Text paraYazi;
    [SerializeField] Image paraGosterici;


    WaitForSeconds beklemeSuresi = new WaitForSeconds(.5f);

    void Start()
    {
        kamera = GameObject.FindWithTag("MainCamera");
        arabalar = GameObject.FindWithTag("Arabalar");

        Application.targetFrameRate = 45;
    }

    private void Update()
    {
        if (Time.frameCount % 15 == 0)
        {
            System.GC.Collect();
        }
    }

    public void SetScore(int eklenecekScore)
    {
        paraMiktari += eklenecekScore;
        paraYazi.text = paraMiktari.ToString() + " $";
        paraGosterici.fillAmount = (float)paraMiktari / 10000;
    }


    //Burdan sonrasi oyun sonundaki olaylarýn olmasýný saglar
    public void OyunSonu()
    {
        araba = GameObject.FindGameObjectsWithTag("Araba");
        kamera.GetComponent<Kamera>().KameraOyunSonuKontrolAyarlari();
        arabalar.GetComponent<ArabayaDoldurucu>().MeyveOyunSonuAyarlayici();

        for (int i = 0; i < araba.Length; i++)
        {
            araba[i].GetComponent<Arabalar>().ArabalariDurdur();
        }

        StartCoroutine(OyunSonuEfektleriAyarla());
    }

    IEnumerator OyunSonuEfektleriAyarla()
    {

        for (int i = 0; i < efektler.Length / 2; i++)
        {
            efektler[i * 2].Play();
            efektler[i * 2 + 1].Play();
            yield return beklemeSuresi;
        }

    }
}
