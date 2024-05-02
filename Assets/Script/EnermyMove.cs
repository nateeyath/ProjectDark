using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // ความเร็วในการเคลื่อนที่ของศัตรู
    private Rigidbody2D rb;
    private bool facingRight = true; // ตัวแปรเก็บทิศทางของศัตรู

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // เคลื่อนที่ไปทางขวา (ถ้าต้องการเคลื่อนที่ไปทางซ้ายให้ใส่ค่าติดลบ)
        if (facingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        // สลับทิศทางของศัตรูหากชนขอบจอหรือขอบการกระตุ้น
        if ((facingRight && rb.velocity.x < 0) || (!facingRight && rb.velocity.x > 0))
        {
            Flip();
        }
    }

    // ฟังก์ชันสลับทิศทางของศัตรู
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}