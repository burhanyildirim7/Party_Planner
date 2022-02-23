using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    [Header("KameraTakibiIcinGerekli")]
    private GameObject Player;
    private Vector3 aradakiFark;
    public float kameraUzakligi;
    Vector3 velocity = Vector3.zero;

    

    [Header("OyunSonuKontrol")]
    bool oyunBittiMi = false;
    private GameObject target;




    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;
        target = Player;
    }



    void Update()
    {
        if (!oyunBittiMi)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
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
        }

       
        
    }

    public void KameraOyunBasiKontrol()
    {
        transform.rotation = Quaternion.Euler(Vector3.right * 17);
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
        while (oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 40), 10 * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator OyunSonuKameraKontrol3()
    {
        bool digerKamerayaGecsinMi = false;
        while (oyunBittiMi && !digerKamerayaGecsinMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 40 + Vector3.up * -40), 10 * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(2.5f);
        digerKamerayaGecsinMi = true;
        target = GameObject.FindWithTag("KameraNoktasi").transform.GetChild(3).transform.gameObject;


        while (oyunBittiMi && !digerKamerayaGecsinMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, Time.deltaTime * 20);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right * 40 + Vector3.up * -40), 10 * Time.deltaTime);

            yield return null;
        }

    }

}
