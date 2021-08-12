using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private InputMaster inputMaster;

    //Movement variables
    private Rigidbody monsterBody;
    public float moveSpeed = 5f;
    private Vector3 inputDirection;
    private Vector3 forwardDir;
    private Vector3 rightDir;
    private Vector3 movementDirection;
    private Vector3 turnVelocity = Vector3.zero;
    private float turnSmoothDamp = 0.05f;

    //Jump variables
    [SerializeField]
    private bool onGround;
    public LayerMask groundLayer;
    public Vector3 contactOffset;
    public float contactRadius;
    public float jumpForce = 7f;
    public float fallMultiplier = 2.5f;

    //Spring variables
    public Transform pogo;
    private float minSpringDistance = -0.185f;
    private float maxSpringDistance = 0.18f;
    private float springSmoothDamp = 0.02f;
    private Vector3 springVelocity = Vector3.zero;

    private void Awake()
    {
        SetUpInputs();
        monsterBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;

        forwardDir = Camera.main.transform.forward;
        forwardDir.y = 0;
        forwardDir = Vector3.Normalize(forwardDir);
        rightDir = Quaternion.Euler(new Vector3(0, 90, 0)) * forwardDir;
    }

    // Update is called once per frame
    void Update()
    {
        InputProcessing();
        MonsterJumpPhysics();
        PogoSpringPhysics();
    }

    private void FixedUpdate()
    {
        MonsterMovement();
        CheckIfMonsterGrounded();
    }

    void SetUpInputs()
    {
        inputMaster = new InputMaster();
    }

    void InputProcessing()
    {
        inputDirection = inputMaster.GameplayActions.Move.ReadValue<Vector2>();
        Vector3 rightMovement = rightDir * inputDirection.x;
        Vector3 upMovement = forwardDir * inputDirection.y;
        movementDirection = Vector3.Normalize(rightMovement + upMovement);
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1 / Mathf.Sqrt(2)) * Mathf.Sqrt(2);

        if(inputDirection.magnitude > 0)
        {
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = Vector3.SmoothDamp(transform.forward, heading, ref turnVelocity, turnSmoothDamp);
        }
    }

    void MonsterMovement()
    {
        monsterBody.velocity = new Vector3(movementDirection.x * moveSpeed, monsterBody.velocity.y, movementDirection.z * moveSpeed);
    }

    bool CheckIfMonsterGrounded()
    {
        onGround = Physics.CheckSphere(transform.position + contactOffset, contactRadius, groundLayer);
        return onGround;
    }

    void MonsterJump()
    {
        monsterBody.velocity = new Vector2(monsterBody.velocity.x, 0);
        monsterBody.velocity += Vector3.up * jumpForce;
    }

    void MonsterJumpPhysics()
    {
        if (monsterBody.velocity.y < 0)
        {
            monsterBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void PogoSpringPhysics()
    {
        Vector3 pogoNewPos = pogo.localPosition;
        if(onGround)
        {
            pogoNewPos.y = minSpringDistance;
            springSmoothDamp = 0.02f;
        } else
        {
            pogoNewPos.y = maxSpringDistance;
            springSmoothDamp = 0.06f;
        }

        pogo.localPosition = Vector3.SmoothDamp(pogo.localPosition, pogoNewPos, ref springVelocity, springSmoothDamp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && onGround)
        {
            MonsterJump();
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        CheckIfMonsterGrounded();
    }
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + contactOffset, contactRadius);
    }
}
