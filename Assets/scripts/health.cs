using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour, IDamageable
{
  // private static Dragon enemy;

    public static GameObject enemy;
    //enemy.AddComponent<Rigidbody>();
     public  static int CurrentHealth { get; private set; }
    public int damage;
    //private static int CurrentHealth;



    public static void DamageTaken(int amount)
    {
        
        CurrentHealth -= amount;
        

    }
    
    public int GetHealth()
    {
        return CurrentHealth;
    }

    public static void Kill(GameObject enemy)
    {
        
        Destroy(enemy);
    }

    public void TakeDamage(int damage)
    {
        int amount = 5;
        damage = amount;

        

    }

}
