using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private Collider stageTrigger;
    public GameObject[] bars;
    public Transform stageSpawn;

    private int wavesLeft;
    public Transform[] wavesSpawns;
    private int initVegetablesOnWave;
    private int vegetablesLeft = 0;

    private void Awake()
    {
        stageTrigger = GetComponent<Collider>();
        wavesLeft = wavesSpawns.Length;
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

        ActivateVegetables();
    }

    void ActivateVegetables()
    {
        wavesLeft -= 1;
        vegetablesLeft += wavesSpawns[wavesLeft].childCount;
    }

    void CheckVegetablesLeft()
    {
        vegetablesLeft -= 1;
    }

    public void StageCleared() //All vegetables defeated
    {
        GameController.OnVegetableDead -= CheckVegetablesLeft;
        //Deactivate bars
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].SetActive(true);
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
