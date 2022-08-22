using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggplant : Vegetable
{
    private float explosionForce = 2000f;
    private float explosionRadius = 15f;
    private Vector3 explosionPosition;
    private float explosionTime = 5f;
    private int explosionPenalty = 50;

    void Start()
    {
        life = 1;
        scoreValue = 20;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        explosionPosition = transform.position;
        StartCoroutine(EggplantExplode());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator EggplantExplode()
    {
        yield return new WaitForSeconds(explosionTime);
        Debug.Log("EXPLOSION!");

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                rb.gameObject.GetComponent<MonsterScript>().onExplosion = true;
                Debug.Log("Rigidbody on radius: " + rb.gameObject.name);
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
