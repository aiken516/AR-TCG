using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterUI _monsterUI;

    [SerializeField] private int _attack = 1;
    [SerializeField] private int _health = 1;

    private void Start()
    {
        if (_monsterUI != null)
        {
            _monsterUI.SetText(_attack, _health);
        }
    }

    private void Attack(Monster monster)
    { 
        monster.TakeDamage(_attack);
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        _monsterUI.SetText(_attack, _health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<Monster>()?.Attack(this);
        }
    }
}
