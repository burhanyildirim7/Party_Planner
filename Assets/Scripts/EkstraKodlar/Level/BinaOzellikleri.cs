using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaOzellikleri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Para"))
        {
            PlayerPrefs.SetInt("Para", 0);
            PlayerPrefs.SetInt("Bina0", 0);
            PlayerPrefs.SetInt("Bina1", 0);
            PlayerPrefs.SetInt("Bina2", 0);
            PlayerPrefs.SetInt("Bina3", 0);
            PlayerPrefs.SetInt("Bina4", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
