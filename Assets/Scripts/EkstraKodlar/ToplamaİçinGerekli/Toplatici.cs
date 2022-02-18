using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toplatici : MonoBehaviour
{
    [SerializeField] BolumTuru bolumTuru;
    [SerializeField] Bar bar;
    [SerializeField] KonserAlani konserAlani;
    [SerializeField] Davetliler davetliler;

    [Header("FiyatlaIlgiliDuzenleme")]
    [SerializeField] int fiyat;
    [SerializeField] Text fiyatYazdirici;


    [Header("KaraktereErisim")]
    GameObject player;
    KarakterPara karakterPara;

    [Header("MeyveResimleriniIcinGerekli")]
    [SerializeField] GameObject[] barResimleri;
    [SerializeField] GameObject[] muzikGrubuResimleri;
    [SerializeField] GameObject[] davetlilerResimleri;


    [Header("MeshPasiflestirmeIcinGerekli")]
    MeshRenderer mesh;

    [Header("MeyveninArabayaKoyulmasi")]
    ArabayaDoldurucu arabayadoldurucu;

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
        if(bolumTuru.ToString() == "Bar")
        {
            if (bar.ToString() == "SandalyeKirmizi")
            {
                barResimleri[0].SetActive(true);
            }
            else if (bar.ToString() == "SandalyeMavi")
            {
                barResimleri[1].SetActive(true);
            }
            else if (bar.ToString() == "IcecekKirmizi")
            {
                barResimleri[2].SetActive(true);
            }
            else if (bar.ToString() == "IcecekMavi")
            {
                barResimleri[3].SetActive(true);
            }
        }
        else if (bolumTuru.ToString() == "MuzikGurubu")
        {
            if (konserAlani.ToString() == "HoparlorKirmizi")
            {
                muzikGrubuResimleri[0].SetActive(true);
            }
            else if (konserAlani.ToString() == "HoparlorMavi")
            {
                muzikGrubuResimleri[1].SetActive(true);
            }
            else if (konserAlani.ToString() == "MasaSari")
            {
                muzikGrubuResimleri[2].SetActive(true);
            }
            else if (konserAlani.ToString() == "MasaYesil")
            {
                muzikGrubuResimleri[3].SetActive(true);
            }
        }
      /*  else if (bolumTuru.ToString() == "Davetliler")
        {
            if (davetliler.ToString() == "SandalyeKirmizi")
            {
                davetlilerResimleri[0].SetActive(true);
            }
            else if (davetliler.ToString() == "SandalyeMavi")
            {
                davetlilerResimleri[1].SetActive(true);
            }
            else if (davetliler.ToString() == "MasaSari")
            {
                davetlilerResimleri[2].SetActive(true);
            }
            else if (davetliler.ToString() == "MasaYesil")
            {
                davetlilerResimleri[3].SetActive(true);
            }
        }*/

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
        if (bolumTuru.ToString() == "Bar")
        {
            for (int i = 0; i < barResimleri.Length; i++)
            {
                barResimleri[i].SetActive(false);
            }
        }
        else if(bolumTuru.ToString() == "MuzikGurubu")
        {
           
            for (int i = 0; i < muzikGrubuResimleri.Length; i++)
            {
                muzikGrubuResimleri[i].SetActive(false);
            }
        }
        else if (bolumTuru.ToString() == "Davetliler")
        {
            for (int i = 0; i < davetlilerResimleri.Length; i++)
            {
                davetlilerResimleri[i].SetActive(false);
            }
        }
    }

    IEnumerator meyveCikarmaAyari()
    {
        for (int i = 0; i < 1; i++)
        {
            MeyveCikar();
            yield return beklemeSuresi1;
        }
    }

    //
    private void MeyveCikar()
    {
        if(bolumTuru.ToString() == "Bar")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(bolumTuru.ToString(), bar.ToString());
        }
        else if (bolumTuru.ToString() == "KonserAlani")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(bolumTuru.ToString(), konserAlani.ToString());
        }
        else if (bolumTuru.ToString() == "Davetliler")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(bolumTuru.ToString(), konserAlani.ToString());
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
