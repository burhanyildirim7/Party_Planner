using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_KonserAlani : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] obje1Konumlari;
    [SerializeField] private Transform[] obje2Konumlari;
    [SerializeField] private Transform[] obje3Konumlari;
    [SerializeField] private Transform[] obje4Konumlari;
    [SerializeField] private Transform[] obje5Konumlari;
    [SerializeField] private Transform[] obje1Tek_Konumlari;
    [SerializeField] private Transform[] obje2Tek_Konumlari;

    [Header("CokluCikacakObjeler›cinKonum")]
    [SerializeField] GameObject[] obje1CokluKonum;
    [SerializeField] GameObject[] obje2CokluKonum;
    [SerializeField] GameObject[] obje3CokluKonum;
    [SerializeField] GameObject[] obje4CokluKonum;
    [SerializeField] GameObject[] obje5CokluKonum;


    [Header("SiraSayilari")]
    private int obje1Sirasi = 0;
    private int obje2Sirasi = 0;
    private int obje3Sirasi = 0;
    private int obje4Sirasi = 0;
    private int obje5Sirasi = 0;
    private int obje1_TekSirasi = 0;

    [Header("OlusacakObjeler")]
    [SerializeField] GameObject[] obje1;
    [SerializeField] GameObject[] obje2;
    [SerializeField] GameObject[] obje3;
    [SerializeField] GameObject[] obje4;
    [SerializeField] GameObject[] obje5;
    [SerializeField] GameObject[] obje1_Tek;
    [SerializeField] GameObject[] obje2_Tek;
    [SerializeField] GameObject[] obje3_Tek;
    [SerializeField] GameObject[] obje4_Tek;
    [SerializeField] GameObject[] obje5_Tek;


    private BinaOzellikleri binaOzellikleri;

    List<GameObject> olusanEsyalar = new List<GameObject>();

    void Start()
    {
        binaOzellikleri = GameObject.FindWithTag("BuildingController").GetComponent<BinaOzellikleri>();
    }

    public void EsyaCikarBar(GameObject esya)
    {
        esya.gameObject.SetActive(false);
        binaOzellikleri.Bolum2KayitEt("Bolum2", esya.gameObject.name);
        ObjeyiYerlestir(esya.gameObject.name);
    }


    public void Sifirla()
    {
        for (int i = 0; i < olusanEsyalar.Count; i++)
        {
            Destroy(olusanEsyalar[i]);
        }
        olusanEsyalar.Clear();


        obje1Sirasi = 0;
        obje2Sirasi = 0;
        obje3Sirasi = 0;
        obje4Sirasi = 0;
        obje5Sirasi = 0;
        obje1_TekSirasi = 0;
    }


    public void ObjeyiYerlestir(string isim)
    {
        Obje1Yerlestir(isim);
        Obje2Yerlestir(isim);
        Obje3Yerlestir(isim);
        Obje4Yerlestir(isim);
        Obje5Yerlestir(isim);
        Obje1TekYerlestir(isim);
        Obje2TekYerlestir(isim);
        Obje3TekYerlestir(isim);
        Obje4TekYerlestir(isim);
    }






    private void Obje1Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje1Iyi(Clone)")
        {
            obje = obje1[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje1Kotu(Clone)")
        {
            obje = obje1[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje2Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje2Iyi(Clone)")
        {
            obje = obje2[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje2Kotu(Clone)")
        {
            obje = obje2[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje3Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje3Iyi(Clone)")
        {
            obje = obje3[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje3Kotu(Clone)")
        {
            obje = obje3[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje4Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje4Iyi(Clone)")
        {
            if (obje4Sirasi == 0)
            {
                obje = obje4[0];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }
            else if (obje4Sirasi == 1)
            {
                obje = obje4[2];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);
            }

            SayiArtir(obje4Sirasi);
        }
        else if (isim == "Obje4Kotu(Clone)")
        {
            if (obje4Sirasi == 0)
            {
                obje = obje4[1];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }
            else if (obje4Sirasi == 1)
            {
                obje = obje4[3];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }

            SayiArtir(obje4Sirasi);
        }
    }

    private void Obje5Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje5Iyi(Clone)")
        {
            obje = obje5[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje5Kotu(Clone)")
        {
            obje = obje5[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje1TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje1TekIyi(Clone)")
        {
            if (obje1_TekSirasi == 0)
            {
                obje = obje1_Tek[0];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }
            else if(obje1_TekSirasi == 1)
            {
                obje = obje1_Tek[2];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }

            SayiArtir(obje1_TekSirasi);
        }
        else if (isim == "Obje1TekKotu(Clone)")
        {
            if (obje1_TekSirasi == 0)
            {
                obje = obje1_Tek[1];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }
            else if (obje1_TekSirasi == 1)
            {
                obje = obje1_Tek[3];
                obje.SetActive(true);
                olusanEsyalar.Add(obje);

            }

            SayiArtir(obje1_TekSirasi);
        }
    }

    private void Obje2TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje2TekIyi(Clone)")
        {
            obje = obje2_Tek[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje2TekKotu(Clone)")
        {
            obje = obje2_Tek[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje3TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje3TekIyi(Clone)")
        {
            obje = obje3_Tek[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);

        }
        else if (isim == "Obje3TekKotu(Clone)")
        {
            obje = obje3_Tek[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void Obje4TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje4TekIyi(Clone)")
        {
            obje = obje4_Tek[0];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
        else if (isim == "Obje4TekKotu(Clone)")
        {
            obje = obje4_Tek[1];
            obje.SetActive(true);
            olusanEsyalar.Add(obje);
        }
    }

    private void SayiArtir(int sayi)
    {
        sayi++;

        if (sayi >= 4)
        {
            sayi = 0;
        }
    }
}
