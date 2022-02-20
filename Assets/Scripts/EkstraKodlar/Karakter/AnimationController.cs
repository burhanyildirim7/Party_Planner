using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void KosuAktif()
    {
        anim.SetBool("KosmaP", true);
    }

    public void KosuPasif()
    {
        anim.SetBool("KosmaP", false);
    }
}
