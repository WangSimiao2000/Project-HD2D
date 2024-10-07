using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int baseDamage = 1; // �����˺�
    public float attackDistance = 1.5f; // ��������
    public float attackRate = 2.0f; // ��������(ÿ�빥������)
    public Transform attackPoint; // ������

    private Animator animator; //����������
    private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>(); // C#���this�ؼ��ֱ�ʾ��ǰ����,����ʡ��
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ƿ���Թ���
        if (Time.time >= nextAttackTime)
        {
            Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackDistance);
            foreach (Collider player in hitPlayers)
            {
                if (player.CompareTag("Player"))
                {
                    Attack(player); // �������
                    nextAttackTime = Time.time + 1.0f / attackRate; // ������һ�ι���ʱ��
                }
            }
        }
    }

    void Attack(Collider player)
    {
        //animator.SetTrigger("Attack");
        return;

        // ���������˺�
        PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(baseDamage);
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
