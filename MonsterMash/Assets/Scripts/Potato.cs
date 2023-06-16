using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Potato : Vegetable
{
    private float moveRate;
    private float minMoveTime = 4.5f;
    private float maxMoveTime = 5.5f;
    private bool canMove;
    private float collisionDetectorRadius = 0.6f;
    private float respawnRadius = 10f;
    public LayerMask groundLayer;
    public LayerMask respawnDetectorLayer;
    private Vector3 checkCollisionGizmoPos = Vector3.zero;
    private GameObject currentFence;

    public AudioClip hideSound;
    public AudioClip resurfaceSound;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 5;
        givesFuel = true;
        fuelAmount = 12f;
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
            moveRate = Random.Range(minMoveTime, maxMoveTime);
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
                    if (Physics.CheckSphere(newPosition, collisionDetectorRadius / 2f, groundLayer))
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
        transform.DOScaleY(0f, 0.2f).OnComplete(()=> transform.localScale = Vector3.zero);
        VFXPool.instance.SpawnDirtVFX(transform.position);
        VFXPool.instance.SpawnHoleVFX(transform.position);
        SoundManager.instance.PlaySoundEffect(hideSound, 0.5f);
    }

    void RespawnEffect()
    {
        Vector3 vegetableScale = transform.localScale;
        vegetableScale.x = originalHeight;
        vegetableScale.z = originalHeight;
        vegetableScale.y = 0f;
        transform.localScale = vegetableScale;
        transform.DOScaleY(originalHeight, 0.2f).OnComplete(()=> vegetableAnim.SetBool("Spin", false));

        VFXPool.instance.SpawnDirtVFX(transform.position);
        SoundManager.instance.PlaySoundEffect(resurfaceSound, 0.5f);
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
            //Debug.Log("Is Outside Stage");
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
