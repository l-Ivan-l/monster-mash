using System.Collections;
using UnityEngine;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StageController : MonoBehaviour
{
    private Collider stageTrigger;
    public GameObject fence;
    public Transform stageSpawn;
    private Vector3 barInitScale;
    private float barsVelocity = 0.1f;
    private float barsDelay = 0.05f;
    private Collider fenceCollider;
    private GameObject[] fenceBars;

    private int wavesLeft;
    [SerializeField]
    private int waveIndex = -1;
    public Transform[] wavesSpawnsContainers;
    private int initVegetablesOnWave;
    private int vegetablesLeft = 0;

    public bool isFinalStage;
    [HideInInspector]public GameObject finalGate;
    [HideInInspector]public AudioClip gateOpenSound;
    public AudioClip fenceBarUpSound;
    public AudioClip spawnSound;

    private StagesOptimization stagesOptimization;

    private void Awake()
    {
        stagesOptimization = transform.parent.gameObject.GetComponent<StagesOptimization>();
        stageTrigger = GetComponent<Collider>();
        wavesLeft = wavesSpawnsContainers.Length;
        barInitScale = fence.transform.GetChild(0).localScale;
        InitializeFence();
    }

    void StageActive()
    {
        //Debug.Log(gameObject.name + " Active");
        stageTrigger.enabled = false;
        GameController.instance.CurrentStage = this;
        GameController.OnVegetableDead += CheckVegetablesLeft;
        stagesOptimization.OptimizeScene(this);
        if(GameController.instance.PreviousStage != null)
        {
            StartCoroutine(GameController.instance.PreviousStage.FenceUp());
        }
        //Activate fence
        StartCoroutine(FenceUp());

        Invoke("ActivateVegetables", 0.5f);
    }

    void InitializeFence()
    {
        foreach(GameObject bar in GetFenceBars())
        {
            Vector3 initScale = bar.transform.localScale;
            initScale.y = 0f;
            bar.transform.localScale = initScale;
        }
        fenceCollider = fence.GetComponent<Collider>();
        fenceCollider.enabled = false;
    }

    GameObject[] GetFenceBars()
    {
        fenceBars = new GameObject[fence.transform.childCount];
        for(int i = 0; i < fence.transform.childCount; i++)
        {
            fenceBars[i] = fence.transform.GetChild(i).gameObject;
        }
        return fenceBars;
    }

    public IEnumerator FenceUp()
    {
        fenceCollider.enabled = true;
        int soundCheck = 2;
        foreach(GameObject bar in GetFenceBars())
        {
            if(soundCheck == 2) //Every 2 bars
            {
                soundCheck = 0;
                SoundManager.instance.PlayAmbienceSoundEffect(fenceBarUpSound, 0.5f);
            }
            bar.transform.DOScaleY(barInitScale.y, barsVelocity);
            soundCheck++;
            yield return new WaitForSeconds(barsDelay);
        }
    }

    IEnumerator FenceDown()
    {
        int soundCheck = 2;
        foreach(GameObject bar in GetFenceBars())
        {
            if(soundCheck == 2) //Every 2 bars
            {
                soundCheck = 0;
                SoundManager.instance.PlayAmbienceSoundEffect(fenceBarUpSound, 0.5f);
            }
            bar.transform.DOScaleY(0f, barsVelocity);
            soundCheck++;
            yield return new WaitForSeconds(barsDelay);
        }
        fenceCollider.enabled = false;
    }

    void ActivateVegetables()
    {
        wavesLeft -= 1;
        waveIndex++;
        vegetablesLeft += wavesSpawnsContainers[waveIndex].childCount;
        initVegetablesOnWave = vegetablesLeft;
        SoundManager.instance.PlayAmbienceSoundEffect(spawnSound, 1f);

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
                    VegetablesPool.instance.SpawnPotato(spawner.position, fence);
                    break;

                case "PumpkinSpawn":
                    VegetablesPool.instance.SpawnPumpkin(spawner.position);
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
        GameController.instance.PreviousStage = this;

        if(isFinalStage)
        {
            GameController.instance.GameFinished();
            StartCoroutine(OpenFinalGate(GameController.instance.comboAddedClip.length)); //In case there is a combo running.
        }
        else 
        {
            GameController.instance.StageNumber++;
            //Deactivate fence
            StartCoroutine(FenceDown());
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
        SoundManager.instance.PlayAmbienceSoundEffect(gateOpenSound, 1f);
        finalGate.GetComponent<Animator>().enabled = true;
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
            myScript.gateOpenSound = EditorGUILayout.ObjectField("Gate Open Sound", myScript.gateOpenSound,
            typeof(AudioClip), true) as AudioClip;
        }
    }
}
#endif
