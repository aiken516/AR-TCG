using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterUI _monsterUI;
    [SerializeField] private ParticleSystem _attackEffect;

    [SerializeField] private string _monsterName = "Monster";
    [SerializeField] private int _attack = 1;
    [SerializeField] private int _health = 1;

    private readonly int IDLE_ANIMATION = Animator.StringToHash("Idle");
    private readonly int ATTACK_ANIMATION = Animator.StringToHash("Attack");
    private readonly int DIE_ANIMATION = Animator.StringToHash("Die");
    private const float ATTACK_COOLDOWN = 1.0f;

    private Animator _animator;
    private int _currenthealth;
    private bool _isAttackCoolDown = false;

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
        _animator.SetTrigger(DIE_ANIMATION);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isAttackCoolDown)
        { 
            if (other.CompareTag("Monster"))
            {
                StartCoroutine(AttackCooldown());
                other.GetComponent<Monster>()?.Attack(this);
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        _isAttackCoolDown = true;
        yield return new WaitForSeconds(ATTACK_COOLDOWN);
        _isAttackCoolDown = false;
    }
}
