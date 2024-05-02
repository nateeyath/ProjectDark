using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint; // จุดที่ใช้ในการโจมตี
    public float attackRange = 0.5f; // รัศมีการโจมตี
    public LayerMask enemyLayers; // เลเยอร์ของศัตรู

    public float attackRate = 2f; // อัตราการโจมตีต่อวินาที
    private float nextAttackTime = 0f; // เวลาที่จะโจมตีครั้งถัดไป

    public int attackDamage = 1; // ความเสียหายที่จะส่งไปยังศัตรู

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) // หรือปุ่มอื่น ๆ ที่คุณต้องการใช้ในการโจมตี
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // ทำให้ศัตรูที่อยู่ในช่วงโจมตีโดยใช้ CircleCastAll
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // ทำความเสียหายแก่ศัตรูที่โจมตี
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // วาดพื้นที่ของการโจมตี
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}