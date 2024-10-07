using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // 最大生命值
    private int currentHealth; // 当前生命值
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 受到伤害
        Debug.Log("Player hit! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;// 防止生命值为负数
            Die(); // 如果生命值降至0或以下，执行死亡逻辑
        }
    }

    void Die()
    {
        // 在此处添加敌人死亡的逻辑，例如播放死亡动画、销毁敌人对象等
        Debug.Log("Enemy died!");
        Destroy(gameObject); // 简单示例：销毁敌人对象
    }
}
