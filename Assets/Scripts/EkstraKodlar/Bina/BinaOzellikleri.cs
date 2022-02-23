using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaOzellikleri : MonoBehaviour
{
    [Header("BinaBul")]
    private Bina_Punch bina_Punch;
    private Bina_KonserAlani bina_KonserAlani;
    //  private Bina_Davetliler bina_Davetliler;   Buradaki veriler kayit edilmedigi icin erisilmesine gerek yoktur

    [Header("ObjeOlustur")]
    private int leveldekiObjeSayisi = 0;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.2f);

    public void InsaEt()
    {
        bina_Punch = GameObject.FindWithTag("Punch").GetComponent<Bina_Punch>();
        bina_KonserAlani = GameObject.FindWithTag("KonserAlani").GetComponent<Bina_KonserAlani>();
        StartCoroutine(OlusturOncekiLeveldekileri());
    }

    public void Sifirla() //Parti tamamlandýktan sonra 
    {
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetString("Bolum1" + i.ToString(), "");
            PlayerPrefs.SetString("Bolum2" + i.ToString(), "");
        }
        PlayerPrefs.SetInt("Punch_ObjeSayisi", 0);
        PlayerPrefs.SetInt("KonserAlani_ObjeSayisi", 0);
    }

    IEnumerator OlusturOncekiLeveldekileri()
    {

        for (int i = 0; i < PlayerPrefs.GetInt("Punch_ObjeSayisi"); i++)
        {
            bina_Punch.ObjeyiYerlestir(PlayerPrefs.GetString("Bolum1" + i.ToString()));
            yield return beklemeSuresi;
        }

        for (int i = 0; i < PlayerPrefs.GetInt("KonserAlani_ObjeSayisi"); i++)
        {
            bina_KonserAlani.ObjeyiYerlestir(PlayerPrefs.GetString("Bolum2" + i.ToString()));
            yield return beklemeSuresi;
        }

        //Davetlilerin olmamsýnýn sebebi kayit edilmesinin ihtiyacinin olmamasýndandir
    }


    //Insa etme kýsýmlarý burdan soradýr
    public void Bolum1KayitEt(string levelIsmi, string objeTuru)   // Binanin ismi ve obje türü
    {
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
}
