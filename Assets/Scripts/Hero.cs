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
    float horizontal;
    float vertical;
    bool isRunning = false;
    Direction direction = Direction.Down;

    public HeroState state = HeroState.Idle;

    [SerializeField] float speed;
    [SerializeField] float deltaSpeed = 0.5f;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 8f;

    [SerializeField] LayerMask collisionMask;
    Vector2 boxSize = new Vector2(1f, 1f);


    Animator animator;


    #region PLAYER_INPUT
    public void MoveInput(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
    public void RunInput(InputAction.CallbackContext context)
    {
        if (context.started)
            isRunning = true;
        else if (context.canceled)
            isRunning = false;
    }
    #endregion

    void Move()
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        if (movement == Vector2.zero)
        {
            state = HeroState.Idle;
            animator.speed = 1;
            speed = minSpeed;
            return;
        }

        state = HeroState.Walk;
        animator.speed = speed;

        Vector2 moveDelta = speed * Time.deltaTime * movement;
        Vector2 targetPos = (Vector2)transform.position + moveDelta;

        
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, movement, moveDelta.magnitude, collisionMask);

        if (hit.collider != null)
        {
            float safeDistance = Mathf.Max(0f, hit.distance - 0.01f); // leave a tiny gap
            transform.position += (Vector3)(movement * safeDistance);

            state = HeroState.Idle;
            return;
        }
        
        transform.position = targetPos;

        if (state == HeroState.Idle)
        {
            speed = minSpeed;
        }
        else if (isRunning)
            speed = Mathf.Min(speed + deltaSpeed, maxSpeed);
        else
            speed = Mathf.Max(speed - deltaSpeed, minSpeed);

        if (movement.x > 0)
            direction = Direction.Right;
        else if (movement.x < 0)
            direction = Direction.Left;
        else if (movement.y > 0)
            direction = Direction.Up;
        else if (movement.y < 0)
            direction = Direction.Down;
    }
    void Animate()
    {
        String animation = state.ToString() + direction.ToString();
        animator.Play(animation);
    }

    #region UNITY_FUNCTIONS
    void Awake()
    {
        boxSize = GetComponent<BoxCollider2D>().size;
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        Move();
        Animate();
    }
    #endregion
}
