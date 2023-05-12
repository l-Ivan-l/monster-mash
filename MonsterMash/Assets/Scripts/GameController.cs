using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Cinemachine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [HideInInspector]
    public InputMaster inputMaster;

    public delegate void VegetableDeath();
    public static event VegetableDeath OnVegetableDead;

    private MonsterScript pumpkinManBehavior;
    public GameObject pumpkinMan;
    public GameObject hudPanel;
    public GameObject gameOverPanel;
    private TextMeshProUGUI finalScoreUI;
    private TextMeshProUGUI finalTimeUI;
    private TextMeshProUGUI finalLifesUI;
    private TextMeshProUGUI rankUI;

    public GameObject losePanel;
    private TextMeshProUGUI stageUI;
    private TextMeshProUGUI timeUI;
    private int stageNumber;

    //Score variables
    private int score;
    public TextMeshProUGUI scoreUI;
    private RectTransform scoreUIContainer;
    private Animator scoreAnim;
    public AnimationClip scoreAddedClip;
    public AnimationClip scorePenaltyClip;
    private int currentCombo = 0;
    private IEnumerator comboCoroutine;
    private int comboValue = 50;
    public TextMeshProUGUI comboUI;
    private Animator comboAnim;
    public AnimationClip comboAddedClip;
    public TextMeshProUGUI comboMessage;
    private Animator comboMessageAnim;
    public AnimationClip messageShowClip;

    //Timer variables
    private bool timerActive;
    private float currentTime;
    public TextMeshProUGUI timerUI;

    private StageController currentStage;
    private StageController previousStage;

    private bool gameOver;

    [Header("Camera Fields")]
    public CinemachineVirtualCamera virtualCamera_Gameplay;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    private IEnumerator stopScreenShakeCoroutine;
    private bool screenShakeOn = false;
    public GameObject titleScreenCamera;

    //Stomp Fuel Bar Variables
    public Image fuelBar;
    private Gradient fuelGradient;
    private GradientColorKey[] colorKeys = new GradientColorKey[7];
    private GradientAlphaKey[] alphaKeys = new GradientAlphaKey[1];
    public ParticleSystem fuelParticlesUI;
    private float fuelUIMinEmissionRate = 50f;
    private float fuelUIMaxEmissionRate = 200f;
    private float fuelUIMinYVelocity = 0.1f;
    private float fuelUIMaxYVelocity = 13f;
    public RectTransform stompFuelIndicator;

    //Lifes variables
    public GameObject lifesContainer;
    public GameObject lifeUIPrefab;
    private List<GameObject> lifes = new List<GameObject>();

    public int Score
    {
        get { return score; }
        set
        {
            int tempScore = score;
            score = value;
            if(tempScore < score)
            {
                scoreAnim.Play(scoreAddedClip.name, -1, 0f);
            }
            else
            {
                scoreAnim.Play(scorePenaltyClip.name, -1, 0f);
            }

            if(score < 0)
            {
                score = 0;
            }
            scoreUI.text = score.ToString();
        }
    }

    public float CurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public StageController CurrentStage
    {
        get { return currentStage; }
        set { currentStage = value; }
    }

    public StageController PreviousStage
    {
        get { return previousStage; }
        set { previousStage = value; }
    }

    public List<GameObject> Lifes 
    {
        get{ return lifes; }
        set{ lifes = value; }
    }

    public int StageNumber
    {
        get{ return stageNumber; }
        set{ stageNumber = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        inputMaster = new InputMaster();
        #if UNITY_EDITOR 
        inputMaster.EditorActions.Reset.performed += _ => Reset();
        #endif

        pumpkinManBehavior = pumpkinMan.GetComponent<MonsterScript>();
        comboAnim = comboUI.GetComponent<Animator>();
        comboMessageAnim = comboMessage.GetComponent<Animator>();
        scoreAnim = scoreUI.GetComponent<Animator>();
        scoreUIContainer = scoreUI.gameObject.transform.parent.GetComponent<RectTransform>();

        virtualCameraNoise = virtualCamera_Gameplay.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        SetupLifes(pumpkinManBehavior.initLifes);

        //Until gameplay start
        pumpkinMan.SetActive(false);
        hudPanel.SetActive(false);

        finalScoreUI = gameOverPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        finalTimeUI = gameOverPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        finalLifesUI = gameOverPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        rankUI = gameOverPanel.transform.GetChild(4).GetComponent<TextMeshProUGUI>();

        stageUI = losePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        timeUI = losePanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        fuelGradient = new Gradient();
        colorKeys[0].color = new Color(0.7411765f, 0.2039215862751007f, 0.21568629145622254f);
        colorKeys[1].color = new Color(0.8784314393997192f, 0.6274510025978088f, 0.3529411852359772f);
        colorKeys[2].color = new Color(0.8274510502815247f, 0.46666669845581057f, 0.3019607961177826f);
        colorKeys[3].color = new Color(0.960784375667572f, 0.8705883026123047f, 0.43137258291244509f);
        colorKeys[4].color = new Color(0.7529412508010864f, 0.2352941334247589f, 0.22745099663734437f);
        colorKeys[5].color = new Color(0.9098039865493774f, 0.7176470756530762f, 0.38431376218795779f);
        colorKeys[6].color = new Color(0.7215686440467835f, 0.14509804546833039f, 0.2039215862751007f);
        alphaKeys[0].alpha = 1.0f;
        fuelGradient.SetKeys(colorKeys, alphaKeys);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        gameOver = false;
        timerActive = false;
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        TimerRun();
    }

    void Reset()
    {
        DOTween.KillAll();
        OnVegetableDead -= currentStage.CheckVegetablesLeft;
        inputMaster.EditorActions.Reset.performed -= _ => Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        stageNumber = 1;
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        titleScreenCamera.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pumpkinMan.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        virtualCamera_Gameplay.Follow = pumpkinMan.transform;

        UIAnimationsIn();
        hudPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        timerActive = true;
        pumpkinManBehavior.EnableMovement();
    }

    public void SetupLifes(int _nLifes)
    {
        for(int i = 0; i < lifesContainer.transform.childCount; i++)
        {
            Destroy(lifesContainer.transform.GetChild(i).gameObject); //Destroy previous UI elements that are there for visualization.
        }

        for(int i = 0; i < _nLifes; i++)
        {
            GameObject life = Instantiate(lifeUIPrefab, lifesContainer.transform);
            lifes.Add(life);
        }
    }

    void UIAnimationsIn()
    {
        float tweenSpeed = 0.5f;

        float initialLifeScale = lifes[0].transform.localScale.x;
        foreach(GameObject life in lifes)
        {
            life.transform.localScale = Vector3.zero;
            life.transform.DOScale(initialLifeScale, tweenSpeed);
            life.transform.DORotate(new Vector3(0, 540, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        }

        float realTimerPosition = timerUI.rectTransform.localPosition.y;
        Vector3 timerPos = timerUI.rectTransform.localPosition;
        timerPos.y -= 125f; //Hidden timer position.
        timerUI.rectTransform.localPosition = timerPos;
        timerUI.rectTransform.DOLocalMoveY(realTimerPosition, tweenSpeed, true);

        float realScorePosition = scoreUIContainer.localPosition.y;
        Vector3 scorePos = scoreUIContainer.localPosition;
        scorePos.y += 160f; //Hidden score position.
        scoreUIContainer.localPosition = scorePos;
        scoreUIContainer.DOLocalMoveY(realScorePosition, tweenSpeed, true);

        float realFuelBarPosition = stompFuelIndicator.localPosition.x;
        Vector3 fuelBarPos = stompFuelIndicator.localPosition;
        fuelBarPos.x -= 170f; //Hidden stomp fuel bar position.
        stompFuelIndicator.localPosition = fuelBarPos;
        stompFuelIndicator.DOLocalMoveX(realFuelBarPosition, tweenSpeed, true);

        fuelBar.DOGradientColor(fuelGradient, tweenSpeed).SetLoops(-1, LoopType.Yoyo);
        UIFuelParticlesChange(1f);
    }

    void UIAnimationsOut()
    {
        float tweenSpeed = 0.7f;

        foreach(GameObject life in lifes)
        {
            life.transform.DOScale(0f, tweenSpeed);
        }

        Vector3 timerPos = timerUI.rectTransform.localPosition;
        timerPos.y -= 125f; //Hidden timer position.
        timerUI.rectTransform.DOLocalMoveY(timerPos.y, tweenSpeed, true);

        Vector3 scorePos = scoreUIContainer.localPosition;
        scorePos.y += 160f; //Hidden score position.
        scoreUIContainer.DOLocalMoveY(scorePos.y, tweenSpeed, true);

        Vector3 fuelBarPos = stompFuelIndicator.localPosition;
        fuelBarPos.x -= 170f; //Hidden stomp fuel bar position.
        stompFuelIndicator.DOLocalMoveX(fuelBarPos.x, tweenSpeed, true);
    }

    void UIFuelParticlesChange(float _fuelBarFillValue)
    {
        var emission = fuelParticlesUI.emission;
        emission.rateOverTime = Mathf.Lerp(fuelUIMinEmissionRate, fuelUIMaxEmissionRate, _fuelBarFillValue);
        var velocity = fuelParticlesUI.velocityOverLifetime;
        velocity.y = Mathf.Lerp(fuelUIMinYVelocity, fuelUIMaxYVelocity, _fuelBarFillValue);
    }

    void TimerRun()
    {
        if(timerActive)
        {
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timerUI.text = time.ToString(@"m\:ss");
        }
    }

    public void VegetableDeathEvent()
    {
        AddComboCount();
        if(OnVegetableDead != null)
        {
            OnVegetableDead();
        }
    }

    void AddComboCount()
    {
        if(currentCombo > 0)
        {
            StopCoroutine(comboCoroutine);
        }
        currentCombo++;
        //Debug.Log("Current COMBO: " + currentCombo);
        comboCoroutine = ComboCountdown();
        StartCoroutine(comboCoroutine);
    }

    IEnumerator ComboCountdown()
    {
        //Update UI
        if(currentCombo > 1)
        {
            comboUI.text = "COMBO x" + currentCombo.ToString();
            comboAnim.Play(comboAddedClip.name, -1, 0f);
        }
        yield return new WaitForSeconds(comboAddedClip.length);
        if(currentCombo > 1)
        {
            //Spawn combo details
            int comboScore = currentCombo * comboValue;
            comboMessage.text = currentCombo.ToString() + " COMBO!\nCOMBO\n REWARD!\n +" + comboScore.ToString() + " Score";
            comboMessageAnim.Play(messageShowClip.name);
            //Add combo score
            Score += comboScore;
            //Debug.Log("COMBO x" + currentCombo + "ADDED!");
        }
        currentCombo = 0;
        comboUI.text = "COMBO x" + currentCombo.ToString();
        //Debug.Log("Combo count back to 0");
    } 

    public void ScreenShake(float _duration, float _shakeAmplitude, float _shakeFrequency)
    {
        if(screenShakeOn)
        {
            StopCoroutine(stopScreenShakeCoroutine);
        }

        screenShakeOn = true;
        virtualCameraNoise.m_AmplitudeGain = _shakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = _shakeFrequency;
        stopScreenShakeCoroutine = StopScreenShake(_duration);
        StartCoroutine(stopScreenShakeCoroutine);
    }

    IEnumerator StopScreenShake(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        virtualCameraNoise.m_AmplitudeGain = 0f;
        virtualCameraNoise.m_FrequencyGain = 0f;
        screenShakeOn = false;
    }

    public void GiveStompFuel(float _fuelAmount)
    {
        pumpkinManBehavior.stompFuel += _fuelAmount;
        if(pumpkinManBehavior.stompFuel > pumpkinManBehavior.maxStompFuel)
        {
            pumpkinManBehavior.stompFuel = pumpkinManBehavior.maxStompFuel;
        }
        UpdateStompUI();
    }

    public void UpdateStompUI()
    {
        float fuelValue = pumpkinManBehavior.stompFuel / pumpkinManBehavior.maxStompFuel;
        fuelBar.DOFillAmount(fuelValue, 0.3f);
        UIFuelParticlesChange(fuelValue);
    }

    public void GameFinished()
    {
        timerActive = false;
    }

    public IEnumerator GameOverSequence(GameOverController.Rank _rank)
    {
        //Stop game 
        UIAnimationsOut();
        titleScreenCamera.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        hudPanel.SetActive(false);
        //Show GameOver Panel
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show score
        finalScoreUI.text = "Score: " + score.ToString();
        finalScoreUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show timer
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        finalTimeUI.text = "Time: " + time.ToString(@"m\:ss");
        finalTimeUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show lifes
        finalLifesUI.text = "Lifes: " + pumpkinManBehavior.GetLifes().ToString();
        finalLifesUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show rank
        rankUI.text = "Rank: " + GetRankString(_rank);
        rankUI.gameObject.SetActive(true);
        //Debug.Log("RANK: " + GetRankString(_rank));
    }

    public IEnumerator LoseSequence()
    {
        UIAnimationsOut();
        titleScreenCamera.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        hudPanel.SetActive(false);
        losePanel.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        stageUI.text = "Stage Reached: " + stageNumber.ToString();
        stageUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show timer
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeUI.text = "Time: " + time.ToString(@"m\:ss");
        timeUI.gameObject.SetActive(true);
    }

    string GetRankString(GameOverController.Rank _rank)
    {
        string rankString = "";
        switch(_rank)
        {
            case GameOverController.Rank.A_Minus:
                rankString = "A-";
                break;

            case GameOverController.Rank.A_Plus:
                rankString = "A+";
                break;

            case GameOverController.Rank.B_Minus:
                rankString = "B-";
                break;

            case GameOverController.Rank.B_Plus:
                rankString = "B+";
                break;

            case GameOverController.Rank.C_Minus:
                rankString = "C-";
                break;

            case GameOverController.Rank.C_Plus:
                rankString = "C+";
                break;

            case GameOverController.Rank.D_Minus:
                rankString = "D-";
                break;

            case GameOverController.Rank.D_Plus:
                rankString = "D+";
                break;

            case GameOverController.Rank.S:
                rankString = "S";
                break;
        }

        return rankString;
    }
}
