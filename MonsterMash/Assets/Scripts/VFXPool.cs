using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPool : MonoBehaviour
{
    //Impact VFX
    [SerializeField] private GameObject impactVFXPrefab;
    [SerializeField] private Transform impactVFXContainer;
    private int impactVFXPoolLength = 2;
    private List<ParticleSystem> impactVFXPool = new List<ParticleSystem>();
    //Vegetable Explosion VFX
    [SerializeField] private GameObject vegetableVFXPrefab;
    [SerializeField] private Transform vegetableVFXContainer;
    private int vegetableVFXPoolLength = 3;
    private List<ParticleSystem> vegetableVFXPool = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        CreateImpactVFXPool();
        CreateVegetableVFXPool();
    }

    void CreateImpactVFXPool()
    {
        for (int i = 0; i < impactVFXPoolLength; i++)
        {
            ParticleSystem impact = Instantiate(impactVFXPrefab, Vector3.zero, Quaternion.identity, impactVFXContainer).GetComponent<ParticleSystem>();
            Quaternion impactRot = new Quaternion(0f, 0f, 0f, 0f);
            impactRot.eulerAngles = new Vector3(0f, 90f, 0f);
            impact.gameObject.transform.rotation = impactRot;
            impactVFXPool.Add(impact);
        }
    }

    void CreateVegetableVFXPool()
    {
        for (int i = 0; i < vegetableVFXPoolLength; i++)
        {
            ParticleSystem vegExp = Instantiate(vegetableVFXPrefab, Vector3.zero, Quaternion.identity, vegetableVFXContainer).GetComponent<ParticleSystem>();
            Quaternion vegRot = new Quaternion(0f, 0f, 0f, 0f);
            vegRot.eulerAngles = new Vector3(0f, 90f, 0f);
            vegExp.gameObject.transform.rotation = vegRot;
            vegetableVFXPool.Add(vegExp);
        }
    }

    public void SpawnImpactVFX(Vector3 _position)
    {
        for (int i = 0; i < impactVFXPool.Count; i++)
        {
            if (!impactVFXPool[i].isPlaying)
            {
                impactVFXPool[i].transform.position = _position;
                impactVFXPool[i].Play();
                break;
            }
        }
    }

    public void SpawnVegetableVFX(Vector3 _position)
    {
        for (int i = 0; i < vegetableVFXPool.Count; i++)
        {
            if (!vegetableVFXPool[i].isPlaying)
            {
                vegetableVFXPool[i].transform.position = _position;
                vegetableVFXPool[i].Play();
                break;
            }
        }
    }
}
