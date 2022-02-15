using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterPara : MonoBehaviour
{
    [Header("ParanýnKontroluIcinGereklidir")]
    GameController1 gameController;

    [Header("Efektler")]
    [SerializeField] ParticleSystem paraToplamaEfekt;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController1>();
    }

    public void meyveSatinAl(int fiyat)
    {
        gameController.SetScore(fiyat * -1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Para"))
        {
            gameController.SetScore(1000); //Daha sonrasinda degistirilebilir


            paraToplamaEfekt.transform.position = other.transform.position + Vector3.up * .5f;
            paraToplamaEfekt.Play();

            other.gameObject.SetActive(false);
        }
    }

}
