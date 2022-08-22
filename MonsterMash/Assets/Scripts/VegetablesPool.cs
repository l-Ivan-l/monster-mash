using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablesPool : MonoBehaviour
{
    public static VegetablesPool instance;

    private int turnipsPoolLenght = 12;
    [SerializeField] private GameObject turnipPrefab;
    [SerializeField] private Transform turnipsContainer;
    private List<GameObject> turnipsPool = new List<GameObject>();

    private int eggPlantsPoolLenght = 8;
    [SerializeField] private GameObject eggPlantPrefab;
    [SerializeField] private Transform eggPlantsContainer;
    private List<GameObject> eggPlantsPool = new List<GameObject>();

    private int potatoesPoolLenght = 10;
    [SerializeField] private GameObject potatoPrefab;
    [SerializeField] private Transform potatoesContainer;
    private List<GameObject> potatoesPool = new List<GameObject>();

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
        CreateTurnipsPool();
        CreateEggPlantsPool();
        CreatePotatoesPool();
    }

    void CreateTurnipsPool()
    {
        for (int i = 0; i < turnipsPoolLenght; i++)
        {
            GameObject turnip = Instantiate(turnipPrefab, turnipsContainer);
            turnip.SetActive(false);
            turnipsPool.Add(turnip);
        }
    }

    void CreateEggPlantsPool()
    {
        for (int i = 0; i < eggPlantsPoolLenght; i++)
        {
            GameObject eggPlant = Instantiate(eggPlantPrefab, eggPlantsContainer);
            eggPlant.SetActive(false);
            eggPlantsPool.Add(eggPlant);
        }
    }

    void CreatePotatoesPool()
    {
        for (int i = 0; i < potatoesPoolLenght; i++)
        {
            GameObject potato = Instantiate(potatoPrefab, potatoesContainer);
            potato.SetActive(false);
            potatoesPool.Add(potato);
        }
    }

    //---------------------------------------------------------------------------
    public void SpawnTurnip(Vector3 _position)
    {
        for (int i = 0; i < turnipsPool.Count; i++)
        {
            if (!turnipsPool[i].activeInHierarchy)
            {
                turnipsPool[i].transform.position = _position;
                turnipsPool[i].SetActive(true);
                break;
            }
        }
    }

    public void SpawnEggPlant(Vector3 _position)
    {
        for (int i = 0; i < eggPlantsPool.Count; i++)
        {
            if (!eggPlantsPool[i].activeInHierarchy)
            {
                eggPlantsPool[i].transform.position = _position;
                eggPlantsPool[i].SetActive(true);
                break;
            }
        }
    }

    public void SpawnPotato(Vector3 _position)
    {
        for (int i = 0; i < potatoesPool.Count; i++)
        {
            if (!potatoesPool[i].activeInHierarchy)
            {
                potatoesPool[i].transform.position = _position;
                potatoesPool[i].SetActive(true);
                break;
            }
        }
    }
}
