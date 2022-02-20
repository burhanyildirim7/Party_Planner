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

        if(bolumIsmi == "PunchAlani")
        {
            hedef.GetComponent<Bina_Bar>().EsyaCikarBar(gameObject); 
        }
        else if (bolumIsmi == "KonserAlani")
        {
            hedef.GetComponent<Bina_KonserAlani>().EsyaCikarBar(gameObject); 
        }
        else if (bolumIsmi == "Davetliler")
        {
          //  hedef.GetComponent<Bina_Davetliler>().EsyaCikarBar(gameObject);  //Burasinin otomatik olmasi gerekir
        }
        
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin")) //Yere dusen meyve icin gecerlidir
        {
            transform.position = GameObject.FindWithTag("Player").transform.position - Vector3.forward * 20;
        }

    }
}
