using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints;
    public int damage;
    public string collTag;
    public Animator animator;
    public bool isPlayer;

    public void TakeDamage(int damage)
    {
        healthPoints-=damage;

        if(healthPoints<=0)
            Destroy(gameObject);
    }
    public void Heal(int points)
    {
        healthPoints+=points;
    }
    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.tag==collTag)
            TakeDamage(coll.gameObject.GetComponent<Health>().damage);
            if(animator!=null)
                animator.SetTrigger("Attack");

    }
    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if(coll.gameObject.tag=="Healbox")
            Heal(10);
            Destroy(coll.gameObject);
        if(coll.gameObject.tag=="Magic" && !isPlayer)
            {
                TakeDamage(30);
                Destroy(coll.gameObject);
            }
    }
}
