using UnityEngine;
using DG.Tweening;

public class Turnip : Vegetable
{
    private Vector3 currentDirection = new Vector3();
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 8;
        givesFuel = true;
        fuelAmount = 18f;
        Vector3 initDir = Random.insideUnitSphere;
        ChangeDirection(initDir.normalized);
        transform.DORotate(new Vector3(0, 540, 0), 0.5f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

    private void FixedUpdate()
    {
        TurnipMovement();
    }

    void TurnipMovement()
    {
        vegetableBody.velocity = new Vector3(currentDirection.x * moveSpeed, vegetableBody.velocity.y, currentDirection.z * moveSpeed); //* Time.deltaTime;
    }

    void ChangeDirection(Vector3 _dir)
    {
        _dir.y = 0f;
        currentDirection = _dir;
        //Debug.Log("Turnip direction: " + currentDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ground"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            ChangeDirection(dir);
        }
    }
}
