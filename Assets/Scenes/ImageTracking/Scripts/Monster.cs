using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterUI _monsterUI;
    [SerializeField] private ParticleSystem _attackEffect;

    [SerializeField] private string _monsterName = "Monster";
    [SerializeField] private int _attack = 1;
    [SerializeField] private int _health = 1;
    private int _currenthealth;

    private Animator _animator;
    
    private readonly int IDLE_ANIMATION = Animator.StringToHash("Idle");
    private readonly int ATTACK_ANIMATION = Animator.StringToHash("Attack");
    
    private void Start()
    {
        if (_monsterUI != null)
        {
            _monsterUI.SetNameText(_monsterName);
            _monsterUI.SetStatText(_attack, _health, false);
        }

        _currenthealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Attack(Monster monster)
    { 
        monster.TakeDamage(_attack);
        _animator.SetTrigger(ATTACK_ANIMATION);
        transform.LookAt(monster.transform.position);
    }

    private void TakeDamage(int damage)
    {
        _currenthealth -= damage;
        _monsterUI.SetStatText(_attack, _currenthealth, _currenthealth != _health);
        _attackEffect.Play();

        if (_currenthealth <= 0)
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
