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
        if (!PlayerPrefs.HasKey("BarOlustur"))
        {
            PlayerPrefs.SetInt("BarOlustur", 0);
            PlayerPrefs.SetInt("MuzikGrubuOlustur", 0);

            //Bardaki Obje Sayisi
            PlayerPrefs.SetInt("Bar_ObjeSayisi", 0);

            //Muzik gurubu obje sayisi
            PlayerPrefs.SetInt("MuzikGrubu_ObjeSayisi", 0);
        }

        OlusturOncekiLeveldekileri();
    }

    void Update()   //Burasinin silinmesi gerekecek
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetInt("BarOlustur", 1);
        }
    }

    //Onceki levellerde insa edilenleri getir
    private void OlusturOncekiLeveldekileri()
    {
        
        if (PlayerPrefs.GetInt("BarOlustur") == 1)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("Bar_ObjeSayisi"); i++)
            {
                bina_Bar.ObjeyiYerlestir(PlayerPrefs.GetString("Bar" + i.ToString()));
            }
        }

        if (PlayerPrefs.GetInt("MuzikGrubuOlustur") == 1)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("MuzikGrubu_ObjeSayisi"); i++)
            {
                bina_KonserAlani.ObjeyiYerlestir(PlayerPrefs.GetString("MuzikGrubu" + i.ToString()));
            }
        }
    }


    //Insa etme kýsýmlarý burdan soradýr
    public void BarKayitEt(string levelIsmi, string objeTuru)
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi.ToString(), objeTuru);

        PlayerPrefs.SetInt("Bar_ObjeSayisi", leveldekiObjeSayisi);
        leveldekiObjeSayisi++;
    }


    public void MuzikGrubuKayitEt(string levelIsmi, string objeTuru)
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi, objeTuru);

        PlayerPrefs.SetInt("MuzikGrubu_ObjeSayisi", leveldekiObjeSayisi);
        leveldekiObjeSayisi++;
    }

}
