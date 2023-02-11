using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Collider2D swordCollider;
    public float damage = 3;
 
    Vector2 rightAttackOffset; 


     private void Start ()
    {
        rightAttackOffset = transform.position;
    }

    public void AttackRight ()
    {
        print("Attack Right");
        swordCollider.enabled = true; 
        transform.localPosition = rightAttackOffset;
    }

    

    public void AttackLeft ()
    {
        print("Attack Left");   
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void Stopattack()
    {
        swordCollider.enabled = false;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();  

            if (enemy != null)
            {

                enemy.health -= damage;
            }

        }
    }
}
