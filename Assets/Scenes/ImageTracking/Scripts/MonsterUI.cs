using TMPro;
using UnityEngine;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackText;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void SetText(int attack, int health)
    {
        _attackText.text = $"{attack}";
        _healthText.text = $"{health}";
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
