using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTester : MonoBehaviour
{
    [SerializeField]
    private Dragon _dragon;

    [SerializeField] private DestructibleWall _destructibleWall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DamageObject(_dragon);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DamageObject(_dragon);
        }
    }

    private void DamageObject(IDamageable damageable)
    {
        damageable.TakeDamage(5);
    }
}
