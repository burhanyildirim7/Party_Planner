using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsyaGonder : MonoBehaviour
{
    private string bolumIsmi;

    void Start()
    {
        bolumIsmi = LevelController.bolumunIsmi;
    }

    public void EsyayiGonder(GameObject hedef)
    {
        if(bolumIsmi == "Bolum1")
        {
            hedef.GetComponent<Bina_Punch>().EsyaCikarBar(gameObject); 
        }
        else if (bolumIsmi == "Bolum2")
        {
            hedef.GetComponent<Bina_KonserAlani>().EsyaCikarBar(gameObject); 
        }
        else if (bolumIsmi == "Bolum3")
        {
            hedef.GetComponent<Bina_Davetliler>().EsyaCikarBar(gameObject);
        }

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin")) //Yere dusen meyve icin gecerlidir
        {
            transform.position = GameObject.FindWithTag("Player").transform.position - Vector3.forward * 350;
        }
    }


    public void YokEt()
    {
        Destroy(gameObject);
    }
}
