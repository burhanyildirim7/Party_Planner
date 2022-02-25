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


    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.04f);
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(.2f);

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        StartCoroutine(KarakteriTakipEt());
        StartCoroutine(HizBelirle());
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

    public void HedefDegistir()
    {
       
    }


    IEnumerator KarakteriTakipEt()
    {
        while(true)
        {
            agent.SetDestination(player.transform.position - Vector3.forward);
            yield return beklemeSuresi1;
        }
    }

    IEnumerator HizBelirle()
    {
        while(true)
        {
            if (Vector3.Distance(transform.position, player.transform.position - Vector3.forward) >= 1.5f)
            {
                agent.speed = 7.2f;
            }
            else
            {
                agent.speed = 6f;
            }
            yield return beklemeSuresi2;
        }
    }

}
