using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // �������ֵ
    private int currentHealth; // ��ǰ����ֵ
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �ܵ��˺�
        Debug.Log("Player hit! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;// ��ֹ����ֵΪ����
            Die(); // �������ֵ����0�����£�ִ�������߼�
        }
    }

    void Die()
    {
        // �ڴ˴���ӵ����������߼������粥���������������ٵ��˶����
        Debug.Log("Enemy died!");
        Destroy(gameObject); // ��ʾ�������ٵ��˶���
    }
}
