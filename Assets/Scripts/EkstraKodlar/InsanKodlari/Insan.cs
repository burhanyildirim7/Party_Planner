using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Insan : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    bool sonKonumaYaklasildiMi = false;


    WaitForSeconds beklemeSuresi = new WaitForSeconds(.2f);

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        StartCoroutine(HedefBelirle());
    }

    public void InsaniGonder(GameObject hedef)  //Bina_Davetlilere gönderilmistir
    {
        hedef.GetComponent<Bina_Davetliler>().EsyaCikarBar(gameObject);
    }

    
    IEnumerator HedefBelirle()
    {
        while (GameController.instance.isContinue == true)
        {
            agent.SetDestination(player.transform.position);
            yield return beklemeSuresi;
        }
    }

    public void SonKonumuBelirle(Vector3 sonHedef) //Bina Davetlilerden geliyor
    {
        agent.SetDestination(sonHedef);
    }

}
