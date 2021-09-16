using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        Debug.Log("Wall has collapsed");
    }
}
