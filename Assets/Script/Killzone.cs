using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า Object ที่เข้ามาชนเป็น Player หรือไม่
        if (other.CompareTag("Player"))
        {
            // ใส่โค้ดที่คุณต้องการทำเมื่อ Player ตาย
            // ยกตัวอย่างเช่น:
            Debug.Log("Player has entered the kill zone");
            // สามารถเรียกฟังก์ชันที่เกี่ยวข้องกับการตายของ Player ได้ที่นี่
            // เช่น โหลดฉากใหม่, เล่นเอฟเฟคการตาย, หรืออื่น ๆ
        }
    }
}