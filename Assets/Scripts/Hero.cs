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
    public HeroState state = HeroState.Idle;
    Direction direction = Direction.Down;

    [SerializeField] float speed;
    Animator animator;

    float horizontal;
    float vertical;

    #region PLAYER_INPUT
    public void MoveInput(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
    #endregion

    void Move()
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        if (movement == Vector2.zero)
        {
            state = HeroState.Idle;
            animator.speed = 1;
            return;
        }

        state = HeroState.Walk;
        animator.speed = speed;
        transform.position += (Vector3)(speed * Time.deltaTime * movement);
        if (movement.y > 0)
        {
            direction = Direction.Up;
        }
        else if (movement.y < 0)
        {
            direction = Direction.Down;

        }
        else if (movement.x < 0)
        {
            direction = Direction.Left;
        }
        else if (movement.x > 0)
        {
            direction = Direction.Right;
        }
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

    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }
}
