using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("KosuIcin")]
    [SerializeField] float hiz = 5;
    [SerializeField] float donusHizi = 5;
    private bool oyunBitti = false;

    [Header("KarakterYönBelirlemeIcin")]
    private Touch ilkDokunus;
    private Vector3 haraketEttirme;

    [Header("AnimatorIcinGerekli")]
    Animator anim;

    [Header("OyunSonuIcýnGerekli")]
    GameObject gameController;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(!oyunBitti)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * hiz);


            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.right * Time.deltaTime * donusHizi * 20);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * donusHizi * 20);
            }
        }

        if (Input.touchCount > 0 && !oyunBitti)
        {
            ilkDokunus = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                haraketEttirme = ilkDokunus.deltaPosition;

                transform.Translate(Vector3.right * haraketEttirme.x * Time.deltaTime * donusHizi);
            }
        }
    }


    //Oyun sonu icin gereklidir
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BolumSonu"))
        {
            gameController.GetComponent<GameController>().OyunSonu();
            anim.SetBool("KosmaP", false);
            other.gameObject.SetActive(false);
            oyunBitti = true;
        }
    }
}
