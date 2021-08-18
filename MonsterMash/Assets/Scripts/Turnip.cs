using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnip : Vegetable
{
    private Vector3 currentDirection = new Vector3();
    private float moveSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        Vector3 initDir = Random.insideUnitSphere;
        ChangeDirection(initDir.normalized);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Turnip direction: " + currentDirection);
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
