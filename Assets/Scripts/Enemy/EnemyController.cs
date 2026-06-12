using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private float switchDirection = -1.0f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(enemyData.moveSpeed * switchDirection, rb.linearVelocity.y);
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall_Left"))
        {
            switchDirection = 1.0f;        
        }
        if (other.CompareTag("Wall_Right"))
        {
            switchDirection = -1.0f;
        }
    }
}
