using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolumSonuEfekt : MonoBehaviour
{
    [Header("OyunSonuEfektler")]
    [SerializeField] ParticleSystem[] efektler;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.6f);


    public void EfektleriBaslat()
    {
        StartCoroutine(OyunSonuEfektleriAyarla());
    }


    IEnumerator OyunSonuEfektleriAyarla()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < efektler.Length / 2; i++)
        {
            efektler[i * 2].Play();
            efektler[i * 2 + 1].Play();
            yield return beklemeSuresi;
        }
    }
}
