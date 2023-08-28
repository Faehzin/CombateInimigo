using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

   public void TakeDamage(int damage)
   {
       currentHealth -= damage;

       //play hurt animation;
       animator.SetTrigger("damage");

       if(currentHealth  <= 0)
       {
           Die();
       }
       else
        {
            StartCoroutine(ReturnToNormalAnimation());
        }
   }
   IEnumerator ReturnToNormalAnimation()
    {
        yield return new WaitForSeconds(0.5f); 
        animator.SetTrigger("normal"); 
    }
   public void Die()
   {
       StartCoroutine(DieCoroutine());
    // die animation
    //disable the enemy
   }
    IEnumerator DieCoroutine()
    {
        animator.SetTrigger("dying");
        yield return new WaitForSeconds(0.3f); // Delay for the dying animation
        Destroy(gameObject);
        // die animation
        // disable the enemy
    }

}
