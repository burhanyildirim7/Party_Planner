using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsyaGonder : MonoBehaviour
{

    void Start()
    {
       
    }

    public void EsyayiGonder(GameObject hedef)
    {
        hedef.GetComponent<Bina_Bar>().EsyaCikarBar(gameObject);  //Burasinin otomatik olmasi gerekir
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
