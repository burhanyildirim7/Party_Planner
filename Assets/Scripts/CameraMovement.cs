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
    public float kameraYavaslikAyari;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;
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
        StartCoroutine(OyunSonuKameraKontrol());
    }

    public void KameraOyunBasiKontrol()
    {
        oyunBittiMi = false;
    }

    //Oyun sonunda tum meyveleri gorebilmek icin yapilmistir
    IEnumerator OyunSonuKameraKontrol()
    {
      //  transform.position = Player.transform.position + -Vector3.forward * 8 * (1 + kameraUzakligi * .2f) + Vector3.up * 3 * (1 + kameraUzakligi * .1f) - Vector3.forward * 10;
        Vector3 kameraHedef = new Vector3(0, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z);
        while (oyunBittiMi)
        {
            transform.position = Vector3.SmoothDamp(transform.position, kameraHedef - Vector3.forward * 4, ref velocity, Time.deltaTime * kameraYavaslikAyari * 20);

            yield return null;
        }
    }

}
