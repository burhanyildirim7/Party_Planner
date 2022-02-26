using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabayaDoldurucu : MonoBehaviour
{
   
    //Resimler icin gereklidir
    [Header("Doldurulacaklar")]
    [SerializeField] GameObject[] punch_Objeler;
    [SerializeField] GameObject[] punch_Objeler_Tek;
    [SerializeField] GameObject[] konserAlani_Objeler;
    [SerializeField] GameObject[] konserAlani_Objeler_Tek;
    [SerializeField] GameObject[] davetli_Objeler;
    [SerializeField] GameObject[] davetli_Objeler_Tek;


    [Header("ArabaIcin")]
    GameObject karakter;
    GameObject player;
    [SerializeField] GameObject araba;
    private int arabaSetSayisi = 0;   //Arabalarýn 2 veya daha fazla sekilde arka arkaya olmasi durumunda ise yarar
    private bool arabaSayisiTekMi;    //Araba sayisinin tek olmasi durumunda arabanin tam ortada diger durumda ise biraz yan tarafta olmasini saglar

    [Header("YerlestirmeIcinGerekli")]
    int esyaSayisi = 0;
    [SerializeField] private int arabaKapasitesi;
    string bolumIsmi;

    [Header("BolumSonuIcinKonumlar")]
    private GameObject hedefEsya = null;            //Gidilecek hedefi belirler
    private GameObject punchAlani;
    private GameObject konserAlani;
    private GameObject davetliAlani;

    [Header("Listeler")]
    List<GameObject> tumEsyalar = new List<GameObject>();
    List<GameObject> tumInsanlar = new List<GameObject>();
    List<GameObject> tumArabalar = new List<GameObject>();

    [Header("Efektler")]
    [SerializeField] ParticleSystem arabaOlusmaEfekt;
    [SerializeField] ParticleSystem iyiKapiEfekt;
    [SerializeField] ParticleSystem kotuKapiEfekt;

    [Header("ScoreIcin")]
    UIController uIController;
    [SerializeField] int score;


    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.2f);  //Meyvelerin firlatili ile ilgilidir


    public void TekrarBaslat()   //Level controllerden erisiliyor
    {
        uIController = GameObject.FindWithTag("UIController").GetComponent<UIController>();


        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(tumArabalar[i]);
        }
        tumEsyalar.Clear();
        tumArabalar.Clear();
        tumInsanlar.Clear();
        arabaSetSayisi = 0;
        esyaSayisi = 0;

        karakter = GameObject.FindWithTag("KarakterPaketi");
        player = GameObject.FindWithTag("Player");
        bolumIsmi = LevelController.bolumunIsmi;


        punchAlani = GameObject.FindWithTag("Punch");
        konserAlani = GameObject.FindWithTag("KonserAlani");
        davetliAlani = GameObject.FindWithTag("DavetliAlani");

        ArabaOlustur();
    }

    //Esyalarin arabaya yereleþtirilmesi ile ilgilidir
    public void EsyaYerlestirmeAyarlayici(string esyaIsmi, string esyaLayeri)
    {
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
        if (bolumIsmi == "Bolum1")
        {
            PunchEsyaCikar(esyaIsmi, esyaLayeri);
        }
        else if (bolumIsmi == "Bolum2")
        {
            KonserAlaniEsyaCikar(esyaIsmi, esyaLayeri);
        }
        else if (bolumIsmi == "Bolum3")
        {
            DavetliAlaniEsyaCikar(esyaIsmi, esyaLayeri);
        }
    }

    private void PunchEsyaCikar(string esyaIsmi, string esyaLayeri)
    {
        if (esyaIsmi == "Iobje1")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[0]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[2]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[4]);
            }
        }
        else if (esyaIsmi == "Kobje1")
        {
            KotuKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[1]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[3]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[5]);
            }
        }
        else if (esyaIsmi == "Iobje2")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[6]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[8]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[10]);
            }
        }
        else if (esyaIsmi == "Kobje2")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[7]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[9]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[11]);
            }
        }
        else if (esyaIsmi == "Iobje3")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[12]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[14]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[16]);
            }
        }
        else if (esyaIsmi == "Kobje3")
        {
            KotuKapiEfektOynat();

            if (esyaLayeri == "6")
            {
                esyaYerlestir(punch_Objeler[13]);
            }
            else if (esyaLayeri == "7")
            {
                esyaYerlestir(punch_Objeler[15]);
            }
            else if (esyaLayeri == "8")
            {
                esyaYerlestir(punch_Objeler[17]);
            }
        }
        else if (esyaIsmi == "Iobje4")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(punch_Objeler[18]);
        }
        else if (esyaIsmi == "Kobje4")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(punch_Objeler[19]);
        }
        else if (esyaIsmi == "Iobje5")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(punch_Objeler[20]);
        }
        else if (esyaIsmi == "Kobje5")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(punch_Objeler[21]);
        }


        hedefEsya = punchAlani;
    }

    private void KonserAlaniEsyaCikar(string esyaIsmi, string esyaLayeri)
    {
        if (esyaIsmi == "Iobje1")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[0]);
        }
        else if (esyaIsmi == "Kobje1")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[1]);
        }
        else if (esyaIsmi == "Iobje2")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[2]);
        }
        else if (esyaIsmi == "Kobje2")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[3]);
        }
        else if (esyaIsmi == "Iobje3")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[4]);
        }
        else if (esyaIsmi == "Kobje3")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[5]);
        }
        else if (esyaIsmi == "Iobje4")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[6]);
        }
        else if (esyaIsmi == "Kobje4")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[7]);
        }
        else if (esyaIsmi == "Iobje5")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[8]);
        }
        else if (esyaIsmi == "Kobje5")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler[9]);
        }


        if (esyaIsmi == "Iobje1Tek")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler_Tek[0]);
        }
        else if (esyaIsmi == "Kobje1Tek")
        {
            KotuKapiEfektOynat();
            esyaYerlestir(konserAlani_Objeler_Tek[1]);
        }
        if (esyaIsmi == "Iobje2Tek")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            //insan yerlestir
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[2]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[4]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[6]);
            }
        }
        else if (esyaIsmi == "Kobje2Tek")
        {
            KotuKapiEfektOynat();
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[3]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[5]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(konserAlani_Objeler_Tek[7]);
            }
        }
        hedefEsya = konserAlani;
    }

    private void DavetliAlaniEsyaCikar(string esyaIsmi,  string esyaLayeri)
    {
        if (esyaIsmi == "Iobje1") 
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            InsanYerlesitir(davetli_Objeler[0]);
        }
        else if (esyaIsmi == "Kobje1")
        {
            KotuKapiEfektOynat();
            InsanYerlesitir(davetli_Objeler[1]);
        }
        else if (esyaIsmi == "Iobje2")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            InsanYerlesitir(davetli_Objeler[2]);
        }
        else if (esyaIsmi == "Kobje2")
        {
            KotuKapiEfektOynat();
            InsanYerlesitir(davetli_Objeler[3]);
        }
        else if (esyaIsmi == "Iobje3") //Esya
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[4]);
        }
        else if (esyaIsmi == "Kobje3")//Esya
        {
            KotuKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[5]);
        }
        else if (esyaIsmi == "Iobje4")//Esya
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[6]);
        }
        else if (esyaIsmi == "Kobje4")//Esya
        {
            KotuKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[7]);
        }
        else if (esyaIsmi == "Iobje5")//Esya
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[8]);
        }
        else if (esyaIsmi == "Kobje5") //Esya
        {
            KotuKapiEfektOynat();
            esyaYerlestir(davetli_Objeler[9]);
        }


        if (esyaIsmi == "Iobje1Tek")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(davetli_Objeler_Tek[0]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(davetli_Objeler_Tek[2]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(davetli_Objeler_Tek[4]);
            }
        }
        else if (esyaIsmi == "Kobje1Tek")
        {
            KotuKapiEfektOynat();
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(davetli_Objeler_Tek[1]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(davetli_Objeler_Tek[3]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(davetli_Objeler_Tek[5]);
            }
        }
        if (esyaIsmi == "Iobje2Tek")
        {
            uIController.ScoreArtir(score);
            IyiKapiEfektOynat();
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(davetli_Objeler_Tek[6]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(davetli_Objeler_Tek[8]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(davetli_Objeler_Tek[10]);
            }
        }
        else if (esyaIsmi == "Kobje2Tek")
        {
            KotuKapiEfektOynat();
            if (esyaLayeri == "6")
            {
                InsanYerlesitir(davetli_Objeler_Tek[7]);
            }
            else if (esyaLayeri == "7")
            {
                InsanYerlesitir(davetli_Objeler_Tek[9]);
            }
            else if (esyaLayeri == "8")
            {
                InsanYerlesitir(davetli_Objeler_Tek[11]);
            }
        }

        hedefEsya = davetliAlani;
    }

    private void IyiKapiEfektOynat()
    {
        iyiKapiEfekt.transform.position = player.transform.position + Vector3.forward * 5 + Vector3.up * 2;
        iyiKapiEfekt.Play();
    }

    private void KotuKapiEfektOynat()
    {
        kotuKapiEfekt.transform.position = player.transform.position + Vector3.forward * 5 + Vector3.up * 2;
        kotuKapiEfekt.Play();
    }


    //Esyalarin yerlestirilmesi icin gereklidir
    //Araba olusturma kismi burasidir
    void esyaYerlestir(GameObject esya)
    {
        GameObject gelenEsya = Instantiate(esya, tumArabalar[tumArabalar.Count - 1].transform.position + Vector3.up * .5f + Vector3.right * Random.Range(-.1f, .1f), Quaternion.identity);
        gelenEsya.transform.parent = tumArabalar[tumArabalar.Count - 1].transform;
        tumEsyalar.Add(gelenEsya);

        esyaSayisi++;
        if (esyaSayisi >= arabaKapasitesi)
        {
            esyaSayisi = 0;

            ArabaOlustur();
        }
    }

    private void ArabaOlustur()
    {
        GameObject yeniAraba = Instantiate(araba, karakter.transform.position - Vector3.forward * 5, Quaternion.identity);
        yeniAraba.transform.parent = transform;
        tumArabalar.Add(yeniAraba);

        arabaOlusmaEfekt.transform.position = yeniAraba.transform.position + Vector3.forward * .5f;
        arabaOlusmaEfekt.Play();

        ArabayaHedefBelirle();

    }

    private void ArabayaHedefBelirle()  //Buraya her seferinde gelebiliyor
    {
        if (tumArabalar.Count % 2 == 0)
        {
            arabaSayisiTekMi = false;
        }
        else if (tumArabalar.Count % 2 == 1)
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
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.3f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * 2 * (.3f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * 2 * (.6f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.1f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.9f + arabaSetSayisi * .09f));
                    arabaSetSayisi++;
                }
            }
        }
        else if (!arabaSayisiTekMi)           //Araba sayisinin cift olmasi durumu
        {
            for (int i = arabaSetSayisi * 6; i < tumArabalar.Count; i++)
            {
                if (i % 6 == 0)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) + Vector3.right * 2 * (.15f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 1)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.6f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.15f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 2)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) + Vector3.right * 2 * (.45f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 3)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.4f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.45f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 4)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) + Vector3.right * 2 * (.9f + arabaSetSayisi * .09f));
                }
                else if (i % 6 == 5)
                {
                    tumArabalar[i].GetComponent<Arabalar>().HedefDegistir(Vector3.forward * (.2f + arabaSetSayisi * .75f) - Vector3.right * 2 * (.9f + arabaSetSayisi * .09f));
                    arabaSetSayisi++;
                }
            }
        }
    }



    //Insanlarin olusturulmasi ile ilgilidir
    private void InsanYerlesitir(GameObject insan)
    {
        GameObject gelenInsan = Instantiate(insan, GameObject.FindWithTag("Player").transform.position - Vector3.forward * 8, Quaternion.identity);
        tumInsanlar.Add(gelenInsan);
    }





    //Oyun sonu icin gereklidir
    //Meyvelerin yukari firlatilmasini duzenler
    public void EsyaOyunSonuAyarlayici()
    {
        StartCoroutine(EsyalariGonder());
    }

    public IEnumerator EsyalariGonder()
    {
        int firlatilanEsyaSayisi = 0;
        int firlatilanInsanSayisi = 0;
        int yokEdilenArabaSayisi = 0;

        yield return new WaitForSeconds(1);

        while (firlatilanEsyaSayisi < tumEsyalar.Count)
        {
            tumEsyalar[(tumEsyalar.Count - 1) - firlatilanEsyaSayisi].GetComponent<EsyaGonder>().EsyayiGonder(hedefEsya);
            arabaOlusmaEfekt.transform.position = tumEsyalar[(tumEsyalar.Count - 1) - firlatilanEsyaSayisi].transform.position;
            arabaOlusmaEfekt.Play();

            if (((tumEsyalar.Count - 1) - firlatilanEsyaSayisi) % 3 == 0)
            {
                if (((tumArabalar.Count - 1) - yokEdilenArabaSayisi) >= 0)
                {
                    arabaOlusmaEfekt.transform.position = tumArabalar[(tumArabalar.Count - 1) - yokEdilenArabaSayisi].transform.position;
                }

                arabaOlusmaEfekt.Play();
                if (((tumArabalar.Count - 1) - yokEdilenArabaSayisi) >= 0)
                {
                    tumArabalar[(tumArabalar.Count - 1) - yokEdilenArabaSayisi].transform.GetChild(0).transform.gameObject.SetActive(false);
                }
                yokEdilenArabaSayisi++;
            }
            firlatilanEsyaSayisi++;

            yield return beklemeSuresi;
        }


        while (firlatilanInsanSayisi < tumInsanlar.Count)
        {
            tumInsanlar[(tumInsanlar.Count - 1) - firlatilanInsanSayisi].GetComponent<Insan>().InsaniGonder(hedefEsya);
            arabaOlusmaEfekt.transform.position = tumInsanlar[(tumInsanlar.Count - 1) - firlatilanInsanSayisi].transform.position;
            arabaOlusmaEfekt.Play();

            firlatilanInsanSayisi++;

            yield return beklemeSuresi;
        }
    }
}
