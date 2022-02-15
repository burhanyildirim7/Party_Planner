using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    [Header("KameraTakibiIcinGerekli")]
    Transform Karakter;
    public float kameraUzakligi;
    Vector3 velocity = Vector3.zero;

    public float sayi;

    [Header("OyunSonuKontrol")]
    bool oyunBittiMi = false;

    void Start()
    {
        Karakter = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Karakter.position + -Vector3.forward * 3 * (1 + kameraUzakligi * .2f) + Vector3.up * 3 * (1 + kameraUzakligi * .1f),ref velocity, Time.deltaTime * sayi);
        }
    }

    public void KameraOyunSonuKontrolAyarlari()
    {
        oyunBittiMi = true;
        StartCoroutine(OyunSonuKameraKontrol());
    }

    //Oyun sonunda tum meyveleri gorebilmek icin yapilmistir
    IEnumerator OyunSonuKameraKontrol()
    {
        transform.position = Karakter.position + -Vector3.forward * 3 * (1 + kameraUzakligi * .2f) + Vector3.up * 3 * (1 + kameraUzakligi * .1f) - Vector3.forward * 10;
        while(true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Karakter.position + -Vector3.forward * 3 * (1 + kameraUzakligi * .2f) + Vector3.up * 3 * (1 + kameraUzakligi * .1f),ref velocity, Time.deltaTime * sayi * 20);

            yield return null;
        }
    }
}
