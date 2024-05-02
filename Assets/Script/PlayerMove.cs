using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jump = 15;
    public float jumpCooldown = 1f; // ระยะเวลาที่ต้องรอระหว่างการกระโดด (วินาที)
    private bool canJump = true; // ตัวแปรเพื่อตรวจสอบว่า Player สามารถกระโดดได้หรือไม่
    public GameObject projectilePrefab; // โปรเจกไตล์ของ Projectile

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer; // เพิ่ม SpriteRenderer เพื่อเปลี่ยนแปลงทิศทางของตัวละคร

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // เพิ่มการเชื่อมโยงกับ SpriteRenderer
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        // เช็คการเคลื่อนที่และเปลี่ยนแปลงทิศทางของตัวละคร
        if (move > 0)
        {
            spriteRenderer.flipX = false; // หันไปทางขวา
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // หันไปทางซ้าย
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            canJump = false; // ตั้งค่าให้ไม่สามารถกระโดดได้อีกจนกว่าจะผ่านไปเวลา jumpCooldown
            StartCoroutine(JumpCooldown()); // เริ่มการนับเวลา cooldown
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            // สร้าง Projectile ที่ตำแหน่งของ Player
            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // เช็คว่า Rigidbody2D มีการแนบมากับ projectileObject หรือไม่
            Rigidbody2D projectileRb = projectileObject.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                // เซ็ตค่าเริ่มต้นให้ Projectile ไปทางขวาถ้า Player หันไปทางขวา หรือทางซ้ายถ้า Player หันไปทางซ้าย
                Vector2 direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
                projectileRb.velocity = direction * speed; // กำหนดความเร็วให้ Projectile ไปในทิศทางที่ถูกต้อง
            }
            else
            {
                Debug.LogWarning("Rigidbody2D is missing in the projectile object.");
            }
        }
        else
        {
            Debug.LogWarning("Projectile Prefab is not assigned.");
        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true; // หลังจากผ่านไปเวลา jumpCooldown ให้ Player สามารถกระโดดได้อีก
    }
}