using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Potato : Vegetable
{
    private float moveRate = 5f;
    private bool canMove;
    private float collisionDetectorRadius = 0.6f;
    private float respawnRadius = 10f;
    public LayerMask groundLayer;
    public LayerMask respawnDetectorLayer;
    private Vector3 checkCollisionGizmoPos = Vector3.zero;
    private GameObject currentFence;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 5;
        givesFuel = true;
        fuelAmount = 7f;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        canMove = true;
        StartCoroutine(ChangePosition());
    }

    private void OnDisable()
    {
        canMove = false;
        StopAllCoroutines();
    }

    public void SetCurrentFence(GameObject fence)
    {
        currentFence = fence;
    }

    IEnumerator ChangePosition()
    {
        while(canMove)
        {
            yield return new WaitForSeconds(moveRate);
            HideEffect();
            yield return new WaitForSeconds(0.75f);
            Vector3 newPosition = GetRandomPosition();
            checkCollisionGizmoPos = newPosition;
            //Debug.Log("Potato new position: " + newPosition.ToString());
            bool posFound = false;
            while(!posFound)
            {
                if(!IsOutsideStage(newPosition.z))
                {
                    if (Physics.CheckSphere(newPosition, collisionDetectorRadius, groundLayer))
                    {
                        if (!Physics.CheckSphere(newPosition, collisionDetectorRadius, respawnDetectorLayer))
                        {
                            posFound = true;
                            transform.position = newPosition;
                            RespawnEffect();
                        }
                        else 
                        {
                            newPosition = GetRandomPosition();
                        }
                    }
                    else 
                    {
                        newPosition = GetRandomPosition();
                    }
                }
                else 
                {
                    newPosition = GetRandomPosition();
                }
                yield return null;
            }
        }
    }

    void HideEffect()
    {
        vegetableAnim.SetBool("Spin", true);
        transform.DOScaleY(0f, 0.2f);
        VFXPool.instance.SpawnDirtVFX(transform.position);
        VFXPool.instance.SpawnHoleVFX(transform.position);
    }

    void RespawnEffect()
    {
        Vector3 vegetableScale = transform.localScale;
        vegetableScale.y = 0f;
        transform.localScale = vegetableScale;
        transform.DOScaleY(originalHeight, 0.2f).OnComplete(()=> vegetableAnim.SetBool("Spin", false));

        VFXPool.instance.SpawnDirtVFX(transform.position);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x + Random.insideUnitSphere.x * respawnRadius, 
            transform.position.y, transform.position.z + Random.insideUnitSphere.z * respawnRadius);
    }

    public bool IsOutsideStage(float potentialPosZ)
    {
        if(potentialPosZ > currentFence.transform.position.z)
        {
            Debug.Log("Is Outside Stage");
            return true;
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        // Display the collision detector radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkCollisionGizmoPos, collisionDetectorRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, respawnRadius);
    }
}
