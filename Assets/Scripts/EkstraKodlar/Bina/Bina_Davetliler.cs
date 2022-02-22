using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Davetliler : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] obje1Konumlari;
    [SerializeField] private Transform[] obje2Konumlari;
    [SerializeField] private Transform[] obje3Konumlari;
    [SerializeField] private Transform[] obje4Konumlari;
    [SerializeField] private Transform[] obje5Konumlari;
    [SerializeField] private Transform[] obje1Tek_Konumlari;
    [SerializeField] private Transform[] obje2Tek_Konumlari;

    [Header("CokluCikacakObjelerÝcinKonum")]
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

    public void EsyaCikarBar(GameObject insan)
    {
        ObjeyiYerlestir(insan);
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


    public void ObjeyiYerlestir(GameObject insan)
    {
        Obje1Yerlestir(insan);
        Obje2Yerlestir(insan);
        Obje3Yerlestir(insan);
        Obje4Yerlestir(insan);
        Obje5Yerlestir(insan);
        Obje1TekYerlestir(insan);
        Obje2TekYerlestir(insan);
    }




    private void Obje1Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje1Iyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje1Konumlari[obje1Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje1Sirasi++;
        }
        else if (insan.name == "Obje1Kotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje1Konumlari[obje1Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje1Sirasi++;
        }
    }

    private void Obje2Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje2Iyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje2Konumlari[obje2Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje2Sirasi++;
        }
        else if (insan.name == "Obje2Kotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje2Konumlari[obje2Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje2Sirasi++;
        }
    }

    private void Obje3Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje3Iyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje3Konumlari[obje3Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje3Sirasi++;
        }
        else if (insan.name == "Obje3Kotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje3Konumlari[obje3Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje3Sirasi++; ;
        }
    }

    private void Obje4Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje4Iyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje4Konumlari[obje4Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje4Sirasi++;
        }
        else if (insan.name == "Obje4Kotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje4Konumlari[obje4Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje4Sirasi++;
        }
    }

    private void Obje5Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje5Iyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje5Konumlari[obje5Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje5Sirasi++;
        }
        else if (insan.name == "Obje5Kotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje5Konumlari[obje5Sirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje5Sirasi++;
        }
    }

    private void Obje1TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje1TekIyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje1Tek_Konumlari[obje1_TekSirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje1_TekSirasi++;
        }
        else if (insan.name == "Obje1TekKotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje1Tek_Konumlari[obje1_TekSirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje1_TekSirasi++;
        }
    }

    private void Obje2TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje2TekIyi(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje2Tek_Konumlari[obje2_TekSirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje2_TekSirasi++;
        }
        else if (insan.name == "Obje2TekKotu(Clone)")
        {
            insan.GetComponent<Insan>().SonKonumuBelirle(obje2Tek_Konumlari[obje2_TekSirasi].transform.position);
            olusanEsyalar.Add(insan);

            obje2_TekSirasi++;
        }
    }
}
