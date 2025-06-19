using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterUI _monsterUI;

    [SerializeField] private int _attack = 1;
    [SerializeField] private int _health = 1;

    private Animator _animator;
    
    private readonly int IDLE_ANIMATION = Animator.StringToHash("Idle");
    private readonly int ATTACK_ANIMATION = Animator.StringToHash("Attack");
    
    private void Start()
    {
        if (_monsterUI != null)
        {
            _monsterUI.SetText(_attack, _health);
        }
        
        _animator = GetComponent<Animator>();
    }

    private void Attack(Monster monster)
    { 
        monster.TakeDamage(_attack);
        _animator.SetTrigger(ATTACK_ANIMATION);
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
