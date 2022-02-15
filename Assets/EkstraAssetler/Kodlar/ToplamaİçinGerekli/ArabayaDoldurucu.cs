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

    [Header("YerlestirmeIcinGerekli")]
    int meyveSayisi = 0;
    int arabaSayisi = 1;

    [Header("BolumSonuIcinKonumlar")]
    Transform restaurant;

    [Header("Listeler")]
    List<GameObject> tumMeyveler = new List<GameObject>();
    List<GameObject> tumArabalar = new List<GameObject>();

    [Header("Efektler")]
    [SerializeField] ParticleSystem arabaOlusmaEfekt;

    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.05f);

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
    void MeyveYerlestir(GameObject meyve)
    {
        GameObject gelenMeyve = Instantiate(meyve, tumArabalar[0].transform.position + Vector3.up * .3f + Vector3.right * Random.Range(-.1f, .1f), Quaternion.identity);
        gelenMeyve.transform.parent = tumArabalar[0].transform;
        tumMeyveler.Add(gelenMeyve);


        meyveSayisi++;
        if (meyveSayisi >= 3)
        {
            meyveSayisi = 0;


            GameObject yeniAraba = Instantiate(araba, karakter.transform.position - Vector3.forward * .5f, Quaternion.identity);
            yeniAraba.transform.parent = transform;
            tumArabalar.Insert(0, yeniAraba);


            arabaOlusmaEfekt.transform.position = yeniAraba.transform.position + Vector3.forward * .5f;
            arabaOlusmaEfekt.Play();


            for (int i = 0; i < tumArabalar.Count; i++)
            {
                if (i != 0)
                {
                    tumArabalar[i].GetComponent<Arabalar>().SiralamaDegistir(tumArabalar[i - 1]);
                }
            }
        }
    }


    //Oyun sonu icin gereklidir
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
