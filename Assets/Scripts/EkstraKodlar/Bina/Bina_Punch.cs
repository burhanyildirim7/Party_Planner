using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Punch : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] obje1Konumlari;


    [Header("Efektler")]
    [SerializeField] ParticleSystem bardakOlusmaEfekt;
    [SerializeField] ParticleSystem sandalyeEfekt;




    [Header("SiraSayilari")]
    private int obje1Sirasi = 0;
    private int obje2Sirasi = 0;
    private int obje3Sirasi = 0;
    private int obje4Sirasi = 0;
    private int obje5Sirasi = 0;
    private int obje1_TekSirasi = 0;
    private int obje2_TekSirasi = 0;

    [Header("OlusacakObjeler")]
    [SerializeField] GameObject[] obje1;
    [SerializeField] GameObject[] obje2;
    [SerializeField] GameObject[] obje3;
    [SerializeField] GameObject[] obje4;
    [SerializeField] GameObject[] obje5;
    [SerializeField] GameObject[] obje1_Tek;
    [SerializeField] GameObject[] obje2_Tek;


    

    private BinaOzellikleri binaOzellikleri;

    List<GameObject> olusanEsyalar = new List<GameObject>();


    void Start()
    {
        binaOzellikleri = GameObject.FindWithTag("BuildingController").GetComponent<BinaOzellikleri>();
    }

    public void EsyaCikarBar(GameObject esya)
    {
        esya.gameObject.SetActive(false);
        binaOzellikleri.Bolum1KayitEt("Bolum1", esya.gameObject.name);
        ObjeyiYerlestir(esya.gameObject.name);
    }

    public void Sifirla()
    {
        for (int i = 0; i < olusanEsyalar.Count; i++)
        {
            olusanEsyalar[i].SetActive(false);
        }
        olusanEsyalar.Clear();


        obje1Sirasi = 0;
        obje2Sirasi = 0;
        obje3Sirasi = 0;
        obje4Sirasi = 0;
        obje5Sirasi = 0;
        obje1_TekSirasi = 0;
        obje2_TekSirasi = 0;
    }


    public void ObjeyiYerlestir(string isim) // Disardan buraya erisilerek insa sistemi yapilir
    {
        Obje1Yerlestir(isim);
        Obje2Yerlestir(isim);
        Obje3Yerlestir(isim);
        Obje4Yerlestir(isim);
        Obje5Yerlestir(isim);
    }






    private void Obje1Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje1Iyi(Clone)")
        {
            obje = Instantiate(obje1[0], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);     
        }
        else if (isim == "Obje1Kotu(Clone)")
        {
            obje = Instantiate(obje1[1], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje2Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje2Iyi(Clone)")
        {
            obje = Instantiate(obje2[0], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje2Kotu(Clone)")
        {
            obje = Instantiate(obje2[1], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje3Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje3Iyi(Clone)")
        {
            obje = Instantiate(obje3[0], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje3Kotu(Clone)")
        {
            obje = Instantiate(obje3[1], obje1Konumlari[0].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje4Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje4Iyi(Clone)")
        {
            obje = obje4[0];
            obje.SetActive(true);
            bardakOlusmaEfekt.Play();
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje4Kotu(Clone)")
        {
            obje = obje4[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje5Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje5Iyi(Clone)")
        {
            obje = obje5[0];
            obje.SetActive(true);
            sandalyeEfekt.Play();
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje5Kotu(Clone)")
        {
            obje = obje5[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }



    private void SayiArtir(int sayi)
    {
        sayi++;

        if(sayi  >= 4)
        {
            sayi = 0;
        }
    }
}
