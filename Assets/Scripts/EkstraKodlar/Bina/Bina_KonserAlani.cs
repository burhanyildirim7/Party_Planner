using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_KonserAlani : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] hoparlorKonumlari;
    [SerializeField] private Transform[] sarkiciKonumlari;

    [Header("SiraSayilari")]
    private int hoparlorSirasi = 0;
    private int sarkiciSirasi = 0;

    [Header("OlusacakObjeler")]
    [SerializeField] GameObject[] hoparlorler;
    [SerializeField] GameObject[] sarkicilar;

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
        binaOzellikleri.KonserAlaniKayitEt("KonserAlani", other.gameObject.name);
        ObjeyiYerlestir(other.gameObject.name);
    }

    public void ObjeyiYerlestir(string isim)
    {
        SandalyeYerlestir(isim);
        IceceklerYerlestir(isim);
    }

    //Sandalye yerlestirme için gereklidir
    private void SandalyeYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "HoparlorKirmizi(Clone)")
        {
            obje = Instantiate(hoparlorler[0], hoparlorKonumlari[hoparlorSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 1;

            hoparlorSirasi++;
        }
        else if (isim == "HoparlorMavi(Clone)")
        {
            obje = Instantiate(hoparlorler[1], hoparlorKonumlari[hoparlorSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 1;

            hoparlorSirasi++;
        }
    }

    //icecek yerlestirme icin gereklidir
    private void IceceklerYerlestir(string isim)
    {
        if (isim == "KirmiziIcecek(Clone)")
        {
            Instantiate(sarkicilar[0], sarkiciKonumlari[sarkiciSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            sarkiciSirasi++;
        }
        else if (isim == "MaviIcecek(Clone)")
        {
            Instantiate(sarkicilar[1], sarkiciKonumlari[sarkiciSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            sarkiciSirasi++;
        }
    }
}
