using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    public Animator animator;

    public int AttackDamage = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    void Attack()
    {
        //dá play na animação de ataque
        animator.SetTrigger("attack");
        // detecta se há inimigos no range do ataque
        Collider2D [] hitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers); // cria um círculo e coleta as informações de tudo que este círculo tocar;

        // Aplica o Dano
        foreach (Collider2D enemy in hitEnemy) // basicamente, aplica o dano no inimigo que for atingido pelo "hitenemy"
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

}
