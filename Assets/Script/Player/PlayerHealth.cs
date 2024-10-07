using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // 最大生命值
    private int currentHealth; // 当前生命值

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 受到伤害
        Debug.Log("Enemy hit! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;// 防止生命值为负数
            Die(); // 如果生命值降至0或以下，执行死亡逻辑
        }
    }

    void Die()
    {
        // 在此处添加敌人死亡的逻辑，例如播放死亡动画、销毁敌人对象等
        Debug.Log("Player died!");
        gameObject.SetActive(false); // 简单示例：销毁敌人对象
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // 恢复生命值
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // 确保不超过最大生命值
        }
        Debug.Log("Player healed! Current health: " + currentHealth);
    }
}
