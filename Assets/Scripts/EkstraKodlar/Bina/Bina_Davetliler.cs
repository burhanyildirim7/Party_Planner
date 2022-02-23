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
    private int obje2_TekSirasi = 0;

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
    [SerializeField] GameObject[] obje6_Tek;

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


    public void ObjeyiYerlestir(GameObject esya)
    {
        Obje1Yerlestir(esya);
        Obje2Yerlestir(esya);
        Obje3Yerlestir(esya);//esya
        Obje4Yerlestir(esya);//esya
        Obje5Yerlestir(esya);//esya
        Obje1TekYerlestir(esya);
        Obje2TekYerlestir(esya);
        Obje3TekYerlestir(esya);
        Obje4TekYerlestir(esya);
        Obje5TekYerlestir(esya);
        Obje6TekYerlestir(esya);
    }




    private void Obje1Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje1Iyi(Clone)")
        {
            obje1[0].SetActive(true);
        }
        else if (insan.name == "Obje1Kotu(Clone)")
        {
            obje1[1].SetActive(true);
        }
    }

    private void Obje2Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje2Iyi(Clone)")
        {
            obje2[0].SetActive(true);
        }
        else if (insan.name == "Obje2Kotu(Clone)")
        {
            obje2[1].SetActive(true);
        }
    }

    private void Obje3Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje3Iyi(Clone)")
        {
            obje3[0].SetActive(true);
        }
        else if (insan.name == "Obje3Kotu(Clone)")
        {
            obje3[1].SetActive(true);
        }
    }

    private void Obje4Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje4Iyi(Clone)")
        {
            obje4[0].SetActive(true);
        }
        else if (insan.name == "Obje4Kotu(Clone)")
        {
            obje4[1].SetActive(true);
        }
    }

    private void Obje5Yerlestir(GameObject insan)
    {
        if (insan.name == "Obje5Iyi(Clone)")
        {
            obje5[0].SetActive(true);
        }
        else if (insan.name == "Obje5Kotu(Clone)")
        {
            obje5[1].SetActive(true);
        }
    }



    private void Obje1TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje1TekIyi(Clone)")
        {
            obje1_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje1TekKotu(Clone)")
        {
            obje1_Tek[1].SetActive(true);
        }
    }

    private void Obje2TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje2TekIyi(Clone)")
        {
            obje2_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje2TekKotu(Clone)")
        {
            obje2_Tek[1].SetActive(true);
        }
    }

    private void Obje3TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje3TekIyi(Clone)")
        {
            obje3_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje3TekKotu(Clone)")
        {
            obje3_Tek[1].SetActive(true);
        }
    }

    private void Obje4TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje4TekIyi(Clone)")
        {
            obje4_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje4TekKotu(Clone)")
        {
            obje4_Tek[1].SetActive(true);
        }
    }

    private void Obje5TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje5TekIyi(Clone)")
        {
            obje5_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje5TekKotu(Clone)")
        {
            obje5_Tek[1].SetActive(true);
        }
    }

    private void Obje6TekYerlestir(GameObject insan)
    {
        if (insan.name == "Obje6TekIyi(Clone)")
        {
            obje5_Tek[0].SetActive(true);
        }
        else if (insan.name == "Obje6TekKotu(Clone)")
        {
            obje5_Tek[1].SetActive(true);
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
