using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // เลือดสูงสุดของ Player
    private int currentHealth; // เลือดปัจจุบันของ Player

    private void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าเริ่มต้นให้เลือดปัจจุบันเป็นเลือดสูงสุด
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่า Player ชน Collider ของ Object อื่นหรือไม่
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("KillZone"))
        {
            // ลดเลือดของ Player
            TakeDamage(1); // ลดเลือดทีละ 1
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลดเลือดตามจำนวนที่ระบุ

        if (currentHealth <= 0)
        {
            Die(); // ถ้าเลือดหมด Player ตาย
        }
    }

    void Die()
    {
        // ใส่โค้ดที่คุณต้องการให้ Player ตาย ตามที่คุณต้องการ
        Debug.Log("Player has died."); // ตัวอย่างเช่น
        // เรียกใช้ฟังก์ชันหรือเมทอดที่เกี่ยวข้องกับการตายของ Player ที่นี่
        // เช่น โหลดฉากใหม่, เล่นเอฟเฟคการตาย, หรืออื่น ๆ
    }
}