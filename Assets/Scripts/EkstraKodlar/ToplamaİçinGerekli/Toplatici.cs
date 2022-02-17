using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toplatici : MonoBehaviour
{
    [SerializeField] BolumTuru bolumTuru;
    [SerializeField] Bina0 pasta;
    [SerializeField] Bina1 bar;


    [Header("KaraktereErisim")]
    GameObject player;
    KarakterPara karakterPara;

    [Header("MeyveResimleriniIcinGerekli")]
    [SerializeField] GameObject[] pastaResimleri;
    [SerializeField] GameObject[] barResimleri;


    [Header("MeshPasiflestirmeIcinGerekli")]
    MeshRenderer mesh;

    [Header("MeyveninArabayaKoyulmasi")]
    ArabayaDoldurucu arabayadoldurucu;

    [Header("FiyatlaIlgiliDuzenleme")]
    [SerializeField] int fiyat;
    [SerializeField] Text fiyatYazdirici;

    [Header("KapiRenkleriIcin")]
    [SerializeField] private Material[] renk;
    Renderer renderer;

    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.25f); //Meyveyi yerlestirme suresi
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(.5f); //Kapi rengini guncelleme suresi 

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<Renderer>();
        karakterPara = GameObject.FindWithTag("Player").GetComponent<KarakterPara>();
        arabayadoldurucu = GameObject.FindWithTag("Arabalar").GetComponent<ArabayaDoldurucu>();

        fiyatYazdirici.text = fiyat.ToString() + " $";

        mesh = GetComponent<MeshRenderer>();

        ResimiBelirleKapi();
        StartCoroutine(KapiRenginiGuncelle());
    }

    //Kapida olusacak olan resimi belirler
    private void ResimiBelirleKapi()
    {
        if(bolumTuru.ToString() == "Pasta")
        {
            if (pasta.ToString() == "Kirmizi")
            {
                pastaResimleri[0].SetActive(true);
            }
            else if (pasta.ToString() == "Sari")
            {
                pastaResimleri[1].SetActive(true);
            }
            else if (pasta.ToString() == "Mavi")
            {
                pastaResimleri[2].SetActive(true);
            }
            else if (pasta.ToString() == "Yesil")
            {
                pastaResimleri[3].SetActive(true);
            }
        }
        else if (bolumTuru.ToString() == "Bar")
        {
            if (bar.ToString() == "SandalyeKirmizi")
            {
                barResimleri[0].SetActive(true);
            }
            else if (bar.ToString() == "SandalyeMavi")
            {
                barResimleri[1].SetActive(true);
            }
            else if (bar.ToString() == "MasaSari")
            {
                barResimleri[2].SetActive(true);
            }
            else if (bar.ToString() == "MasaYesil")
            {
                barResimleri[3].SetActive(true);
            }
        }

    }

    
    //Kapinin rengini player in parasina gore günceller
    IEnumerator KapiRenginiGuncelle()
    {
        while((player.transform.position.z - transform.position.z) <= 10)
        {
            if(GameController.dolar >= fiyat)
            {
                renderer.material = renk[0];   
            }
            else
            {
                renderer.material = renk[1];
            }
            yield return beklemeSuresi2;
        }
    }

    

    //Kapiya temas anini ayarlar
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            karakterPara.meyveSatinAl(fiyat);

            ResimPasiflestir();
            StartCoroutine(meyveCikarmaAyari());
            DigerKapidanMeyveAlmayiPasiflestir();
        }
    }

    //kapiya temastan sonra resimi pasiflestirir
    private void ResimPasiflestir()
    {
        mesh.enabled = false;
        if (bolumTuru.ToString() == "Pasta")
        {
            for (int i = 0; i < pastaResimleri.Length; i++)
            {
                pastaResimleri[i].SetActive(false);
            }
        }
        else if(bolumTuru.ToString() == "Bar")
        {
           
            for (int i = 0; i < pastaResimleri.Length; i++)
            {
                barResimleri[i].SetActive(false);
            }
        }
    }

    IEnumerator meyveCikarmaAyari()
    {
        for (int i = 0; i < Random.Range(3, 7); i++)
        {
            MeyveCikar();
            yield return beklemeSuresi1;
        }
    }

    //
    private void MeyveCikar()
    {
        if(bolumTuru.ToString() == "Pasta")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(bolumTuru.ToString(), pasta.ToString());
        }
        else if (bolumTuru.ToString() == "Bar")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(bolumTuru.ToString(),bar.ToString());
        }    
    }

    //Iki kapidan ayni anda meyve almasini engeller
    private void DigerKapidanMeyveAlmayiPasiflestir()
    {
        for (int i = 0; i < 2; i++)
        {
            transform.root.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
    }
}
