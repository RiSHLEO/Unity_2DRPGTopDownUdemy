using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatsSO _stats;

    public PlayerStatsSO Stats => _stats;

    private PlayerAnimations _playerAnimations;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void ResetPlayer()
    {
        _stats.ResetPlayer();
        _playerAnimations.ResetPlayerAnimation();
    }
}
