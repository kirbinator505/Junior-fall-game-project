using UnityEngine;
using UnityEngine.Events;

public class EnemyStatBehavior : MonoBehaviour
{
    public EnemySO enemyBase;
    private int currentHealth;
    public int lvl;
    public UnityEvent onDeathEvent;
    
    void Start()
    {
        if (enemyBase != null)
        {
            currentHealth = enemyBase.health;
            lvl = enemyBase.level;
        }
    }
/*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }
    */

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDeathEvent.Invoke();
        Debug.Log("dead");//for debugging purposes
    }
}
