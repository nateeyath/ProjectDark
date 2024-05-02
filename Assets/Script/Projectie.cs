using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // �������Ǣͧ projectile
    public int damage = 3; // ����������·��С�����Ѻ�ѵ��

    private void Start()
    {
        // ����� projectile ��ѧ�ҡ 2 �Թҷ����ͻ�ͧ�ѹ�����餧���������ʹ����
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        // ����͹��� projectile 仢�ҧ˹��
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��� projectile ���Ѻ�ѵ��
        if (other.CompareTag("Enemy"))
        {
            // �觤�������������Ѻ�ѵ��
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            // ����� projectile
            Destroy(gameObject);
        }
    }

    internal void Initialize(bool v)
    {
        throw new NotImplementedException();
    }
}
