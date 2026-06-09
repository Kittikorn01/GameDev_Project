using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private bool isGrounded = false;
    public event Action OnPlayerDied;

    private Rigidbody2D rb;
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += OnJump;
        inputActions.Player.Kill.performed += PlayerDied;
    }

    void OnDisable()
    {
        inputActions.Player.Jump.performed -= OnJump;
        inputActions.Player.Kill.performed -= PlayerDied;
        inputActions.Player.Disable();

    }
    void Update()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();    
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput.x * playerData.moveSpeed,
            rb.linearVelocity.y
        );
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * playerData.jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void PlayerDied(InputAction.CallbackContext context)
    {
        OnPlayerDied?.Invoke();
    }
}
