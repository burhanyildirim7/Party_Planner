using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meyveYokEt : MonoBehaviour
{
    [SerializeField] ParticleSystem suyaDusmeEfekt;

    private WaitForSeconds beklemeSuresi = new WaitForSeconds(.1f);

    void Start()
    {
        StartCoroutine(meyveninBoyunuKucult());
    }


    IEnumerator meyveninBoyunuKucult()
    {
        while(true)
        {
            transform.localScale *= .95f;
            yield return beklemeSuresi;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kase"))
        {
            Instantiate(suyaDusmeEfekt, transform.position + Vector3.up * .25f, Quaternion.Euler(-Vector3.right));
            Destroy(gameObject);
        }
    }
}
