using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
}
