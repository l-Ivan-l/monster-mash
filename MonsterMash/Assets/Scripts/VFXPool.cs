using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPool : MonoBehaviour
{
    public static VFXPool instance;
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
    //Spawn VFX
    [SerializeField] private GameObject spawnVFXPrefab;
    [SerializeField] private Transform spawnVFXContainer;
    private int spawnVFXPoolLength = 10;
    private List<ParticleSystem> spawnVFXPool = new List<ParticleSystem>();
    //Explosion VFX
    [SerializeField] private GameObject explosionVFXPrefab;
    [SerializeField] private Transform explosionVFXContainer;
    private int explosionVFXPoolLength = 5;
    private List<ParticleSystem> explosionVFXPool = new List<ParticleSystem>();
    //Score Pop-Up
    [SerializeField] private GameObject scorePopUpPrefab;
    [SerializeField] private Transform scorePopUpContainer;
    private int scorePopUpPoolLenght = 8;
    private List<GameObject> scorePopUpPool = new List<GameObject>();

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
        CreateImpactVFXPool();
        CreateVegetableVFXPool();
        CreateSpawnVFXPool();
        CreateExplosionVFXPool();
        CreateScorePopUpPool();
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

    void CreateSpawnVFXPool()
    {
        for (int i = 0; i < spawnVFXPoolLength; i++)
        {
            ParticleSystem spawn = Instantiate(spawnVFXPrefab, Vector3.zero, Quaternion.identity, spawnVFXContainer).GetComponent<ParticleSystem>();
            Quaternion spawnRot = new Quaternion(0f, 0f, 0f, 0f);
            spawnRot.eulerAngles = new Vector3(0f, 90f, 0f);
            spawn.gameObject.transform.rotation = spawnRot;
            spawnVFXPool.Add(spawn);
        }
    }

    void CreateExplosionVFXPool()
    {
        for(int i = 0; i < explosionVFXPoolLength; i++)
        {
            ParticleSystem explosion = Instantiate(explosionVFXPrefab, Vector3.zero, Quaternion.identity, explosionVFXContainer).GetComponent<ParticleSystem>();
            Quaternion expRot = new Quaternion(0f, 0f, 0f, 0f);
            expRot.eulerAngles = new Vector3(0f, 90f, 0f);
            explosion.gameObject.transform.rotation = expRot;
            explosionVFXPool.Add(explosion);
        }
    }

    void CreateScorePopUpPool()
    {
        for(int i = 0; i < scorePopUpPoolLenght; i++)
        {
            GameObject popUp = Instantiate(scorePopUpPrefab, Vector3.zero, Quaternion.identity, scorePopUpContainer);
            popUp.SetActive(false);
            scorePopUpPool.Add(popUp);
        }
    }
    //---------------------------------------------------------------------------
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

    public void SpawnInstantiateVFX(Vector3 _position)
    {
        for (int i = 0; i < spawnVFXPool.Count; i++)
        {
            if (!spawnVFXPool[i].isPlaying)
            {
                spawnVFXPool[i].transform.position = _position;
                spawnVFXPool[i].Play();
                break;
            }
        }
    }

    public void SpawnExplosionVFX(Vector3 _position)
    {
        for (int i = 0; i < explosionVFXPool.Count; i++)
        {
            if (!explosionVFXPool[i].isPlaying)
            {
                explosionVFXPool[i].transform.position = _position;
                explosionVFXPool[i].Play();
                break;
            }
        }
    }

    public void SpawnScorePopUp(Vector3 _position, string _scoreText, Color _textColor)
    {
        for (int i = 0; i < scorePopUpPool.Count; i++)
        {
            if (!scorePopUpPool[i].activeInHierarchy)
            {
                scorePopUpPool[i].transform.position = _position;
                TextMesh popUpText = scorePopUpPool[i].transform.GetChild(0).GetComponent<TextMesh>();
                popUpText.text = _scoreText;
                popUpText.color = _textColor;
                scorePopUpPool[i].SetActive(true);
                StartCoroutine(DeactivatePopUp(scorePopUpPool[i], 1f));
                break;
            }
        }
    }

    IEnumerator DeactivatePopUp(GameObject _popUp, float _timer)
    {
        yield return new WaitForSeconds(_timer);
        _popUp.SetActive(false);
    }
}
