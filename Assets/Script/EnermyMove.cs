using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // ��������㹡������͹���ͧ�ѵ��
    private Rigidbody2D rb;
    private bool facingRight = true; // ������纷�ȷҧ�ͧ�ѵ��

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ����͹���价ҧ��� (��ҵ�ͧ�������͹���价ҧ�����������ҵԴź)
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
        // ��Ѻ��ȷҧ�ͧ�ѵ���ҡ���ͺ�����͢ͺ��á�е��
        if ((facingRight && rb.velocity.x < 0) || (!facingRight && rb.velocity.x > 0))
        {
            Flip();
        }
    }

    // �ѧ��ѹ��Ѻ��ȷҧ�ͧ�ѵ��
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}