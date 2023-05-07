using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    //Dirt VFX
    [SerializeField] private GameObject dirtVFXPrefab;
    [SerializeField] private Transform dirtVFXContainer;
    private int dirtVFXPoolLength = 7;
    private List<ParticleSystem> dirtVFXPool = new List<ParticleSystem>();
    //Hole VFX
    [SerializeField] private GameObject holeVFXPrefab;
    [SerializeField] private Transform holeVFXContainer;
    private int holeVFXPoolLength = 10;
    private List<GameObject> holeVFXPool = new List<GameObject>();
    private Vector3 holeOriginalScale;

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
        CreateDirtVFXPool();
        CreateHoleVFXPool();
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

    void CreateDirtVFXPool()
    {
        for (int i = 0; i < dirtVFXPoolLength; i++)
        {
            ParticleSystem dirt = Instantiate(dirtVFXPrefab, Vector3.zero, Quaternion.identity, dirtVFXContainer).GetComponent<ParticleSystem>();
            Quaternion dirtRot = new Quaternion(0f, 0f, 0f, 0f);
            dirtRot.eulerAngles = new Vector3(0f, 90f, 0f);
            dirt.gameObject.transform.rotation = dirtRot;
            dirtVFXPool.Add(dirt);
        }
    }

    void CreateHoleVFXPool()
    {
        for (int i = 0; i < holeVFXPoolLength; i++)
        {
            GameObject hole = Instantiate(holeVFXPrefab, Vector3.zero, Quaternion.identity, holeVFXContainer);
            hole.SetActive(false);
            holeVFXPool.Add(hole);
        }
        holeOriginalScale = holeVFXPrefab.transform.localScale;
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

    public void SpawnDirtVFX(Vector3 _position)
    {
        for (int i = 0; i < dirtVFXPool.Count; i++)
        {
            if (!dirtVFXPool[i].isPlaying)
            {
                dirtVFXPool[i].transform.position = _position;
                dirtVFXPool[i].Play();
                break;
            }
        }
    }

    public void SpawnHoleVFX(Vector3 _position)
    {
        for (int i = 0; i < holeVFXPool.Count; i++)
        {
            if (!holeVFXPool[i].activeInHierarchy)
            {
                _position.y += 0.05f;
                holeVFXPool[i].transform.position = _position;
                Quaternion holeRot = new Quaternion(0f, 0f, 0f, 0f);
                holeRot.eulerAngles = new Vector3(0f, Random.Range(0f, 360f), 0f);
                holeVFXPool[i].transform.rotation = holeRot;
                holeVFXPool[i].SetActive(true);
                HoleSpawnEffect(holeVFXPool[i]);
                StartCoroutine(RestoreHole(holeVFXPool[i]));
                break;
            }
        }
    }

    void HoleSpawnEffect(GameObject _hole)
    {
        _hole.transform.localScale = Vector3.zero;
        _hole.transform.DOScale(holeOriginalScale, 0.25f);
    }

    void HoleHideEffect(GameObject _hole)
    {
        _hole.transform.DOScale(Vector3.zero, 1.5f);
    }

    IEnumerator RestoreHole(GameObject _hole)
    {
        yield return new WaitForSeconds(1f);
        HoleHideEffect(_hole);
        yield return new WaitForSeconds(1.6f);
        _hole.SetActive(false);
    }

    IEnumerator DeactivatePopUp(GameObject _popUp, float _timer)
    {
        yield return new WaitForSeconds(_timer);
        _popUp.SetActive(false);
    }
}
