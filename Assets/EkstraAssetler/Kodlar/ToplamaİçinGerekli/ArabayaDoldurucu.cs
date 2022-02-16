using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabayaDoldurucu : MonoBehaviour
{
    [Header("Meyveler")]
    [SerializeField] GameObject kirmizi;
    [SerializeField] GameObject mavi;
    [SerializeField] GameObject sari;
    [SerializeField] GameObject yesil;

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

    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.04f);

    void Start()
    {
        tumArabalar.Add(GameObject.FindWithTag("Araba"));
        karakter = GameObject.FindWithTag("Player");
        restaurant = GameObject.FindWithTag("Restaurant").transform;
    }

    //Hangi meyve olacagi ve nereye konulacagi icin gereklidir
    public void MeyveYerlestirmeAyarlayici(string meyveIsmi)
    {
        if(meyveIsmi == "Kirmizi")
        {
            MeyveYerlestir(kirmizi);
        }
        else if(meyveIsmi == "Mavi")
        {
            MeyveYerlestir(mavi);
        }
        else if (meyveIsmi == "Sari")
        {
            MeyveYerlestir(sari);
        }
        else if (meyveIsmi == "Yesil")
        {
            MeyveYerlestir(yesil);
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            MeyveYerlestir(yesil);
        }
    }

    private void ArabaOlustur()
    {
        GameObject yeniAraba = Instantiate(araba, karakter.transform.position - Vector3.forward * 1 * arabaSetSayisi, Quaternion.identity);
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
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * (.4f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * (.4f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * (.8f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * (.8f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.1f + arabaSetSayisi * .75f) - Vector3.right * (1.2f + arabaSetSayisi * .09f));
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
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) + Vector3.right * (.2f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 1)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) - Vector3.right * (.2f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * (1f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * (1f + arabaSetSayisi * .09f));
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
        while (firlatilanMeyveSayisi < tumMeyveler.Count)
        {
            tumMeyveler[firlatilanMeyveSayisi].GetComponent<Meyveler>().OyunSonuMeyveKontrol(restaurant);

            firlatilanMeyveSayisi++;
            yield return beklemeSuresi;
        }
    }
}
