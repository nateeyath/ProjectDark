using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��� Object �������Ҫ��� Player �������
        if (other.CompareTag("Player"))
        {
            // ����鴷��س��ͧ��÷������ Player ���
            // ¡������ҧ��:
            Debug.Log("Player has entered the kill zone");
            // ����ö���¡�ѧ��ѹ�������Ǣ�ͧ�Ѻ��õ�¢ͧ Player ������
            // �� ��Ŵ�ҡ����, ����Ϳ࿤��õ��, ������� �
        }
    }
}