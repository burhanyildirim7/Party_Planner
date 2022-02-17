using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meyveler : MonoBehaviour
{
    [Header("MeyveAtýsYapici")]  //Oyun sonunda yukari firlatma icin kullanilmistir
    bool yukariCikildiMi = false;
    bool assagiInildiMi = false;

    [Header("Componentler")]
    Rigidbody fizik; //Oyun sonunda yukari firlatma icin 

    WaitForSeconds beklemeSuresi = new WaitForSeconds(.25f);

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }

    public void OyunSonuMeyveKontrol(Transform adres)
    {
        StartCoroutine(MeyveyiGerekliYereGonder(adres));
    }

    public IEnumerator MeyveyiGerekliYereGonder(Transform GidilecekKonum)
    {
        while (!assagiInildiMi)
        {
            if (transform.position.y <= 8 && !yukariCikildiMi)
            {
                fizik.velocity = Vector3.up * 15;
            }
            else if (!assagiInildiMi)
            {
                transform.localScale *= 3.25f;
                transform.position = GidilecekKonum.position + Vector3.up * 10 + Vector3.right * Random.Range(-.5f, .5f) + Vector3.forward * Random.Range(-.5f, .5f);
                fizik.velocity = -Vector3.up * 1.5f;

                assagiInildiMi = true;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Zemin")) //Yere dusen meyve icin gecerlidir
        {
            transform.position = GameObject.FindWithTag("Player").transform.position - Vector3.forward * 20;
        }

        if (collision.gameObject.CompareTag("Restaurant")) //Buradan sonra restaurant icin insa etme sureci eklenecektir
        {
            gameObject.SetActive(false);
        }

    }
}
