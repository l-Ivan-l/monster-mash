using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Vegetable : MonoBehaviour
{
    protected int life;
    protected int scoreValue;
    protected bool givesFuel;
    protected float fuelAmount;

    protected Rigidbody vegetableBody;

    private bool initialized;

    private void Awake()
    {
        vegetableBody = GetComponent<Rigidbody>();
        initialized = false;
        transform.localEulerAngles = new Vector3(0f, 125f, 0f);
    }

    public virtual void OnEnable()
    {
        if(initialized)
        {
            SpawnEffect();
        }

        if(!initialized)
        {
            initialized = true;
        }
    }

    void SpawnEffect()
    {
        float originalHeight = transform.localScale.y;
        Vector3 vegetableScale = transform.localScale;
        vegetableScale.y = 0f;
        transform.localScale = vegetableScale;
        transform.DOScaleY(originalHeight, 0.15f);

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
        GameController.instance.ScreenShake(0.3f, 0.75f, 1f);
        GameController.instance.Score += scoreValue;
        GameController.instance.VegetableDeathEvent();
        if(givesFuel)
        {
            GameController.instance.GiveStompFuel(fuelAmount);
        }

        VFXPool.instance.SpawnVegetableVFX(transform.position);

        string scoreText = "+" + scoreValue.ToString();
        Vector3 popUpPosition = transform.position;
        popUpPosition.y += 0.5f;
        transform.position = popUpPosition;
        VFXPool.instance.SpawnScorePopUp(popUpPosition, scoreText, Color.white);

        gameObject.SetActive(false);
    }
}
