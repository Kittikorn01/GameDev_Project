using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float currentHealth;
    public event Action OnEnemyDied;
    private EnemyInputActions inputActions;

    void Awake()
    {
        inputActions = new EnemyInputActions();
        currentHealth = enemyData.health;
    }
    void OnEnable()
    {
        inputActions.Enemy.Enable();
        inputActions.Enemy.DealDamage.performed += TakeDamage;
    }
    void OnDisable()
    {
        inputActions.Enemy.DealDamage.performed -= TakeDamage;
        inputActions.Enemy.Disable();
    }

    void TakeDamage(InputAction.CallbackContext context)
    {
        currentHealth -= enemyData.damage;
        Debug.Log("Hp: " + currentHealth);
        if (currentHealth <= 0)
        {
            OnEnemyDied?.Invoke();
            Destroy(gameObject);
        }
    }
    
}
