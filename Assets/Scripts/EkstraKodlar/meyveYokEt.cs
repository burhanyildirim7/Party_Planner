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
            transform.localScale *= .9f;
            yield return beklemeSuresi;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kase"))
        {
          /*  if (LevelController.bolumunIsmi == "Bolum1")
            {
                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            }*/

            Instantiate(suyaDusmeEfekt, transform.position + Vector3.up * .175f, Quaternion.Euler(-Vector3.right * 90));
            gameObject.SetActive(false);
        }
    }
}
