using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int baseDamage = 1; // �����˺�
    public float attackDistance = 2.0f; // ��������
    public float attackRate = 1.0f; // ��������(ÿ�빥������)
    public Transform attackPoint; // ������

    private Animator animator; //����������
    private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��
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
                Debug.Log("���¹�����");
                Attack();
                nextAttackTime = Time.time + 1.0f / attackRate;
            }
        }
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");

        Debug.Log("Player Attack!");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackDistance);//��⹥����Χ�ڵĵ��˵���ײ��
        
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
        // ��Scene��ͼ�п��ӻ�������Χ
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
