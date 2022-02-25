using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; // Singleton yapisi icin gerekli ornek

    public GameObject TapToStartPanel, LoosePanel, GamePanel, WinPanel, winScreenEffectObject, winScreenCoinImage, startScreenCoinImage, scoreEffect;
    public Text gamePlayScoreText, winScreenScoreText, levelNoText;

    WaitForSeconds beklemeSuresi = new WaitForSeconds(4f); //sayac sistemi icin gereklidir
    WaitForSeconds beklemeSuresi1 = new WaitForSeconds(.05f); //sayac sistemi icin gereklidir
    WaitForSeconds beklemeSuresi2 = new WaitForSeconds(.015f); //sayac sistemi icin gereklidir
    WaitForSeconds beklemeSuresi3 = new WaitForSeconds(.025f); //sayac sistemi icin gereklidir
    WaitForSeconds beklemeSuresi4 = new WaitForSeconds(.03f); //sayac sistemi icin gereklidir
    WaitForSeconds beklemeSuresi5 = new WaitForSeconds(.75f); //sayac sistemi icin gereklidir


    [Header("ScoreAyariIcinGereklidir")]
    private int oncekiLevelScore;
    private int Score;
    [SerializeField] Slider scoreDoldurucu;
    [SerializeField] GameObject[] ScoreYorumYazisi;
    [SerializeField] GameObject[] sonradanAktiflestirilecekler;

    // singleton yapisi burada kuruluyor.
    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);

        if (!PlayerPrefs.HasKey("Score"))
        {
            ScoreSifirla();

        }
        else
        {
            oncekiLevelScore = PlayerPrefs.GetInt("Score");
            Score = oncekiLevelScore;
        }
    }

    private void Start()
    {
        StartUI();
    }

    private void ScoreSifirla()
    {
        PlayerPrefs.SetInt("Score", 0);
        oncekiLevelScore = 0;
        Score = 0;
    }


    public void ScoreArtir(int gelenSayi)    //ArabayaDoldurucu icerisinden geliyor
    {
        Score += gelenSayi;
    }

    private void ScoreKayitEt() //NextLevelden geliyor
    {
        PlayerPrefs.SetInt("Score", Score);
    }


    IEnumerator ScoreArtir()  //Win
    {
        yield return beklemeSuresi5;
        while (Score >= oncekiLevelScore)
        {
            oncekiLevelScore += 1;
            scoreDoldurucu.value = oncekiLevelScore;
            yield return new WaitForSeconds(.006f);
        }
    }


    // Oyun ilk acildiginda calisacak olan ui fonksiyonu. 
    public void StartUI()
    {
        ActivateTapToStartScreen();
    }

    /// <summary>
    /// Level numarasini ui kisminda degistirmek icin fonksiyon. Parametre olarak level numarasi aliyor.
    /// </summary>
    /// <param name="levelNo">UI ekranina yazilmak istenen Level numarasý</param>
    public void SetLevelText(int levelNo)
    {
        levelNoText.text = "Level " + levelNo.ToString();
    }

    // TAPTOSTART TUSUNA BASILDISINDA  --- GIRIS EKRANINDA VE LEVEL BASLARINDA
    public void TapToStartButtonClick()
    {
        GameObject.FindWithTag("Player").GetComponent<AnimationController>().KosuAktif();



        GameController.instance.isContinue = true;
        //PlayerController.instance.SetArmForGaming();
        TapToStartPanel.SetActive(false);
        GamePanel.SetActive(true);
        SetLevelText(LevelController.instance.totalLevelNo);
        SetGamePlayScoreText();

    }

    // RESTART TUSUNA BASILDISINDA  --- LOOSE EKRANINDA
    public void RestartButtonClick()
    {
        //araba sayýsý ve esya sayisini sifirla
        //kapilardaki meshleri tekrar ayarla

        GamePanel.SetActive(false);
        LoosePanel.SetActive(false);
        TapToStartPanel.SetActive(true);
        LevelController.instance.RestartLevelEvents();
        SetTapToStartScoreText();
    }


    // NEXT LEVEL TUSUNA BASILDIGINDA... WIN EKRANINDAKI BUTON
    public void NextLevelButtonClick()
    {
        //araba sayýsý ve esya sayisini sifirla
        if (LevelController.bolumunIsmi == "Bolum3")
        {
            ScoreSifirla();
            for (int i = 0; i < ScoreYorumYazisi.Length; i++)
            {
                ScoreYorumYazisi[i].SetActive(false);
            }
        }

        if (LevelController.bolumunIsmi == "Bolum1")
        {
            GameObject.FindWithTag("BuildingController").GetComponent<BinaOzellikleri>().digerBolumObjeSayisiBolum1();
        }
        else if (LevelController.bolumunIsmi == "Bolum2")
        {
            GameObject.FindWithTag("BuildingController").GetComponent<BinaOzellikleri>().digerBolumObjeSayisiBolum2();
        }

        ScoreKayitEt();
        SetTapToStartScoreText();
        TapToStartPanel.SetActive(true);
        WinPanel.SetActive(false);
        GamePanel.SetActive(false);
        LevelController.instance.NextLevelEvents();
    }


    /// <summary>
    /// Bu fonksiyon gameplay ekranindaki score textini gunceller.
    /// </summary>
    public void SetGamePlayScoreText()
    {
        gamePlayScoreText.text = PlayerPrefs.GetInt("totalScore").ToString();
    }


    /// <summary>
    /// Bu fonksiyon totalScore un yazilmasi gereken textleri gunceller.
    /// </summary>
    public void SetTapToStartScoreText()
    {
     //   tapToStartScoreText.text = PlayerPrefs.GetInt("totalScore").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen de geçerli level scoreunun yazildigi texti gunceller.
    /// </summary>
    public void WinScreenScore()
    {
        winScreenScoreText.text = GameController.instance.score.ToString();
    }

    /// <summary>
    /// Bu fonksiyon totalElmas sayilarinin yazildigi textleri gunceller.
    /// </summary>
    public void SetTotalElmasText()
    {
     //   totalElmasText.text = PlayerPrefs.GetInt("totalElmas").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen ekranini acar.
    /// </summary>
    public void ActivateWinScreen()
    {
        // GamePanel.SetActive(false);

        StartCoroutine(WinScreenDelay());
    }

    IEnumerator WinScreenDelay()
    {
        //WinPanel.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            ScoreYorumYazisi[i].SetActive(false);
        }

        if (LevelController.bolumunIsmi == "Bolum1")
        {
            if (Score < 60)
            {
                ScoreYorumYazisi[0].SetActive(true);
            }
            else if (Score >= 60 && Score < 75)
            {
                ScoreYorumYazisi[1].SetActive(true);
            }
            else if (Score >= 75)
            {
                ScoreYorumYazisi[2].SetActive(true);
            }
        }
        else if (LevelController.bolumunIsmi == "Bolum2")
        {
            if (Score < 120)
            {
                ScoreYorumYazisi[0].SetActive(true);
            }
            else if (Score >= 120 && Score < 150)
            {
                ScoreYorumYazisi[1].SetActive(true);
            }
            else if (Score >= 150)
            {
                ScoreYorumYazisi[2].SetActive(true);
            }
        }
        else if (LevelController.bolumunIsmi == "Bolum3")
        {
            if (Score < 150)
            {
                ScoreYorumYazisi[0].SetActive(true);
            }
            else if (Score >= 150 && Score < 225)
            {
                ScoreYorumYazisi[1].SetActive(true);
            }
            else if (Score >= 225)
            {
                ScoreYorumYazisi[2].SetActive(true);
            }
        }

        int sayac = 0;
        while (sayac < GameController.instance.score)
        {
            sayac++;
            if (sayac % 2 == 0)
            {
                GameObject effectObj = Instantiate(winScreenEffectObject, new Vector3(144, 400, 0), Quaternion.identity, winScreenCoinImage.transform);
                effectObj.transform.localPosition = new Vector3(144, 300, 0);
                effectObj.transform.localRotation = Quaternion.Euler(0, 0, winScreenCoinImage.transform.localRotation.z);
                effectObj.GetComponent<Image>().sprite = winScreenCoinImage.GetComponent<Image>().sprite;
                effectObj.transform.localScale = Vector3.one * .2f;
                StartCoroutine(WinScreenEffect(effectObj));
            }
            winScreenScoreText.text = sayac.ToString();
            yield return beklemeSuresi1; //.05f
        }

        yield return beklemeSuresi; //3f
        if(LevelController.bolumunIsmi == "Bolum3")
        {
            StartCoroutine(ScoreArtir());
            for (int i = 0; i < sonradanAktiflestirilecekler.Length; i++)
            {
                sonradanAktiflestirilecekler[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < sonradanAktiflestirilecekler.Length; i++)
            {
                sonradanAktiflestirilecekler[i].SetActive(false);
            }
        }
      
        GamePanel.SetActive(false);
        WinPanel.SetActive(true);
        winScreenScoreText.text = "0";

    }

    IEnumerator WinScreenEffect(GameObject effectObj)
    {
        float sayac = 0;
        float scale = 0;
        while (Vector2.Distance(effectObj.transform.position, winScreenCoinImage.transform.position) > 0.05f)
        {
            effectObj.transform.position = Vector2.Lerp(effectObj.transform.position, winScreenCoinImage.transform.position, sayac);
            scale = Mathf.Lerp(effectObj.transform.localScale.x, winScreenCoinImage.transform.localScale.x, sayac);
            effectObj.transform.localScale = Vector3.one * scale;
            sayac += .02f;
            yield return beklemeSuresi2;  //.015f
        }
        Destroy(effectObj);
    }

   

    IEnumerator StartScreenCoinsDissolve(GameObject obj)
    {
        Color tempColor = obj.GetComponent<Image>().color;
        while (obj.transform.localScale.x > .2f)
        {
            obj.transform.localScale = new Vector3(obj.transform.localScale.x - .05f, obj.transform.localScale.y - .05f, obj.transform.localScale.z - .05f);
            tempColor.a = tempColor.a - .05f;
            obj.GetComponent<Image>().color = tempColor;
            yield return beklemeSuresi4; //.03f
        }
        Destroy(obj);
    }

    /// <summary>
    /// Bu fonksiyon loose secreeni acar. 
    /// </summary>
    public void ActivateLooseScreen()
    {
        GamePanel.SetActive(false);
        LoosePanel.SetActive(true);
    }


    /// <summary>
    /// Bu fonksiyon gamescreeni acar.
    /// </summary>
    public void ActivateGameScreen()
    {
        GamePanel.SetActive(true);
        TapToStartPanel.SetActive(false);
        SetGamePlayScoreText();
    }

    /// <summary>
    /// Bu fonksiyon taptostartscreen i acar.
    /// </summary>
    public void ActivateTapToStartScreen()
    {
        TapToStartPanel.SetActive(true);
        WinPanel.SetActive(false);
        LoosePanel.SetActive(false);
        GamePanel.SetActive(false);
    }
}
