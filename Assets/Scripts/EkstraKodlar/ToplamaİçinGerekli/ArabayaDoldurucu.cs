using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabayaDoldurucu : MonoBehaviour
{

    //Resimler icin gereklidir
    [Header("Doldurulacaklar")]  
    [SerializeField] GameObject[] bar_Objeler;
    [SerializeField] GameObject[] muzikGrubu_Objeler;
    [SerializeField] GameObject[] davetli_Objeler;


    [Header("ArabaIcin")]
    GameObject karakter;
    [SerializeField] GameObject araba;
    private int arabaSetSayisi = 0;   //Arabalarýn 2 veya daha fazla sekilde arka arkaya olmasi durumunda ise yarar
    private bool arabaSayisiTekMi;    //Araba sayisinin tek olmasi durumunda arabanin tam ortada diger durumda ise biraz yan tarafta olmasini saglar

    [Header("YerlestirmeIcinGerekli")]
    int meyveSayisi = 0;
    [SerializeField] private int arabaKapasitesi;
    string bolumIsmi;

    [Header("BolumSonuIcinKonumlar")]
    private GameObject hedefEsya = null;            //Gidilecek hedefi belirler
    private GameObject bar;
    private GameObject konserAlani;

    [Header("Listeler")]
    List<GameObject> tumEsyalar = new List<GameObject>();
    List<GameObject> tumArabalar = new List<GameObject>();

    [Header("Efektler")]
    [SerializeField] ParticleSystem arabaOlusmaEfekt;

    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.06f);  //Meyvelerin firlatili ile ilgilidir

    void Start()
    {
        tumArabalar.Add(GameObject.FindWithTag("Araba"));
        karakter = GameObject.FindWithTag("Player");
        bolumIsmi = GameObject.FindWithTag("GameController").GetComponent<GameController>().bolumTuru.ToString();


        bar = GameObject.FindWithTag("Bar");
        konserAlani = GameObject.FindWithTag("KonserAlani");
    }

    //Hangi meyve olacagi ve nereye konulacagi icin gereklidir
    public void MeyveYerlestirmeAyarlayici(string esyaIsmi)
    {
        if (bolumIsmi == "Bar")
        {
            BarEsyaCikar(esyaIsmi);
        }
        else if (bolumIsmi == "KonserAlani")
        {
            KonserAlaniEsyaCikar(esyaIsmi);
        }
        else if (bolumIsmi == "Davetliler")
        {
            
        }
    }

    private void BarEsyaCikar(string esyaIsmi)
    {
        if (esyaIsmi == "Kobje1")
        {
            MeyveYerlestir(bar_Objeler[0]);
        }
        else if (esyaIsmi == "Iobje1")
        {
            MeyveYerlestir(bar_Objeler[1]);
        }
        else if (esyaIsmi == "Kobje2")
        {
            MeyveYerlestir(bar_Objeler[2]);
        }
        else if (esyaIsmi == "Iobje2")
        {
            MeyveYerlestir(bar_Objeler[3]);
        }
        hedefEsya = bar;
    }

    private void KonserAlaniEsyaCikar(string esyaIsmi)
    {
        if (esyaIsmi == "Kobje1")
        {
            MeyveYerlestir(muzikGrubu_Objeler[0]);
        }
        else if (esyaIsmi == "Iobje1")
        {
            MeyveYerlestir(muzikGrubu_Objeler[1]);
        }
        else if (esyaIsmi == "Kobje2")
        {
            MeyveYerlestir(muzikGrubu_Objeler[2]);
        }
        else if (esyaIsmi == "Iobje2")
        {
            MeyveYerlestir(muzikGrubu_Objeler[3]);
        }
        hedefEsya = konserAlani;
    }

    private void DavetlilerEsyaCikar(string esyaIsmi)
    {
        if (esyaIsmi == "Kobje1")
        {
            MeyveYerlestir(davetli_Objeler[0]);
        }
        else if (esyaIsmi == "Iobje1")
        {
            MeyveYerlestir(davetli_Objeler[1]);
        }
        else if (esyaIsmi == "Kobje2")
        {
            MeyveYerlestir(davetli_Objeler[2]);
        }
        else if (esyaIsmi == "Iobje2")
        {
            MeyveYerlestir(davetli_Objeler[3]);
        }
    }


    //Meyvenin yerlestirilmesi icin gereklidir
    //Araba olusturma kismi burasidir
    void MeyveYerlestir(GameObject meyve)
    {
        GameObject gelenMeyve = Instantiate(meyve, tumArabalar[tumArabalar.Count - 1].transform.position + Vector3.up * .3f + Vector3.right * Random.Range(-.1f, .1f), Quaternion.identity);
        gelenMeyve.transform.parent = tumArabalar[tumArabalar.Count - 1].transform;
        tumEsyalar.Add(gelenMeyve);


        meyveSayisi++;
        if (meyveSayisi >= arabaKapasitesi)
        {
            meyveSayisi = 0;

            ArabaOlustur();
            ArabayaHedefBelirle();
        }
    }

    private void ArabaOlustur()
    {
        GameObject yeniAraba = Instantiate(araba, karakter.transform.position - Vector3.forward * 5, Quaternion.identity);
        yeniAraba.transform.parent = transform;
        tumArabalar.Add(yeniAraba);

        arabaOlusmaEfekt.transform.position = yeniAraba.transform.position + Vector3.forward * .5f;
        arabaOlusmaEfekt.Play();
    }

    private void ArabayaHedefBelirle()  //Buraya her seferinde gelebiliyor
    {
        if(tumArabalar.Count % 2 == 0)
        {
            arabaSayisiTekMi = false;
        }
        else if(tumArabalar.Count % 2 == 1)
        {
            arabaSayisiTekMi = true;
        }

        if (arabaSayisiTekMi)         //Araba sayisinin tek olmasi durumu
        {
            for (int i = arabaSetSayisi * 6; i < tumArabalar.Count; i++)
            {
                if (i % 6 == 0)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f));
                }
                else if (i % 6 == 1)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * (.3f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * (.3f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.1f + arabaSetSayisi * .75f) - Vector3.right * (.9f + arabaSetSayisi * .09f));
                    arabaSetSayisi++;
                }
            }
        }
        else if(!arabaSayisiTekMi)           //Araba sayisinin cift olmasi durumu
        {
            for (int i = arabaSetSayisi * 6; i < tumArabalar.Count; i++)
            {
                if (i % 6 == 0)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) + Vector3.right * (.15f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 1)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) - Vector3.right * (.15f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * (.45f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * (.45f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * (.9f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * (.9f + arabaSetSayisi * .09f));
                    arabaSetSayisi++;
                }

                
            }
        }
    }


    //Oyun sonu icin gereklidir
    //Meyvelerin yukari firlatilmasini duzenler
    public void MeyveOyunSonuAyarlayici()
    {
        StartCoroutine(MeyveleriFirlat());
    }

    public IEnumerator MeyveleriFirlat()
    {
        int firlatilanMeyveSayisi = 0;
        int yokEdilenArabaSayisi = 0;

        while (firlatilanMeyveSayisi < tumEsyalar.Count)
        {
            tumEsyalar[(tumEsyalar.Count - 1) - firlatilanMeyveSayisi].GetComponent<EsyaGonder>().EsyayiGonder(hedefEsya);
            arabaOlusmaEfekt.transform.position = tumEsyalar[(tumEsyalar.Count - 1) - firlatilanMeyveSayisi].transform.position;
            arabaOlusmaEfekt.Play();

            if (((tumEsyalar.Count - 1) - firlatilanMeyveSayisi) % 3 == 0)
           {
                arabaOlusmaEfekt.transform.position = tumArabalar[(tumArabalar.Count - 1) - yokEdilenArabaSayisi].transform.position;
                arabaOlusmaEfekt.Play();

                tumArabalar[(tumArabalar.Count - 1) - yokEdilenArabaSayisi].transform.GetChild(0).transform.gameObject.SetActive(false);
                yokEdilenArabaSayisi++;
            }

            firlatilanMeyveSayisi++;
            yield return beklemeSuresi;
        }
    }


}
