using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElephantSDK;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public int levelNo, tempLevelNo, totalLevelNo; // totallevelno tum leveller bitip random level gelmeye baslayinca kullaniliyor
    public List<GameObject> levels = new List<GameObject>();
    private GameObject currentLevelObj;

    public static string bolumunIsmi;  //Onceki level ismini çekerken gereklidir


    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    private void Start()
    {
        totalLevelNo = PlayerPrefs.GetInt("level");
        if (totalLevelNo == 0)
        {
            totalLevelNo = 1;
            levelNo = 1;
            PlayerPrefs.SetInt("level", totalLevelNo);
        }
        UIController.instance.SetLevelText(totalLevelNo);
        LevelStartingEvents();
    }


    /// <summary>
    /// Bu fonksiyon level nuarasini bir artirir.
    /// </summary>
    public void IncreaseLevelNo()
    {
        tempLevelNo = levelNo;
        totalLevelNo++;
        PlayerPrefs.SetInt("level", totalLevelNo);
        UIController.instance.SetLevelText(totalLevelNo);


    }

    /// <summary>
    /// Bu fonksiyon oyun ilk acildiginda veya nextlevelde tetiklenir.
    /// </summary>
    public void LevelStartingEvents()
    {
        if (totalLevelNo > levels.Count)
        {
            levelNo = Random.Range(1, levels.Count + 1);
            if (levelNo == tempLevelNo) levelNo = Random.Range(1, levels.Count + 1);
        }
        else
        {
            levelNo = totalLevelNo;
        }
        UIController.instance.SetLevelText(totalLevelNo);
        currentLevelObj = Instantiate(levels[levelNo - 1], Vector3.zero, Quaternion.identity);
        Elephant.LevelStarted(totalLevelNo);

        Debug.Log(PlayerPrefs.GetInt("level").ToString() + PlayerPrefs.GetString("OncekiLevelBolumIsmi"));

        if (PlayerPrefs.GetInt("level") == 1)
        {
            bolumunIsmi = "Bolum1";
        }

        if (PlayerPrefs.GetInt("level") > 1)
        {
            if (PlayerPrefs.GetInt("level") % 3 == 1)
            {
                if (Random.Range(0, 2) == 0)
                {
                    bolumunIsmi = "Bolum1";
                }
                else
                {
                    bolumunIsmi = "Bolum2";
                }
                PlayerPrefs.SetInt("OrtancaBolumKararlastirildi", 0);      //Ortanca bölümün rastgele gelmesi için ayarlanmiþtir
            }
            else if (PlayerPrefs.GetInt("level") % 3 == 2)
            {
                if(PlayerPrefs.GetInt("OrtancaBolumKararlastirildi") == 0)
                {
                    if (PlayerPrefs.GetString("OncekiLevelBolumIsmi") == "Bolum2")
                    {
                        bolumunIsmi = "Bolum1";
                    }
                    else if (PlayerPrefs.GetString("OncekiLevelBolumIsmi") == "Bolum1")
                    {
                        bolumunIsmi = "Bolum2";
                    }
                    PlayerPrefs.SetInt("OrtancaBolumKararlastirildi", 1);
                }
            }
            else if (PlayerPrefs.GetInt("level") % 3 == 0)
            {
                bolumunIsmi = "Bolum3";
            }
        }

        PlayerPrefs.SetString("OncekiLevelBolumIsmi", bolumunIsmi);
        GameObject.FindWithTag("KarakterPaketi").transform.position = Vector3.zero;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraMovement>().KameraOyunBasýKontrol();
        GameObject.FindWithTag("Arabalar").GetComponent<ArabayaDoldurucu>().TekrarBaslat();
        Debug.Log("Bölümün ismi: " + bolumunIsmi);

    }

    /// <summary>
    /// Bu fonksiyon nextlevel butonuna basildiginda tetiklenir. UIControlden tetikleniyor.
    /// </summary>
    public void NextLevelEvents()
    {
        Elephant.LevelCompleted(totalLevelNo);
        Destroy(currentLevelObj);
        IncreaseLevelNo();
        LevelStartingEvents();
        PlayerController.instance.StartingEvents();
    }

    /// <summary>
    /// Bu fonksiyon RestartLevel butonuna basildiginda tetiklenir. UIControlden tetikleniyor.
    /// </summary>
    public void RestartLevelEvents()
    {
        Elephant.LevelFailed(totalLevelNo);
        PlayerController.instance.StartingEvents();
    }
}
