using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int baseDamage = 1; // 基础伤害
    public float attackDistance = 1.5f; // 攻击距离
    public float attackRate = 2.0f; // 攻击速率(每秒攻击次数)
    public Transform attackPoint; // 攻击点

    private Animator animator; //动画控制器
    private float nextAttackTime = 0.0f; // 下次可以攻击的时间
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>(); // C#里的this关键字表示当前对象,可以省略
    }

    // Update is called once per frame
    void Update()
    {
        // 检查是否可以攻击
        if (Time.time >= nextAttackTime)
        {
            Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackDistance);
            foreach (Collider player in hitPlayers)
            {
                if (player.CompareTag("Player"))
                {
                    Attack(player); // 攻击玩家
                    nextAttackTime = Time.time + 1.0f / attackRate; // 更新下一次攻击时间
                }
            }
        }
    }

    void Attack(Collider player)
    {
        //animator.SetTrigger("Attack");
        return;

        // 对玩家造成伤害
        PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(baseDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        // 在Scene视图中可视化攻击范围
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
