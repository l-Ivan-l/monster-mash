using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    protected int life;

    protected Rigidbody vegetableBody;

    private void Awake()
    {
        vegetableBody = GetComponent<Rigidbody>();
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

    }
}
