using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaOzellikleri : MonoBehaviour
{
    [Header("BinaBul")]
    private Bina_Bar bina_Bar;
    private Bina_KonserAlani bina_KonserAlani;

    [Header("ObjeOlustur")]
    private int leveldekiObjeSayisi = 0;


    void Start()
    {
        //Binalari bulmak icin gereklidir
        bina_Bar = GameObject.FindWithTag("Bar").GetComponent<Bina_Bar>();
        bina_KonserAlani = GameObject.FindWithTag("KonserAlani").GetComponent<Bina_KonserAlani>();

        //playerprefsler icin gereklidir
        if (!PlayerPrefs.HasKey("Bar_ObjeSayisi"))
        {
            //Bardaki Obje Sayisi
            PlayerPrefs.SetInt("Bar_ObjeSayisi", 0);

            //Muzik gurubu obje sayisi
            PlayerPrefs.SetInt("KonserAlani_ObjeSayisi", 0);
        }

        OlusturOncekiLeveldekileri();
    }


    private void OlusturOncekiLeveldekileri()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Bar_ObjeSayisi"); i++)
        {
            bina_Bar.ObjeyiYerlestir(PlayerPrefs.GetString("Bar" + i.ToString()));
        }

        for (int i = 0; i < PlayerPrefs.GetInt("KonserAlani_ObjeSayisi"); i++)
        {
            bina_KonserAlani.ObjeyiYerlestir(PlayerPrefs.GetString("KonserAlani" + i.ToString()));
        }

    }


    //Insa etme kýsýmlarý burdan soradýr
    public void BarKayitEt(string levelIsmi, string objeTuru)   // Binanin ismi ve obje türü
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi.ToString(), objeTuru); //Burasi sebebiyle ayný leveli iki defa oynadiginda son oynadigindaki objeler diger level icin kalici olur
        
        leveldekiObjeSayisi++;
        PlayerPrefs.SetInt("Bar_ObjeSayisi", leveldekiObjeSayisi);
    }


    public void KonserAlaniKayitEt(string levelIsmi, string objeTuru)  // Binanin ismi ve obje türü
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi, objeTuru);

        leveldekiObjeSayisi++;
        PlayerPrefs.SetInt("KonserAlani_ObjeSayisi", leveldekiObjeSayisi);
    }

    public void Sifirla_BinaOzellikleri()
    {
        //Daha sonrasinda burayi doldur.
    }

}
