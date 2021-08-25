using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    protected int life;
    protected int scoreValue;

    protected Rigidbody vegetableBody;

    private void Awake()
    {
        vegetableBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //Spawn effect
        VFXPool.instance.SpawnInstantiateVFX(transform.position);
    }

    public void ApplyDamage()
    {
        life -= 1;
        if(life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameController.instance.Score += scoreValue;
        GameController.instance.VegetableDeathEvent();

        VFXPool.instance.SpawnVegetableVFX(transform.position);
        gameObject.SetActive(false);
    }
}
