using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterScript : MonoBehaviour
{
    private InputMaster _inputMaster;

    //Movement variables
    private bool canMove;
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
    public LayerMask jumpLayers;
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

    //Stomp variables
    private bool stomp;
    public float stompSpeed = 200f;
    public ParticleSystem stompVFX;
    private bool canStomp;
    public float maxStompFuel = 100f;
    public float stompFuel;
    private float stompCost = 12f;

    public int initLifes = 3;
    private int lifes;

    public bool onExplosion;

    //Audio variables
    public AudioClip pogoJumpSound;
    public AudioClip hitVegetableSound;
    public AudioClip stompSound;
    public AudioClip loseLifeSound;

    private void Awake()
    {
        lifes = initLifes;
        monsterBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if(GameController.instance != null)
        {
            GameController.instance.inputMaster.Enable();
            SetUpInputs();
        }
    }

    private void OnDisable()
    {
        DisableInputs();
        if(GameController.instance != null)
            GameController.instance.inputMaster.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        stompFuel = maxStompFuel;
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
        CheckPogoFloorProximity();
    }

    public void EnableMovement()
    {
        forwardDir = Camera.main.transform.forward;
        forwardDir.y = 0;
        forwardDir = Vector3.Normalize(forwardDir);
        rightDir = Quaternion.Euler(new Vector3(0, 90, 0)) * forwardDir;
        canMove = true;
        canStomp = true;
    }

    void SetUpInputs()
    {
        _inputMaster = GameController.instance.inputMaster;
        _inputMaster.GameplayActions.Stomp.performed += _ => Stomp();
    }

    public void DisableInputs()
    {
        if(_inputMaster != null)
            _inputMaster.GameplayActions.Stomp.performed -= _ => Stomp();
    }

    void InputProcessing()
    {
        if (!GameController.instance.GameOver && canMove)
        {
            inputDirection = _inputMaster.GameplayActions.Move.ReadValue<Vector2>();
            Vector3 rightMovement = rightDir * inputDirection.x;
            Vector3 upMovement = forwardDir * inputDirection.y;
            movementDirection = Vector3.Normalize(rightMovement + upMovement);
            movementDirection = Vector3.ClampMagnitude(movementDirection, 1 / Mathf.Sqrt(2)) * Mathf.Sqrt(2);

            if (inputDirection.magnitude > 0 && !stomp)
            {
                Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                transform.forward = Vector3.SmoothDamp(transform.forward, heading, ref turnVelocity, turnSmoothDamp);
            }
        } 
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void MonsterMovement()
    {
        if(!onExplosion)
        {
            if (!stomp)
            {
                monsterBody.velocity = new Vector3(movementDirection.x * moveSpeed, monsterBody.velocity.y, movementDirection.z * moveSpeed);
            }
            else
            {
                monsterBody.velocity = new Vector3(0f, monsterBody.velocity.y, 0f);
            }
        }
    }

    bool CheckIfMonsterGrounded()
    {
        return Physics.CheckSphere(transform.position + contactOffset, contactRadius, jumpLayers);
    }

    void CheckPogoFloorProximity()
    {
        onGround = Physics.CheckSphere(transform.position + contactOffset, contactRadius, jumpLayers);
    }

    void MonsterJump(float _jumpForce)
    {
        SoundManager.instance.PlayCharacterSoundEffect(pogoJumpSound, 0.25f);
        monsterBody.velocity = new Vector2(monsterBody.velocity.x, 0);
        monsterBody.velocity += Vector3.up * _jumpForce;
    }

    void MonsterJumpPhysics()
    {
        if (monsterBody.velocity.y < 0 && !stomp)
        {
            monsterBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if(stomp && !onExplosion)
        {
            monsterBody.velocity += Vector3.up * Physics.gravity.y * stompSpeed * Time.deltaTime;
        } 
        else if(onExplosion)
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

    void Stomp()
    {
        if(!stomp && canStomp && !onGround && !GameController.instance.GameOver && stompFuel >= stompCost)
        {
            SoundManager.instance.PlayCharacterSoundEffect(stompSound, 1f);
            stomp = true;
            canStomp = false;
            stompFuel -= stompCost;
            GameController.instance.UpdateStompUI();
            Debug.Log("Stomp fuel left: " + stompFuel);
            if(stompVFX != null)
                stompVFX.Play();
        }
    }

    IEnumerator StompCooldown(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        canStomp = true;
    }

    void LoseLife()
    {
        SoundManager.instance.PlayUXSoundEffect(loseLifeSound, 1f);
        GameController.instance.ScreenShake(0.3f, 1.5f, 1.75f);
        lifes -= 1;
        StartCoroutine(LoseLifeAnimation());

        if(lifes <= 0)
        {
            StartCoroutine(GameController.instance.LoseSequence());
        }
        else
        {
            Respawn();
        }
    }

    IEnumerator LoseLifeAnimation()
    {
        GameObject currentLife = GameController.instance.Lifes[GameController.instance.Lifes.Count - 1];
        Sequence loseLifeSequence = DOTween.Sequence();
        Vector3 punchStrength = currentLife.transform.localScale * 0.6f;
        loseLifeSequence.Append(currentLife.transform.DOPunchScale(punchStrength, 0.3f, 10, 1));
        loseLifeSequence.Append(currentLife.transform.DOScale(Vector3.zero, 0.3f));
        GameController.instance.Lifes.Remove(currentLife);
        yield return loseLifeSequence.WaitForKill();
        loseLifeSequence.Kill();
        currentLife.SetActive(false);
    }

    void Respawn()
    {
        transform.position = GameController.instance.CurrentStage.stageSpawn.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckIfMonsterGrounded())
        {
            if(onExplosion)
            {
                onExplosion = false;
            }

            if (stomp)
            {
                stomp = false;
                StartCoroutine(StompCooldown(0.25f));
                MonsterJump(jumpForce + 2f);
            } else
            {
                MonsterJump(jumpForce);
            }

            VFXPool.instance.SpawnImpactVFX(transform.position + contactOffset);
            if(collision.gameObject.CompareTag("Vegetable"))
            {
                SoundManager.instance.PlayCharacterSoundEffect(hitVegetableSound, 0.5f);
                collision.gameObject.GetComponent<Vegetable>().ApplyDamage();
            }
        }
    }

    private void OnCollisionStay(Collision collision) //Avoid getting stuck
    {
        if (collision.gameObject.CompareTag("Prop") && stomp && !CheckIfMonsterGrounded())
        {
            stomp = false;
            StartCoroutine(StompCooldown(0.25f));
        }

        if ((collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Prop")) && CheckIfMonsterGrounded())
        {
            onGround = false;
            MonsterJump(jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Death") && !GameController.instance.GameOver)
        {
            LoseLife();
        }
    }

    public int GetLifes()
    {
        return lifes;
    }

    public void TurnOffMonster()
    {
        monsterBody.useGravity = false;
        canMove = false;
        canStomp = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + contactOffset, contactRadius);
    }
}
