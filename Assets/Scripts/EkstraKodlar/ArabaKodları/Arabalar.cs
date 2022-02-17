using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arabalar : MonoBehaviour
{
    [Header("TakipIcinGerekli")]
    private Transform Karakter;
    private Vector3 hedef = Vector3.forward * .4f;
    bool oyunBittiMi = false;
    [SerializeField] int siralama = 0; //ilk arabanýn "siralama" degeri 1 olmalidir

    [Header("IcerdenGerekli")]
    NavMeshAgent agent;


    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.04f);
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(1f);

    void Start()
    {
        Karakter = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 8;

        StartCoroutine(TakipEt());
        StartCoroutine(ArabaninHiziniDegistir());
    }


    IEnumerator ArabaninHiziniDegistir()
    {
        yield return beklemeSuresi2;
        agent.speed = 3.4f;
    }
   

    IEnumerator TakipEt()
    {
        while (!oyunBittiMi)
        {
            agent.SetDestination(Karakter.position - hedef);
            yield return beklemeSuresi1;
        }
    }


    //olusan her araba en önde olacagi icin böyle bir fonksiyona ihtiyac vardir
    public void HedefDegistir(Vector3 yeniHedef)
    {
        hedef = yeniHedef;
    }

    //Oyun bitiminde arabalari durdurur
    public void ArabalariDurdur()
    {
        oyunBittiMi = true;
        agent.ResetPath();
    }
}
