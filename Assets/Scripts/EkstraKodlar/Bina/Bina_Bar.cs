using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Bar : MonoBehaviour
{

    [Header("Konumlar")]
    [SerializeField] private Transform[] sandalyeKonumlari;
    [SerializeField] private Transform[] icecekKonumlari;

    [Header("SiraSayilari")]
    private int sandalyeSirasi = 0;
    private int IcecekSirasi = 0;

    [Header("OlusacakObjeler")]
    [SerializeField] GameObject[] Sandalyeler;
    [SerializeField] GameObject[] Icecekler;

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
    }

    //Sandalye yerlestirme için gereklidir
    private void SandalyeYerlestir(string isim)
    {
        GameObject obje;
        if (isim == "KirmiziSandalye(Clone)")
        {
            Debug.Log(sandalyeSirasi);
            obje = Instantiate(Sandalyeler[0], sandalyeKonumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
        else if (isim == "MaviSandalye(Clone)")
        {
            obje = Instantiate(Sandalyeler[1], sandalyeKonumlari[sandalyeSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90));
            obje.transform.localScale = Vector3.one * 4;

            sandalyeSirasi++;
        }
    }

    //icecek yerlestirme icin gereklidir
    private void IceceklerYerlestir(string isim)
    {
        if (isim == "KirmiziIcecek(Clone)")
        {
            Instantiate(Icecekler[0], icecekKonumlari[IcecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            IcecekSirasi++;
        }
        else if (isim == "MaviIcecek(Clone)")
        {
            Instantiate(Icecekler[1], icecekKonumlari[IcecekSirasi].transform.position, Quaternion.Euler(-Vector3.right * 90 + Vector3.forward * 180));

            IcecekSirasi++;
        }
    }
}
