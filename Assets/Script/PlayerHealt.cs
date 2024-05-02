using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // ���ʹ�٧�ش�ͧ Player
    private int currentHealth; // ���ʹ�Ѩ�غѹ�ͧ Player

    private void Start()
    {
        currentHealth = maxHealth; // ��˹�����������������ʹ�Ѩ�غѹ�����ʹ�٧�ش
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ǩ�ͺ��� Player �� Collider �ͧ Object ����������
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("KillZone"))
        {
            // Ŵ���ʹ�ͧ Player
            TakeDamage(1); // Ŵ���ʹ���� 1
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; // Ŵ���ʹ����ӹǹ����к�

        if (currentHealth <= 0)
        {
            Die(); // ������ʹ��� Player ���
        }
    }

    void Die()
    {
        // ����鴷��س��ͧ������ Player ��� ������س��ͧ���
        Debug.Log("Player has died."); // ������ҧ��
        // ���¡��ѧ��ѹ�������ʹ�������Ǣ�ͧ�Ѻ��õ�¢ͧ Player �����
        // �� ��Ŵ�ҡ����, ����Ϳ࿤��õ��, ������� �
    }
}