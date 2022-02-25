using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    [Header("KameraTakibiIcinGerekli")]
    private GameObject Player;
    [SerializeField] Vector3 aradakiFark;
    [SerializeField] float rotasyon;
    Vector3 velocity = Vector3.zero;
    private bool digerKamerayaGeceilsinMi = false; //Bolum 3 icin gereklidir

    

    [Header("OyunSonuKontrol")]
    bool oyunBittiMi = false;
    private GameObject target;




    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //aradakiFark = transform.position - Player.transform.position;
        target = Player;
    }



    void Update()
    {
        if (!oyunBittiMi)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + Vector3.up * aradakiFark.y + Vector3.forward * aradakiFark.z, Time.deltaTime * 5f);
        }
    }


    public void KameraOyunSonuKontrolAyarlari()
    {
        oyunBittiMi = true;
        if (LevelController.bolumunIsmi == "Bolum1")
        {
            target = GameObject.FindWithTag("KameraNoktasi").transform.GetChild(0).transform.gameObject;
            StartCoroutine(OyunSonuKameraKontrol1());
        }
        else if (LevelController.bolumunIsmi == "Bolum2")
        {
            target = GameObject.FindWithTag("KameraNoktasi").transform.GetChild(1).transform.gameObject;
            StartCoroutine(OyunSonuKameraKontrol2());
        }
        else if (LevelController.bolumunIsmi == "Bolum3")
        {
            target = GameObject.FindWithTag("KameraNoktasi").transform.GetChild(2).transform.gameObject;
            StartCoroutine(OyunSonuKameraKontrol3());
            StartCoroutine(OyunSonuKameraKontrol4());
        }
    }

    public void KameraOyunBasiKontrol()
    {
        transform.position = Player.transform.position + Vector3.up * aradakiFark.y + Vector3.forward * aradakiFark.z;
        transform.rotation = Quaternion.Euler(Vector3.right * 25);
        oyunBittiMi = false;
    }

    //Oyun sonunda tum meyveleri gorebilmek icin yapilmistir
    IEnumerator OyunSonuKameraKontrol1()
    {
        while (oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 30 + Vector3.up * 50), 10 * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator OyunSonuKameraKontrol2()
    {
        digerKamerayaGeceilsinMi = false;
        while (oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 40), 10 * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator OyunSonuKameraKontrol3()
    {
        while (oyunBittiMi && !digerKamerayaGeceilsinMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 40 + Vector3.up * -40), 10 * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(2.5f);
        digerKamerayaGeceilsinMi = true;

    }

    IEnumerator OyunSonuKameraKontrol4()
    {
        yield return new WaitForSeconds(3.5f);
        digerKamerayaGeceilsinMi = true;
        target = GameObject.FindWithTag("KameraNoktasi").transform.GetChild(3).transform.gameObject;


        while (oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 30 + Vector3.up * 50), 10 * Time.deltaTime);

            yield return null;
        }

    }

}
