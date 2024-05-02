using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // ความเร็วของ projectile
    public int damage = 3; // ความเสียหายที่จะก่อให้กับศัตรู

    private void Start()
    {
        // ทำลาย projectile หลังจาก 2 วินาทีเพื่อป้องกันไม่ให้คงอยู่ในเกมตลอดเวลา
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        // เคลื่อนที่ projectile ไปข้างหน้า
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ถ้า projectile ชนกับศัตรู
        if (other.CompareTag("Enemy"))
        {
            // ส่งความเสียหายให้กับศัตรู
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            // ทำลาย projectile
            Destroy(gameObject);
        }
    }

    internal void Initialize(bool v)
    {
        throw new NotImplementedException();
    }
}
