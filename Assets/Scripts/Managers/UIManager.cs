using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStatsSO _stats;

    [Header("Bars")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image _expBar;


    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _manaText;
    [SerializeField] private TextMeshProUGUI _expText;

    private void Update()
    {
        UpdatePlayerUI();
    }

    private void UpdatePlayerUI()
    {
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _stats.Health / _stats.MaxHealth, 10f * Time.deltaTime);
        _manaBar.fillAmount = Mathf.Lerp(_manaBar.fillAmount, _stats.Mana / _stats.MaxMana, 10f * Time.deltaTime);
        _expBar.fillAmount = Mathf.Lerp(_expBar.fillAmount, _stats.CurrentExp / _stats.NextLevelExp, 10f * Time.deltaTime);

        _levelText.text = $"Level {_stats.Level}";
        _healthText.text = $"{_stats.Health} / {_stats.MaxHealth}";
        _manaText.text = $"{_stats.Mana} / {_stats.MaxMana}";
        _expText.text = $"{_stats.CurrentExp} / {_stats.NextLevelExp}";
    }
}
