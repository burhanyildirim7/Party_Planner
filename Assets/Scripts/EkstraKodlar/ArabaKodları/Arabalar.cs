using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arabalar : MonoBehaviour
{
    [Header("TakipIcinGerekli")]
    private Transform Karakter;
    private Vector3 hedef;
    bool oyunBittiMi = false;

    [Header("IcerdenGerekli")]
    NavMeshAgent agent;


    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.04f);
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(1f);

    void Start()
    {
        Karakter = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 8;

        StartCoroutine(ArabaninHiziniDegistir());
    }


    IEnumerator ArabaninHiziniDegistir()
    {
        yield return beklemeSuresi2;
        agent.speed = 6f;
    }
   

    IEnumerator TakipEt()
    {
        while (!oyunBittiMi)
        {
            if (agent != null)
            {
                agent.SetDestination(Karakter.position - hedef);
            }
          
            yield return beklemeSuresi1;
        }
    }


    //olusan her araba en �nde olacagi icin b�yle bir fonksiyona ihtiyac vardir
    public void HedefDegistir(Vector3 yeniHedef)
    {
        hedef = yeniHedef;
        StartCoroutine(TakipEt());
    }

    //Oyun bitiminde arabalari durdurur
    public void ArabalariDurdur()
    {
        oyunBittiMi = true;
        agent.ResetPath();
    }
}
