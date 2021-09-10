using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggplant : Vegetable
{
    private float explosionForce = 500f;
    private float explosionRadius = 15f;
    private Vector3 explosionPosition;

    void Start()
    {
        life = 1;
        scoreValue = 20;
    }

    public override void OnEnable()
    {
        //base.OnEnable();

        explosionPosition = transform.position;
        StartCoroutine(EggplantExplode());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator EggplantExplode()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("EXPLOSION!");

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                rb.gameObject.GetComponent<MonsterScript>().onExplosion = true;
                Debug.Log("Rigidbody on radius: " + rb.gameObject.name);
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 0.0f, ForceMode.Force);
                ApplyDamage();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
