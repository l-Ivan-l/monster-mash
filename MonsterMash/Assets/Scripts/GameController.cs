using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public delegate void VegetableDeath();
    public static event VegetableDeath OnVegetableDead;

    //Score variables
    private int score;
    public TextMeshProUGUI scoreUI;

    //Timer variables
    private bool timerActive;
    private float currentTime;
    public TextMeshProUGUI timerUI;

    private StageController currentStage;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreUI.text = score.ToString();
        }
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
    }


    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerRun();
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
        if(OnVegetableDead != null)
        {
            OnVegetableDead();
        }
    }
}
