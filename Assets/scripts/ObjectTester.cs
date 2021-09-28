using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTester : MonoBehaviour
{
    [SerializeField]
    private Dragon _dragon;

    //[SerializeField] private DestructibleWall _destructibleWall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            health.DamageTaken(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            health.DamageTaken(5);
        }

    }

    
}
