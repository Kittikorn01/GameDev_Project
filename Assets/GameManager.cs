using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    void OnEnable()
    {
        player.OnPlayerDied += Died;
    }

    void OnDisable()
    {
        player.OnPlayerDied -= Died;
    }

    void Died()
    {
        Debug.Log("Game Over!");
    }
}
