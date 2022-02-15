using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arabalar : MonoBehaviour
{
    [Header("TakipIcinGerekli")]
    GameObject Karakter;
    public GameObject hedef;
    bool oyunBittiMi = false;
    [SerializeField] int siralama = 0; //ilk arabanýn "siralama" degeri 1 olmalidir

    [Header("IcerdenGerekli")]
    NavMeshAgent agent;
    WaitForSeconds beklemeSuresi = new WaitForSeconds(.04f);

    void Start()
    {
        Karakter = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        hedef = Karakter;

        StartCoroutine(TakipEt());
    }

    public void ArabalariDurdur()
    {
        oyunBittiMi = true;
        agent.ResetPath();
    }

    IEnumerator TakipEt()
    {
        while (!oyunBittiMi)
        {
            agent.SetDestination(hedef.transform.position - hedef.transform.forward * .4f);
            yield return beklemeSuresi;
        }
    }


    //olusan her araba en önde olacagi icin böyle bir fonksiyona ihtiyac vardir
    public void SiralamaDegistir(GameObject yeniHedef)
    {
        transform.position -= Vector3.forward * .5f;
        hedef = yeniHedef;
    }
}
