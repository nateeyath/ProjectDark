using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(10); // ลดเลือดของ Enemy ทีละหนึ่งหน่วยเมื่อโดนตัวละครโจมตี
        }
    }
}