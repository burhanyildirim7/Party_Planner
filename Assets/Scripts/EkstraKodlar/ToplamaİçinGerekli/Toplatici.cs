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

    [Header("ResimlerİcinGerekli")]
    private string bolumIsmi;
    [SerializeField] GameObject[] punchResimleri;
    [SerializeField] GameObject[] t_punchResimleri;
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
    BoxCollider collider;




    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.25f); //Meyveyi yerlestirme suresi
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(.45f); //Kapi rengini guncelleme suresi 
    WaitForSeconds beklemeSuresi3 = new WaitForSeconds(.1f); //Kapi gecikme suresi

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<Renderer>();
        karakterPara = GameObject.FindWithTag("Player").GetComponent<KarakterPara>();
        arabayadoldurucu = GameObject.FindWithTag("Arabalar").GetComponent<ArabayaDoldurucu>();
        bolumIsmi = LevelController.bolumunIsmi;

        collider = GetComponent<BoxCollider>();


        fiyatYazdirici.text = fiyat.ToString() + " $";

        mesh = GetComponent<MeshRenderer>();

        StartCoroutine(KapiRenginiGuncelle());
        StartCoroutine(ResimiBelirleKapi());
    }

    //Kapida olusacak olan resimi belirler  
    //Level controller de restart level den ulasiliyor
    IEnumerator ResimiBelirleKapi()
    {
        yield return beklemeSuresi3;
        mesh.enabled = true;
        mesh.material = renk[1];




        if (LevelController.bolumunIsmi == "Bolum1")
        {
            PunchAlaniResimBelirle();
        }
        else if (LevelController.bolumunIsmi == "Bolum2")
        {
            KonserAlaniResimBelirle();
        }
        else if (LevelController.bolumunIsmi == "Bolum3")
        {
            DavetliResimBelirle();
        }
    }

    private void PunchAlaniResimBelirle()
    {
        if (gameObject.tag == "Iobje1")
        {
            punchResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Kobje1")
        {
            punchResimleri[1].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            punchResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Kobje2")
        {
            punchResimleri[3].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            punchResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Kobje3")
        {
            punchResimleri[5].SetActive(true);
        }
        else if (gameObject.tag == "Iobje4")
        {
            punchResimleri[6].SetActive(true);
        }
        else if (gameObject.tag == "Kobje4")
        {
            punchResimleri[7].SetActive(true);
        }
        else if (gameObject.tag == "Iobje5")
        {
            punchResimleri[8].SetActive(true);
        }
        else if (gameObject.tag == "Kobje5")
        {
            punchResimleri[9].SetActive(true);
        }


        if (gameObject.tag == "Iobje1Tek")
        {
            t_punchResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Kobje1Tek")
        {
            t_punchResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Iobje2Tek")
        {
            t_punchResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Kobje2Tek")
        {
            t_punchResimleri[3].SetActive(true);
        }
    }

    private void KonserAlaniResimBelirle()
    {
        if (gameObject.tag == "Iobje1")
        {
            konserAlaniResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Kobje1")
        {
            konserAlaniResimleri[1].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            konserAlaniResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Kobje2")
        {
            konserAlaniResimleri[3].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            konserAlaniResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Kobje3")
        {
            konserAlaniResimleri[5].SetActive(true);
        }
        else if (gameObject.tag == "Iobje4")
        {
            konserAlaniResimleri[6].SetActive(true);
        }
        else if (gameObject.tag == "Kobje4")
        {
            konserAlaniResimleri[7].SetActive(true);
        }
        else if (gameObject.tag == "Iobje5")
        {
            konserAlaniResimleri[8].SetActive(true);
        }
        else if (gameObject.tag == "Kobje5")
        {
            konserAlaniResimleri[9].SetActive(true);
        }


        if (gameObject.tag == "Iobje1Tek")
        {
            t_konserAlaniResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Kobje1Tek")
        {
            t_konserAlaniResimleri[1].SetActive(true);
        }
        if (gameObject.tag == "Iobje2Tek")
        {
            if (gameObject.layer == 6)
            {
                t_konserAlaniResimleri[2].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_konserAlaniResimleri[4].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_konserAlaniResimleri[6].SetActive(true);
            }
        }
        else if (gameObject.tag == "Kobje2Tek")
        {
            if (gameObject.layer == 6)
            {
                t_konserAlaniResimleri[3].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_konserAlaniResimleri[5].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_konserAlaniResimleri[7].SetActive(true);
            }
        }
    }

    private void DavetliResimBelirle()
    {
        if (gameObject.tag == "Iobje1")
        {
            davetlilerResimleri[0].SetActive(true);
        }
        else if (gameObject.tag == "Kobje1")
        {
            davetlilerResimleri[1].SetActive(true);
        }
        else if (gameObject.tag == "Iobje2")
        {
            davetlilerResimleri[2].SetActive(true);
        }
        else if (gameObject.tag == "Kobje2")
        {
            davetlilerResimleri[3].SetActive(true);
        }
        else if (gameObject.tag == "Iobje3")
        {
            davetlilerResimleri[4].SetActive(true);
        }
        else if (gameObject.tag == "Kobje3")
        {
            davetlilerResimleri[5].SetActive(true);
        }
        else if (gameObject.tag == "Iobje4")
        {
            davetlilerResimleri[6].SetActive(true);
        }
        else if (gameObject.tag == "Kobje4")
        {
            davetlilerResimleri[7].SetActive(true);
        }
        else if (gameObject.tag == "Iobje5")
        {
            davetlilerResimleri[8].SetActive(true);
        }
        else if (gameObject.tag == "Kobje5")
        {
            davetlilerResimleri[9].SetActive(true);
        }


        if (gameObject.tag == "Iobje1Tek")
        {
            if (gameObject.layer == 6)
            {
                t_davetlilerResimleri[0].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_davetlilerResimleri[2].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_davetlilerResimleri[4].SetActive(true);
            }
        }
        else if (gameObject.tag == "Kobje1Tek")
        {
            if (gameObject.layer == 6)
            {
                t_davetlilerResimleri[1].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_davetlilerResimleri[3].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_davetlilerResimleri[5].SetActive(true);
            }
        }
        if (gameObject.tag == "Iobje2Tek")
        {
            if (gameObject.layer == 6)
            {
                t_davetlilerResimleri[6].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_davetlilerResimleri[8].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_davetlilerResimleri[10].SetActive(true);
            }
        }
        else if (gameObject.tag == "Kobje2Tek")
        {
            if (gameObject.layer == 6)
            {
                t_davetlilerResimleri[7].SetActive(true);
            }
            else if (gameObject.layer == 7)
            {
                t_davetlilerResimleri[9].SetActive(true);
            }
            else if (gameObject.layer == 8)
            {
                t_davetlilerResimleri[11].SetActive(true);
            }
        }
    }




    //Kapinin rengini player in parasina gore günceller
    IEnumerator KapiRenginiGuncelle()
    {
        while ((player.transform.position.z - transform.position.z) <= 10)
        {
            if (GameController.para >= fiyat)
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

            if (GameController.para - fiyat >= 0)
            {
                karakterPara.meyveSatinAl(fiyat);
                collider.enabled = false;

                ResimPasiflestir();
                StartCoroutine(esyaCikarmaAyari());
                DigerKapidanMeyveAlmayiPasiflestir();
            }
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
        if (bolumIsmi == "Bolum1")
        {
            arabayadoldurucu.EsyaYerlestirmeAyarlayici(gameObject.tag, gameObject.layer.ToString());
        }
        else if (bolumIsmi == "Bolum2")
        {
            arabayadoldurucu.EsyaYerlestirmeAyarlayici(gameObject.tag, gameObject.layer.ToString());
        }
        else if (bolumIsmi == "Bolum3")
        {
            arabayadoldurucu.EsyaYerlestirmeAyarlayici(gameObject.tag, gameObject.layer.ToString());
        }
    }









    //kapiya temastan sonra resimi pasiflestirir
    private void ResimPasiflestir()
    {
        fiyatYazdirici.text = "";
        mesh.enabled = false;


        if (bolumIsmi == "Bolum1")
        {
            for (int i = 0; i < punchResimleri.Length; i++)
            {
                punchResimleri[i].SetActive(false);
            }

            for (int i = 0; i < t_punchResimleri.Length; i++)
            {
                t_punchResimleri[i].SetActive(false);
            }
        }
        else if (bolumIsmi == "Bolum2")
        {
            for (int i = 0; i < konserAlaniResimleri.Length; i++)
            {
                konserAlaniResimleri[i].SetActive(false);
            }

            for (int i = 0; i < t_konserAlaniResimleri.Length; i++)
            {
                t_konserAlaniResimleri[i].SetActive(false);
            }
        }
        else if (bolumIsmi == "Bolum3")
        {
            for (int i = 0; i < davetlilerResimleri.Length; i++)
            {
                davetlilerResimleri[i].SetActive(false);
            }

            for (int i = 0; i < t_davetlilerResimleri.Length; i++)
            {
                t_davetlilerResimleri[i].SetActive(false);
            }
        }
    }

    //Iki kapidan ayni anda meyve almasini engeller
    private void DigerKapidanMeyveAlmayiPasiflestir()
    {
        for (int i = 0; i < transform.parent.childCount - 1; i++)
        {
            transform.parent.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
    }
}
