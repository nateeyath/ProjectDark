using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(10); // Ŵ���ʹ�ͧ Enemy ����˹��˹��������ⴹ����Ф�����
        }
    }
}