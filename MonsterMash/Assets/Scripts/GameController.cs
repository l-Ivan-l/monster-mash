using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public delegate void VegetableDeath();
    public static event VegetableDeath OnVegetableDead;

    public GameObject pumpkinMan;
    public GameObject hudPanel;
    public GameObject gameOverPanel;
    private TextMeshProUGUI finalScoreUI;
    private TextMeshProUGUI finalTimeUI;
    private TextMeshProUGUI finalLifesUI;
    private TextMeshProUGUI rankUI;

    //Score variables
    private int score;
    public TextMeshProUGUI scoreUI;
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

    private bool gameOver;

    [Header("Camera Fields")]
    public CinemachineVirtualCamera virtualCamera_Gameplay;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    private IEnumerator stopScreenShakeCoroutine;
    private bool screenShakeOn = false;
    public GameObject titleScreenCamera;

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

        comboAnim = comboUI.GetComponent<Animator>();
        comboMessageAnim = comboMessage.GetComponent<Animator>();
        scoreAnim = scoreUI.GetComponent<Animator>();

        virtualCameraNoise = virtualCamera_Gameplay.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        //Until gameplay start
        pumpkinMan.SetActive(false);
        hudPanel.SetActive(false);

        finalScoreUI = gameOverPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        finalTimeUI = gameOverPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        finalLifesUI = gameOverPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        rankUI = gameOverPanel.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        gameOver = false;
        timerActive = false;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        TimerRun();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        titleScreenCamera.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        pumpkinMan.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        virtualCamera_Gameplay.Follow = pumpkinMan.transform;
        hudPanel.SetActive(true);
        timerActive = true;
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

    public void GameFinished()
    {
        timerActive = false;
    }

    public IEnumerator GameOverSequence(GameOverController.Rank _rank)
    {
        //Stop game 
        hudPanel.SetActive(false);
        titleScreenCamera.SetActive(true);
        yield return new WaitForSeconds(1.5f);
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
        finalLifesUI.text = "Lifes: " + pumpkinMan.GetComponent<MonsterScript>().GetLifes().ToString();
        finalLifesUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Show rank
        rankUI.text = "Rank: " + GetRankString(_rank);
        rankUI.gameObject.SetActive(true);
        //Debug.Log("RANK: " + GetRankString(_rank));
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
