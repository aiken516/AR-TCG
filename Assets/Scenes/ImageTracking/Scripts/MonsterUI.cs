using TMPro;
using UnityEngine;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _attackText;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void SetNameText(string name)
    {
        _nameText.text = name;
    }

    public void SetStatText(int attack, int health, bool isHealthChanged)
    {
        _attackText.text = $"{attack}";
        _healthText.text = $"{health}";
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
