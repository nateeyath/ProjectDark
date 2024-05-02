using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject deathEffect; // เอฟเฟกต์ที่เกิดขึ้นเมื่อ Enemy ตาย
    public float respawnTime = 3f; // เวลาที่ต้องรอก่อนสร้าง Enemy ใหม่

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
        // สร้างเอฟเฟกต์ที่ตำแหน่งของ Enemy
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // ทำลาย Enemy
        Destroy(gameObject);
        // เริ่มการนับเวลาสำหรับการสร้าง Enemy ใหม่
        Invoke("RespawnEnemy", respawnTime);
    }

    void RespawnEnemy()
    {
        // สร้าง Enemy ใหม่ที่ตำแหน่งเดิม
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}