using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject deathEffect; // �Ϳ࿡�����Դ�������� Enemy ���
    public float respawnTime = 3f; // ���ҷ���ͧ�͡�͹���ҧ Enemy ����

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ���ҧ�Ϳ࿡������˹觢ͧ Enemy
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ����� Enemy
        Destroy(gameObject);
        // �������ùѺ��������Ѻ������ҧ Enemy ����
        Invoke("RespawnEnemy", respawnTime);
    }

    void RespawnEnemy()
    {
        // ���ҧ Enemy ��������˹����
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}