using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StageController : MonoBehaviour
{
    private Collider stageTrigger;
    public GameObject[] bars;
    public Transform stageSpawn;

    private int wavesLeft;
    [SerializeField]
    private int waveIndex = -1;
    public Transform[] wavesSpawnsContainers;
    private int initVegetablesOnWave;
    private int vegetablesLeft = 0;

    public bool isFinalStage;
    [HideInInspector]public GameObject finalGate;

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
            Transform spawner = wavesSpawnsContainers[waveIndex].GetChild(i);
            switch (spawner.gameObject.tag)
            {
                case "TurnipSpawn":
                    //Spawn turnip
                    VegetablesPool.instance.SpawnTurnip(spawner.position);
                    break;

                case "EggPlantSpawn":
                    VegetablesPool.instance.SpawnEggPlant(spawner.position);
                    break;

                case "PotatoSpawn":
                    VegetablesPool.instance.SpawnPotato(spawner.position);
                    break;
            }
        }
    }

    public void CheckVegetablesLeft()
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

        if(isFinalStage)
        {
            GameController.instance.GameFinished();
            StartCoroutine(OpenFinalGate(GameController.instance.comboAddedClip.length)); //In case there is a combo running.
        }
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

    IEnumerator OpenFinalGate(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        //Open gate
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StageController))]
public class StageControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = target as StageController;

        if(myScript.isFinalStage)
        {
            myScript.finalGate = EditorGUILayout.ObjectField("Final Gate", myScript.finalGate,
            typeof(GameObject), true) as GameObject;
        }
    }
}
#endif
