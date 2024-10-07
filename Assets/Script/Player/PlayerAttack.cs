using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int baseDamage = 1; // 基础伤害
    public float attackDistance = 2.0f; // 攻击距离
    public float attackRate = 1.0f; // 攻击速率(每秒攻击次数)
    public Transform attackPoint; // 攻击点

    private Animator animator; //动画控制器
    private float nextAttackTime = 0.0f; // 下次可以攻击的时间
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("按下攻击键");
                Attack();
                nextAttackTime = Time.time + 1.0f / attackRate;
            }
        }
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");

        Debug.Log("Player Attack!");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackDistance);//检测攻击范围内的敌人的碰撞体
        
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponentInParent<EnemyHealth>().TakeDamage(baseDamage);
            }
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
