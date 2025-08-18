using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum HeroState
{
    Idle,
    Walk
}
enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Hero : MonoBehaviour
{
    bool isRunning = false;
    Direction direction = Direction.Down;

    public HeroState state = HeroState.Idle;

    [SerializeField] float speed;
    [SerializeField] float deltaSpeed = 0.5f;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 8f;

    [SerializeField] Vector2 downTriggerOffset = new(0f, -0.04f);
    [SerializeField] Vector2 upTriggerOffset = new(0f, 0.04f);
    [SerializeField] Vector2 leftTriggerOffset = new(-0.04f, 0f);
    [SerializeField] Vector2 rightTriggerOffset = new(0.04f, 0f);

    [SerializeField] BoxCollider2D triggerCollider;

    Animator animator;
    Rigidbody2D rb;

    Vector2 moveInput;
    Vector2 lastPos;

    IntractableObject intractableObject = null;

    PlayerInput playerInput;

    void SetIdleState()
    {
        state = HeroState.Idle;
        animator.speed = 1;
        speed = minSpeed;
    }

    void ShiftTriggerCollider()
    {
        switch (direction)
        {
            case Direction.Down:
                triggerCollider.offset = downTriggerOffset;
                break;
            case Direction.Up:
                triggerCollider.offset = upTriggerOffset;
                break;
            case Direction.Left:
                triggerCollider.offset = leftTriggerOffset;
                break;
            case Direction.Right:
                triggerCollider.offset = rightTriggerOffset;
                break;
        }
    }
    void Move()
    {
        if (moveInput == Vector2.zero)
        {
            SetIdleState();
            return;
        }

        Vector2 moveDelta = speed * Time.fixedDeltaTime * moveInput;
        rb.MovePosition(rb.position + moveDelta);

        bool blocked = rb.position == lastPos;

        if (blocked)
        {
            SetIdleState();
            return;
        }

        lastPos = rb.position;

        state = HeroState.Walk;
        animator.speed = speed;

        if (isRunning)
            speed = Mathf.Min(speed + deltaSpeed, maxSpeed);
        else
            speed = Mathf.Max(speed - deltaSpeed, minSpeed);

        if (moveInput.x > 0)
            direction = Direction.Right;
        else if (moveInput.x < 0)
            direction = Direction.Left;
        else if (moveInput.y > 0)
            direction = Direction.Up;
        else if (moveInput.y < 0)
            direction = Direction.Down;

        ShiftTriggerCollider();
    }


    #region PLAYER_INPUT
    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.normalized;
    }
    public void RunInput(InputAction.CallbackContext context)
    {
        if (context.started)
            isRunning = true;
        else if (context.canceled)
            isRunning = false;
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!context.started || intractableObject == null) return;

            intractableObject.Interact();
        }
    }
    void EnablePlayerActionMap()
    {
        playerInput.SwitchCurrentActionMap("Player");
    }
    void EnableMenuActionMap()
    {
        playerInput.SwitchCurrentActionMap("Menu");
    }
    #endregion

    #region UNITY_FUNCTIONS
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        EnablePlayerActionMap();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Animate()
    {
        String animation = state.ToString() + direction.ToString();
        animator.Play(animation);
    }
    void Update()
    {
        Animate();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out intractableObject);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        intractableObject = null;
    }
    void OnEnable()
    {
        TextboxManager textboxManager = FindAnyObjectByType<TextboxManager>();
        textboxManager.StartedDialogue += EnableMenuActionMap;
        textboxManager.EndedDialogue += EnablePlayerActionMap;
    }

    void OnDisable()
    {
        TextboxManager textboxManager = FindAnyObjectByType<TextboxManager>();
        if (textboxManager)
        {
            textboxManager.StartedDialogue -= EnableMenuActionMap;
            textboxManager.EndedDialogue -= EnablePlayerActionMap;
        }
    }
    #endregion
}
