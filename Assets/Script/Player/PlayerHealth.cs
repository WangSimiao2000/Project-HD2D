using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // �������ֵ
    private int currentHealth; // ��ǰ����ֵ

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �ܵ��˺�
        Debug.Log("Enemy hit! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;// ��ֹ����ֵΪ����
            Die(); // �������ֵ����0�����£�ִ�������߼�
        }
    }

    void Die()
    {
        // �ڴ˴���ӵ����������߼������粥���������������ٵ��˶����
        Debug.Log("Player died!");
        gameObject.SetActive(false); // ��ʾ�������ٵ��˶���
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // �ָ�����ֵ
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // ȷ���������������ֵ
        }
        Debug.Log("Player healed! Current health: " + currentHealth);
    }
}
