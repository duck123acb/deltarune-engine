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
        transform.position += (Vector3)(speed * Time.deltaTime * movement);
        if (isRunning)
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

    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        Move();
        Animate();
    }
}
