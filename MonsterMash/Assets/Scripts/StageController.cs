using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private Collider stageTrigger;
    public GameObject[] bars;
    public Transform stageSpawn;

    private int wavesLeft;
    private int waveIndex = -1;
    public Transform[] wavesSpawnsContainers;
    private int initVegetablesOnWave;
    private int vegetablesLeft = 0;

    private void Awake()
    {
        stageTrigger = GetComponent<Collider>();
        wavesLeft = wavesSpawnsContainers.Length;
    }

    void StageActive()
    {
        Debug.Log(gameObject.name + " Active");
        stageTrigger.enabled = false;
        GameController.instance.CurrentStage = this;
        GameController.OnVegetableDead += CheckVegetablesLeft;
        //Activate bars
        for(int i = 0; i < bars.Length; i++)
        {
            bars[i].SetActive(true);
        }

        Invoke("ActivateVegetables", 0.5f);
    }

    void ActivateVegetables()
    {
        wavesLeft -= 1;
        waveIndex++;
        vegetablesLeft += wavesSpawnsContainers[waveIndex].childCount;
        initVegetablesOnWave = vegetablesLeft;

        for (int i = 0; i < wavesSpawnsContainers[waveIndex].childCount; i++)
        {
            if(wavesSpawnsContainers[waveIndex].GetChild(i).CompareTag("TurnipSpawn"))
            {
                //Spawn turnip
                VegetablesPool.instance.SpawnTurnip(wavesSpawnsContainers[waveIndex].GetChild(i).position);
            }
        }
    }

    void CheckVegetablesLeft()
    {
        vegetablesLeft -= 1;
        if(wavesLeft == 0 && vegetablesLeft == 0)
        {
            StageCleared();
        }
        else if(Mathf.RoundToInt(initVegetablesOnWave / 2) == vegetablesLeft && wavesLeft > 0)
        {
            ActivateVegetables();
        }
    }

    public void StageCleared() //All vegetables defeated
    {
        GameController.OnVegetableDead -= CheckVegetablesLeft;
        //Deactivate bars
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StageActive();
        }
    }
}
