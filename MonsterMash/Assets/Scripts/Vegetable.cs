using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    protected int life;

    protected Rigidbody vegetableBody;
    private VFXPool vfx;

    private void Awake()
    {
        vegetableBody = GetComponent<Rigidbody>();
        vfx = GameObject.FindObjectOfType<VFXPool>();
    }

    private void OnEnable()
    {
        //Spawn effect
        vfx.SpawnInstantiateVFX(transform.position);
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
        vfx.SpawnVegetableVFX(transform.position);
        gameObject.SetActive(false);
    }
}
