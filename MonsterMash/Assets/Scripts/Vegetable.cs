using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    protected int life;
    protected int scoreValue;

    protected Rigidbody vegetableBody;

    private bool initialized;

    private void Awake()
    {
        vegetableBody = GetComponent<Rigidbody>();
        initialized = false;
    }

    public virtual void OnEnable()
    {
        if(initialized)
        {
            //Spawn effect
            VFXPool.instance.SpawnInstantiateVFX(transform.position);
        }

        if(!initialized)
        {
            initialized = true;
        }
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
        GameController.instance.ScreenShake(0.3f, 0.75f, 1f);
        GameController.instance.Score += scoreValue;
        GameController.instance.VegetableDeathEvent();

        VFXPool.instance.SpawnVegetableVFX(transform.position);

        string scoreText = "+" + scoreValue.ToString();
        Vector3 popUpPosition = transform.position;
        popUpPosition.y += 0.5f;
        transform.position = popUpPosition;
        VFXPool.instance.SpawnScorePopUp(popUpPosition, scoreText, Color.white);

        gameObject.SetActive(false);
    }
}
