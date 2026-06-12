using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private EnemyHealth enemy;

    void OnEnable()
    {
        player.OnPlayerDied += Died;
        enemy.OnEnemyDied += EnemyDied;
    }

    void OnDisable()
    {
        player.OnPlayerDied -= Died;
        enemy.OnEnemyDied -= EnemyDied;
    }

    void Died()
    {
        Debug.Log("Game Over!");
    }

    void EnemyDied()
    {
        Debug.Log("Enemy Defeated!");
    }
}
