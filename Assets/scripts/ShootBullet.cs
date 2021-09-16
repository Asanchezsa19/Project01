using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    public GameObject projectile;
   // public GameObject spawner;
    public float _projSpeed = 200f;
    private void FixedUpdate()
    {
        shootProjectile();
    }
    
    public void shootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bullet = Instantiate(projectile, transform.position, transform.rotation);
            _bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, _projSpeed));
            
        }
        
    }

     
}
