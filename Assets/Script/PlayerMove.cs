using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jump = 15;
    public float jumpCooldown = 1f; // �������ҷ���ͧ�������ҧ��á��ⴴ (�Թҷ�)
    private bool canJump = true; // ��������͵�Ǩ�ͺ��� Player ����ö���ⴴ���������
    public GameObject projectilePrefab; // ��ਡ���ͧ Projectile

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer; // ���� SpriteRenderer ��������¹�ŧ��ȷҧ�ͧ����Ф�

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������������§�Ѻ SpriteRenderer
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        // �礡������͹����������¹�ŧ��ȷҧ�ͧ����Ф�
        if (move > 0)
        {
            spriteRenderer.flipX = false; // �ѹ价ҧ���
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // �ѹ价ҧ����
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            canJump = false; // ��駤������������ö���ⴴ���ա�����Ҩм�ҹ����� jumpCooldown
            StartCoroutine(JumpCooldown()); // �������ùѺ���� cooldown
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
            // ���ҧ Projectile �����˹觢ͧ Player
            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // ����� Rigidbody2D �ա��Ṻ�ҡѺ projectileObject �������
            Rigidbody2D projectileRb = projectileObject.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                // �絤������������ Projectile 价ҧ��Ҷ�� Player �ѹ价ҧ��� ���ͷҧ���¶�� Player �ѹ价ҧ����
                Vector2 direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
                projectileRb.velocity = direction * speed; // ��˹������������ Projectile �㹷�ȷҧ���١��ͧ
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
        canJump = true; // ��ѧ�ҡ��ҹ����� jumpCooldown ��� Player ����ö���ⴴ���ա
    }
}