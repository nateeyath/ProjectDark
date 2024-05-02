using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint; // �ش�����㹡������
    public float attackRange = 0.5f; // ����ա������
    public LayerMask enemyLayers; // �������ͧ�ѵ��

    public float attackRate = 2f; // �ѵ�ҡ�����յ���Թҷ�
    private float nextAttackTime = 0f; // ���ҷ������դ��駶Ѵ�

    public int attackDamage = 1; // ����������·�������ѧ�ѵ��

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) // ���ͻ������ � ���س��ͧ�����㹡������
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // ������ѵ�ٷ������㹪�ǧ�������� CircleCastAll
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // �Ӥ�������������ѵ�ٷ������
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // �Ҵ��鹷��ͧ�������
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}