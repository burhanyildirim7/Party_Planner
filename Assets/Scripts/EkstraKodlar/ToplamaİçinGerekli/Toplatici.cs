using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toplatici : MonoBehaviour
{
    [Header("FiyatlaIlgiliDuzenleme")]
    [SerializeField] int fiyat;
    [SerializeField] Text fiyatYazdirici;


    [Header("KaraktereErisim")]
    GameObject player;
    KarakterPara karakterPara;

    [Header("ResimlerÝcinGerekli")]
    private string bolumIsmi;
    [SerializeField] GameObject[] barResimleri;
    [SerializeField] GameObject[] t_barResimleri;
    [SerializeField] GameObject[] konserAlaniResimleri;
    [SerializeField] GameObject[] t_konserAlaniResimleri;
    [SerializeField] GameObject[] davetlilerResimleri;
    [SerializeField] GameObject[] t_davetlilerResimleri;

    [Header("MeyveninArabayaKoyulmasi")]
    ArabayaDoldurucu arabayadoldurucu;

    [Header("KapiRenkleriIcin")]
    [SerializeField] private Material[] renk;
    Renderer renderer;
    MeshRenderer mesh;

    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.25f); //Meyveyi yerlestirme suresi
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(.45f); //Kapi rengini guncelleme suresi 

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<Renderer>();
        karakterPara = GameObject.FindWithTag("Player").GetComponent<KarakterPara>();
        arabayadoldurucu = GameObject.FindWithTag("Arabalar").GetComponent<ArabayaDoldurucu>();
        bolumIsmi = GameObject.FindWithTag("GameController").GetComponent<GameController>().bolumTuru.ToString();


        fiyatYazdirici.text = fiyat.ToString() + " $";

        mesh = GetComponent<MeshRenderer>();

        ResimiBelirleKapi();
        StartCoroutine(KapiRenginiGuncelle());
    }

    //Kapida olusacak olan resimi belirler
    private void ResimiBelirleKapi()
    {
        if(bolumIsmi == "Bar")
        {
            BarResimBelirle();
        }
        else if (bolumIsmi == "KonserAlani")
        {
            KonserAlaniResimBelirle();
        }
        else if (bolumIsmi == "Davetliler")
        {
            DavetliResimBelirle();
        }
    }

    private void BarResimBelirle()
    {
        if(gameObject.tag == "Kobje1")
        {
            barResimleri[0].SetActive(true);
        }
        else if(gameObject.tag == "Iobje1")
        {
            barResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2")
        {
            barResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            barResimleri[3].SetActive(true);
        }
        if (gameObject.tag == "Kobje3")
        {
            barResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            barResimleri[5].SetActive(true);
        }


        if (gameObject.tag == "Kobje1Tek")
        {
            t_barResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Iobje1Tek")
        {
            t_barResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2Tek")
        {
            t_barResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2Tek")
        {
            t_barResimleri[3].SetActive(true);
        }
    }

    private void KonserAlaniResimBelirle()
    {
        if (gameObject.tag == "Kobje1")
        {
            konserAlaniResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Iobje1")
        {
            konserAlaniResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2")
        {
            konserAlaniResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            konserAlaniResimleri[3].SetActive(true);
        }
        if (gameObject.tag == "Kobje3")
        {
            konserAlaniResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            konserAlaniResimleri[5].SetActive(true);
        }


        if (gameObject.tag == "Kobje1Tek")
        {
            t_konserAlaniResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Iobje1Tek")
        {
            t_konserAlaniResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2Tek")
        {
            t_konserAlaniResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2Tek")
        {
            t_konserAlaniResimleri[3].SetActive(true);
        }
    }

    private void DavetliResimBelirle()
    {
        if (gameObject.tag == "Kobje1")
        {
            davetlilerResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Iobje1")
        {
            davetlilerResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2")
        {
            davetlilerResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            davetlilerResimleri[3].SetActive(true);
        }
        if (gameObject.tag == "Kobje3")
        {
            davetlilerResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            davetlilerResimleri[5].SetActive(true);
        }


        if (gameObject.tag == "Kobje1Tek")
        {
            t_davetlilerResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Iobje1Tek")
        {
            t_davetlilerResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Kobje2Tek")
        {
            t_davetlilerResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2Tek")
        {
            t_davetlilerResimleri[3].SetActive(true);
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
            StartCoroutine(esyaCikarmaAyari());
            DigerKapidanMeyveAlmayiPasiflestir();
        }
    }

    IEnumerator esyaCikarmaAyari()
    {
        for (int i = 0; i < 1; i++)
        {
            esyaCikar();
            yield return beklemeSuresi1;
        }
    }

    private void esyaCikar()
    {
        if(bolumIsmi == "Bar")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(gameObject.tag);
        }
        else if (bolumIsmi == "KonserAlani")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(gameObject.tag);
        }
        else if (bolumIsmi == "Davetliler")
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(gameObject.tag);
        }
    }









    //kapiya temastan sonra resimi pasiflestirir
    private void ResimPasiflestir()
    {
        fiyatYazdirici.text = "";
        mesh.enabled = false;

        if (bolumIsmi == "Bar")
        {
            for (int i = 0; i < barResimleri.Length; i++)
            {
                barResimleri[i].SetActive(false);
            }
        }
        else if (bolumIsmi == "KonserAlani")
        {
            for (int i = 0; i < konserAlaniResimleri.Length; i++)
            {
                konserAlaniResimleri[i].SetActive(false);
            }
        }
        else if (bolumIsmi == "Davetliler")
        {
            for (int i = 0; i < davetlilerResimleri.Length; i++)
            {
                davetlilerResimleri[i].SetActive(false);
            }
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
