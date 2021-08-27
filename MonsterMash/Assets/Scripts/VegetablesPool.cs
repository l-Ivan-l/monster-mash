using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablesPool : MonoBehaviour
{
    public static VegetablesPool instance;

    [SerializeField] private Transform turnipsContainer;
    private List<GameObject> turnipsPool = new List<GameObject>();

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
    }

    void CreateTurnipsPool()
    {
        for (int i = 0; i < turnipsContainer.childCount; i++)
        {
            GameObject turnip = turnipsContainer.GetChild(i).gameObject;
            turnipsPool.Add(turnip);
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
}
