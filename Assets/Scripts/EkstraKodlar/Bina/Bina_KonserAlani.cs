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
        obje2_TekSirasi = 0;
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
    }






    private void Obje1Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje1Iyi(Clone)")
        {
            obje = Instantiate(obje1[0], obje1Konumlari[obje1Sirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            olusanEsyalar.Add(obje);

            obje1Sirasi++;
        }
        else if (isim == "Obje1Kotu(Clone)")
        {
            obje = Instantiate(obje1[1], obje1Konumlari[obje1Sirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            olusanEsyalar.Add(obje);

            obje1Sirasi++;
        }
    }

    private void Obje2Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje2Iyi(Clone)")
        {
            obje = Instantiate(obje2[0], obje2Konumlari[obje2Sirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));
            olusanEsyalar.Add(obje);

            obje2Sirasi++;
        }
        else if (isim == "Obje2Kotu(Clone)")
        {
            obje = Instantiate(obje2[1], obje2Konumlari[obje2Sirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));
            olusanEsyalar.Add(obje);

            obje2Sirasi++;
        }
    }

    private void Obje3Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje3Iyi(Clone)")
        {
            obje = Instantiate(obje3[0], obje3Konumlari[obje3Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje3Sirasi++;
        }
        else if (isim == "Obje3Kotu(Clone)")
        {
            obje = Instantiate(obje3[1], obje3Konumlari[obje3Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje3Sirasi++;
        }
    }

    private void Obje4Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje4Iyi(Clone)")
        {
            obje = Instantiate(obje4[0], obje4Konumlari[obje4Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje4Sirasi++;
        }
        else if (isim == "Obje4Kotu(Clone)")
        {
            obje = Instantiate(obje4[1], obje4Konumlari[obje4Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje4Sirasi++;
        }
    }

    private void Obje5Yerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje5Iyi(Clone)")
        {
            obje = Instantiate(obje5[0], obje5Konumlari[obje5Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje5Sirasi++;
        }
        else if (isim == "Obje5Kotu(Clone)")
        {
            obje = Instantiate(obje5[1], obje5Konumlari[obje5Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje5Sirasi++;
        }
    }

    private void Obje1TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje1TekIyi(Clone)")
        {
            obje = Instantiate(obje1_Tek[0], obje1Tek_Konumlari[obje5Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje1_TekSirasi++;
        }
        else if (isim == "Obje1TekKotu(Clone)")
        {
            obje = Instantiate(obje1_Tek[1], obje1Tek_Konumlari[obje5Sirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje1_TekSirasi++;
        }
    }

    private void Obje2TekYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "Obje2TekIyi(Clone)")
        {
            obje = Instantiate(obje2_Tek[0], obje2Tek_Konumlari[obje1_TekSirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje2_TekSirasi++;
        }
        else if (isim == "Obje2TekKotu(Clone)")
        {
            obje = Instantiate(obje2_Tek[1], obje2Tek_Konumlari[obje2_TekSirasi].transform.position, Quaternion.identity);
            olusanEsyalar.Add(obje);

            obje2_TekSirasi++;
        }
    }
}
