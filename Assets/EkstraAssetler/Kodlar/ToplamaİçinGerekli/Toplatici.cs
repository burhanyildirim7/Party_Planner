using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toplatici : MonoBehaviour
{
    [SerializeField] MeyveTurleri meyveTuru;

    [Header("KarakterParasinaErisim")]
    KarakterPara karakterPara;

    [Header("MeyveResimleriniIcinGerekli")]
    [SerializeField] GameObject[] meyveResimleri;

    [Header("MeshPasiflestirmeIcinGerekli")]
    MeshRenderer mesh;

    [Header("MeyveninArabayaKoyulmasi")]
    ArabayaDoldurucu arabayadoldurucu;

    [Header("FiyatlaIlgiliDuzenleme")]
    [SerializeField] int fiyat;
    [SerializeField] Text fiyatYazdirici;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.25f);

    private void Start()
    {
        karakterPara = GameObject.FindWithTag("Player").GetComponent<KarakterPara>();
        arabayadoldurucu = GameObject.FindWithTag("Arabalar").GetComponent<ArabayaDoldurucu>();

        fiyatYazdirici.text = fiyat.ToString() + " $";

        mesh = GetComponent<MeshRenderer>();

        if (meyveTuru.ToString() == "Kirmizi")
        {
            meyveResimleri[0].SetActive(true);
        }
        else if (meyveTuru.ToString() == "Sari")
        {
            meyveResimleri[1].SetActive(true);
        }
        else if (meyveTuru.ToString() == "Mavi")
        {
            meyveResimleri[2].SetActive(true);
        }
        else if (meyveTuru.ToString() == "Yesil")
        {
            meyveResimleri[3].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            karakterPara.meyveSatinAl(fiyat);
            mesh.enabled = false;
            for (int i = 0; i < meyveResimleri.Length; i++)
            {
                meyveResimleri[i].SetActive(false);
            }

            StartCoroutine(meyveCikar());
        }
    }

    IEnumerator meyveCikar()
    {
        for (int i = 0; i < Random.Range(3 , 7); i++)
        {
            arabayadoldurucu.MeyveYerlestirmeAyarlayici(meyveTuru.ToString());
            yield return beklemeSuresi;
        }
    }
}
