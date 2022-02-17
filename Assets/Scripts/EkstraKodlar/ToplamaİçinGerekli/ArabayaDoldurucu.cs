using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabayaDoldurucu : MonoBehaviour
{
    [Header("Doldurulacaklar")]
    [SerializeField] GameObject[] meyveler;
    [SerializeField] GameObject[] esyalar;


    [Header("ArabaIcin")]
    GameObject karakter;
    [SerializeField] GameObject araba;
    private int arabaSetSayisi = 0;   //Arabalarýn 2 veya daha fazla sekilde arka arkaya olmasi durumunda ise yarar
    private bool arabaSayisiTekMi;    //Araba sayisinin tek olmasi durumunda arabanin tam ortada diger durumda ise biraz yan tarafta olmasini saglar

    [Header("YerlestirmeIcinGerekli")]
    int meyveSayisi = 0;

    [Header("BolumSonuIcinKonumlar")]
    Transform restaurant;

    [Header("Listeler")]
    List<GameObject> tumMeyveler = new List<GameObject>();
    List<GameObject> tumArabalar = new List<GameObject>();

    [Header("Efektler")]
    [SerializeField] ParticleSystem arabaOlusmaEfekt;

    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.06f);  //Meyvelerin firlatili ile ilgilidir

    void Start()
    {
        tumArabalar.Add(GameObject.FindWithTag("Araba"));
        karakter = GameObject.FindWithTag("Player");
        restaurant = GameObject.FindWithTag("Restaurant").transform;
    }

    //Hangi meyve olacagi ve nereye konulacagi icin gereklidir
    public void MeyveYerlestirmeAyarlayici(string bolumIsmi,string meyveIsmi)
    {
        if(bolumIsmi == "Pasta")
        {
            if (meyveIsmi == "Kirmizi")
            {
                MeyveYerlestir(meyveler[0]);
            }
            else if (meyveIsmi == "Mavi")
            {
                MeyveYerlestir(meyveler[1]);
            }
            else if (meyveIsmi == "Sari")
            {
                MeyveYerlestir(meyveler[2]);
            }
            else if (meyveIsmi == "Yesil")
            {
                MeyveYerlestir(meyveler[3]);
            }
        }
        else if (bolumIsmi == "Bar")
        {
            if (meyveIsmi == "SandalyeKirmizi")
            {
                MeyveYerlestir(esyalar[0]);
            }
            else if (meyveIsmi == "SandalyeMavi")
            {
                MeyveYerlestir(esyalar[1]);
            }
            else if (meyveIsmi == "MasaSari")
            {
                MeyveYerlestir(esyalar[2]);
            }
            else if (meyveIsmi == "MasaYesil")
            {
                MeyveYerlestir(esyalar[3]);
            }
        }
    }


    //Meyvenin yerlestirilmesi icin gereklidir
    //Araba olusturma kismi burasidir
    void MeyveYerlestir(GameObject meyve)
    {
        GameObject gelenMeyve = Instantiate(meyve, tumArabalar[tumArabalar.Count - 1].transform.position + Vector3.up * .3f + Vector3.right * Random.Range(-.1f, .1f), Quaternion.identity);
        gelenMeyve.transform.parent = tumArabalar[tumArabalar.Count - 1].transform;
        tumMeyveler.Add(gelenMeyve);


        meyveSayisi++;
        if (meyveSayisi >= 3)
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

        while (firlatilanMeyveSayisi < tumMeyveler.Count)
        {
            tumMeyveler[(tumMeyveler.Count - 1) - firlatilanMeyveSayisi].GetComponent<Meyveler>().OyunSonuMeyveKontrol(restaurant);

           if(((tumMeyveler.Count - 1) - firlatilanMeyveSayisi) % 3 == 0)
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
