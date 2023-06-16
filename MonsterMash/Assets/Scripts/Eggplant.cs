using System.Collections;
using UnityEngine;

public class Eggplant : Vegetable
{
    private float explosionForce = 2000f;
    private float explosionRadius = 15f;
    private Vector3 explosionPosition;
    private float explosionTime = 6f;
    private int explosionPenalty = 50;

    private Material eggplantMaterial;
    public AudioClip beepSound;
    public AudioClip explosionSound;

    public override void Awake()
    {
        base.Awake();

        eggplantMaterial = GetComponent<Renderer>().material;
    }

    void Start()
    {
        scoreValue = 20;
        givesFuel = true;
        fuelAmount = 20f;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        eggplantMaterial.color = Color.white;
        vegetableAnim.speed = 1f;
        explosionPosition = transform.position;
        StartCoroutine(EggplantExplode());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Blink()
    {
        float blinkTime = 0.1f;
        while(gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(blinkTime);
            eggplantMaterial.color = Color.red;
            SoundManager.instance.PlaySoundEffect(beepSound, 0.5f);
            yield return new WaitForSeconds(blinkTime);
            eggplantMaterial.color = Color.white;

            blinkTime -= 0.003f;
            vegetableAnim.speed += 0.5f;
        }
    }

    IEnumerator EggplantExplode()
    {
        float blinkingTime = explosionTime / 3f;
        yield return new WaitForSeconds(explosionTime - blinkingTime);
        StartCoroutine(Blink());
        yield return new WaitForSeconds(blinkingTime);
        SoundManager.instance.PlaySoundEffect(explosionSound, 1f);
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                rb.gameObject.GetComponent<MonsterScript>().onExplosion = true;
                //Debug.Log("Rigidbody on radius: " + rb.gameObject.name);
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 7.5f, ForceMode.Force);
            }
        }

        DeathByExplosion();
    }

    void DeathByExplosion()
    {
        GameController.instance.ScreenShake(0.75f, 2.5f, 2.75f);
        GameController.instance.Score -= explosionPenalty;
        GameController.instance.VegetableDeathEvent();

        VFXPool.instance.SpawnExplosionVFX(transform.position);

        string scoreText = "-" + explosionPenalty.ToString();
        Vector3 popUpPosition = transform.position;
        popUpPosition.y += 0.5f;
        transform.position = popUpPosition;
        VFXPool.instance.SpawnScorePopUp(popUpPosition, scoreText, Color.red);

        gameObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
