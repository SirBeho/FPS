using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHP = 300;


    public GameObject Cuerpo;
    public enemig enemig;
    

    /*
    public GameObject projectile;
    public Transform projectilePoint;

    public Animator animator;

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }*/

    private void Update()
    {

    }

    public int punto (string nombre, float damage)
    {
        if(nombre == "bonos")
             enemyHP -= damage*3;
        else
            enemyHP -= damage;

        if (enemyHP <= 0)
        {
            if (nombre == "bonos")
            {
                Destroy(Cuerpo);
                enemig.eliminado();
                return 200;
            }
            else
            {
                Destroy(Cuerpo);
                enemig.eliminado();
                return 50;
            }
        }

        return 0;

        
    }


}
