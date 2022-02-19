using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Bar : MonoBehaviour
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
    private int sandalyeSirasi = 0;
    private int icecekSirasi = 0;
    private int barmenSirasi = 0;

    [Header("OlusacakObjeler")]
    [SerializeField] GameObject[] sandalyeler;
    [SerializeField] GameObject[] icecekler;
    [SerializeField] GameObject[] barmenler;

    private BinaOzellikleri binaOzellikleri;


    void Start()
    {
        binaOzellikleri = GameObject.FindWithTag("BuildingController").GetComponent<BinaOzellikleri>();
    }

    public void EsyaCikarBar(GameObject esya)
    {
        CarpismaKontrol(esya);
    }


    private void CarpismaKontrol(GameObject other)
    {
        other.gameObject.SetActive(false);
        binaOzellikleri.BarKayitEt("Bar" , other.gameObject.name);
        ObjeyiYerlestir(other.gameObject.name);
    }

    public void ObjeyiYerlestir(string isim)
    {
        SandalyeYerlestir(isim);
        IceceklerYerlestir(isim);
        BarmenYerlestir(isim);
    }

    //Sandalye yerlestirme için gereklidir
    private void SandalyeYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "SandalyeIyi(Clone)")
        {
            obje = Instantiate(sandalyeler[0], obje1Konumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
        else if (isim == "SandalyeKotu(Clone)")
        {
            obje = Instantiate(sandalyeler[1], obje1Konumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
    }

    //icecek yerlestirme icin gereklidir
    private void IceceklerYerlestir(string isim)
    {
        if (isim == "IcecekIyi(Clone)")
        {
            Instantiate(icecekler[0], obje2Konumlari[icecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            icecekSirasi++;
        }
        else if (isim == "IcecekKotu(Clone)")
        {
            Instantiate(icecekler[1], obje2Konumlari[icecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            icecekSirasi++;
        }
    }

    private void BarmenYerlestir(string isim)
    {
        if(isim == "BarmenIyi(Clone)")
        {
            Instantiate(barmenler[0], obje3Konumlari[barmenSirasi].transform.position, Quaternion.identity);
        }
        else if (isim == "BarmenKotu(Clone)")
        {
            Instantiate(barmenler[1], obje3Konumlari[barmenSirasi].transform.position, Quaternion.identity);
        }
    }
}
