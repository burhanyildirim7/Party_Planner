using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Insan : MonoBehaviour
{
    [Header("KarakterTakibiIcinGereklidir")]
    private  NavMeshAgent agent;
    private  GameObject player;
  

    [Header("AnimasyonKontroluIcinGereklidir")]
    private Animator anim;
    bool sonKonumaYaklasildiMi = false;


    WaitForSeconds beklemeSuresi = new WaitForSeconds(.2f);

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        StartCoroutine(KarakteriTakipEt());

    }

    public void InsaniGonder(GameObject hedef)  //Bina_Davetlilere gönderilmistir
    {
        if(LevelController.bolumunIsmi == "Bolum2")
        {
            hedef.GetComponent<Bina_KonserAlani>().EsyaCikarBar(gameObject);
        }
        else if (LevelController.bolumunIsmi == "Bolum3")
        {
            hedef.GetComponent<Bina_Davetliler>().EsyaCikarBar(gameObject);
        }
    }

    IEnumerator KarakteriTakipEt()
    {
        while(true)
        {
            agent.SetDestination(player.transform.position - Vector3.forward);
            yield return beklemeSuresi;
        }
    }

}
