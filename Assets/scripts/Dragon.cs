using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour, IDamageable
{
    private int _health = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere(Clone)")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("You injured the dragon");
        _health -= amount;
        Debug.Log("Dragon health: " + _health);
    }
}
    
