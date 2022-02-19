using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Bar : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] sandalyeKonumlari;
    [SerializeField] private Transform[] icecekKonumlari;
    [SerializeField] private Transform[] barmenKonumlari;

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
            obje = Instantiate(sandalyeler[0], sandalyeKonumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
        else if (isim == "SandalyeKotu(Clone)")
        {
            obje = Instantiate(sandalyeler[1], sandalyeKonumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
    }

    //icecek yerlestirme icin gereklidir
    private void IceceklerYerlestir(string isim)
    {
        if (isim == "IcecekIyi(Clone)")
        {
            Instantiate(icecekler[0], icecekKonumlari[icecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            icecekSirasi++;
        }
        else if (isim == "IcecekKotu(Clone)")
        {
            Instantiate(icecekler[1], icecekKonumlari[icecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            icecekSirasi++;
        }
    }

    private void BarmenYerlestir(string isim)
    {
      
        if(isim == "BarmenIyi(Clone)")
        {
            Debug.Log(isim);
            Instantiate(barmenler[0], barmenKonumlari[barmenSirasi].transform.position, Quaternion.identity);
        }
        else if (isim == "BarmenKotu(Clone)")
        {
            Instantiate(barmenler[1], barmenKonumlari[barmenSirasi].transform.position, Quaternion.identity);
        }
    }
}
