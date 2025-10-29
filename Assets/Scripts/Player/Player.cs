using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatsSO _stats;

    public PlayerStatsSO Stats => _stats;
}
