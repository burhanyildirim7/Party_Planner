using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaOzellikleri : MonoBehaviour
{
    [Header("BinaBul")]
    private Bina_Punch bina_Punch;
    private Bina_KonserAlani bina_KonserAlani;
    private Bina_Davetliler bina_Davetliler;

    [Header("ObjeOlustur")]
    private int leveldekiObjeSayisi = 0;


    public void InsaEt()
    {
        bina_Punch = GameObject.FindWithTag("Punch").GetComponent<Bina_Punch>();
        bina_KonserAlani = GameObject.FindWithTag("KonserAlani").GetComponent<Bina_KonserAlani>();
        bina_Davetliler = GameObject.FindWithTag("DavetliAlani").GetComponent<Bina_Davetliler>();
        OlusturOncekiLeveldekileri();
    }

    public void Sifirla() //Parti tamamlandýktan sonra 
    {
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetString("Bolum1" + i.ToString(), "");
            PlayerPrefs.SetString("Bolum2" + i.ToString(), "");
            PlayerPrefs.SetString("Bolum3" + i.ToString(), "");
        }
        PlayerPrefs.SetInt("Punch_ObjeSayisi", 0);
        PlayerPrefs.SetInt("KonserAlani_ObjeSayisi", 0);
        PlayerPrefs.SetInt("DavetliAlani_ObjeSayisi", 0);
    }

    private void OlusturOncekiLeveldekileri()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Punch_ObjeSayisi"); i++)
        {
            bina_Punch.ObjeyiYerlestir(PlayerPrefs.GetString("Bolum1" + i.ToString()));
        }

        for (int i = 0; i < PlayerPrefs.GetInt("KonserAlani_ObjeSayisi"); i++)
        {
            bina_KonserAlani.ObjeyiYerlestir(PlayerPrefs.GetString("Bolum2" + i.ToString()));
        }

        for (int i = 0; i < PlayerPrefs.GetInt("DavetliAlani_ObjeSayisi"); i++)
        {
            bina_Davetliler.ObjeyiYerlestir(PlayerPrefs.GetString("Bolum3" + i.ToString()));
        }
    }


    //Insa etme kýsýmlarý burdan soradýr
    public void Bolum1KayitEt(string levelIsmi, string objeTuru)   // Binanin ismi ve obje türü
    {
        Debug.Log(levelIsmi);
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi.ToString(), objeTuru); //Burasi sebebiyle ayný leveli iki defa oynadiginda son oynadigindaki objeler diger level icin kalici olur
        
        leveldekiObjeSayisi++;
        PlayerPrefs.SetInt("Punch_ObjeSayisi", leveldekiObjeSayisi);
    }


    public void Bolum2KayitEt(string levelIsmi, string objeTuru)  // Binanin ismi ve obje türü
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi, objeTuru);

        leveldekiObjeSayisi++;
        PlayerPrefs.SetInt("KonserAlani_ObjeSayisi", leveldekiObjeSayisi);
    }

    public void Bolum3KayitEt(string levelIsmi, string objeTuru)   // Binanin ismi ve obje türü
    {
        PlayerPrefs.SetString(levelIsmi + leveldekiObjeSayisi, objeTuru);

        leveldekiObjeSayisi++;
        PlayerPrefs.SetInt("DavetliAlani_ObjeSayisi", leveldekiObjeSayisi);
    }
}
