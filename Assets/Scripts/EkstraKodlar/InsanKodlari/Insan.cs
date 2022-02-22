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


    //Oyunun son durumundaki dans icin gereklidir
    public void SonKonumuBelirle(Vector3 sonHedef) //Bina Davetlilerden geliyor
    {
        StartCoroutine(SonUzaklikAyari(sonHedef));

    }
    

    IEnumerator SonUzaklikAyari(Vector3 sonHedef)
    {
        while(!sonKonumaYaklasildiMi)
        {
            if(Vector3.Distance(transform.position, sonHedef) >= 2f)
            {
                agent.SetDestination(sonHedef);
            }
            else
            {
                sonKonumaYaklasildiMi = true;
            }
            

            yield return beklemeSuresi;
        }
    }

}
