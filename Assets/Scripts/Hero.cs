using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    [SerializeField] float speed;

    float horizontal;
    float vertical;

    #region PLAYER_INPUT
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        transform.position += (Vector3)(speed * Time.deltaTime * movement);
    }
}
