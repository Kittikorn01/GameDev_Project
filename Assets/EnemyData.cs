using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float health = 10f;
    public float moveSpeed = 5f;
    public float damage = 2f;
}
