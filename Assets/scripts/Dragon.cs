using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(health))]
public class Dragon : MonoBehaviour, IDamageable
{
    public GameObject enemy;
    //health _currentHealth = new health(20);
    public int damage;
    // private health healthSystem;
    private health CurrenHealth;
    

  //  health(20);
    static public int Max_Health = 20;

    
    private int CurrentHealth = Max_Health;
    private void start()
    {
       
        // health healthSystem = new health(20);
        Debug.Log("Health: " + CurrentHealth);
    }

    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Sphere(Clone)")
        {

            //TakeDamage(5);
            health.DamageTaken(5);
            CurrentHealth = CurrentHealth - damage;
           Debug.Log("Health: " + CurrentHealth);
        }
        if (CurrentHealth <= 0)
        {
            health.Kill(enemy);
        }


    }
    public void TakeDamage(int damage)
    {
      //  int amount = 5;
       // damage = amount;



    }

}
    
