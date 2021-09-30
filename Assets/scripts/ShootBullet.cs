using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] ParticleSystem _shootParticles;
    [SerializeField] AudioClip _shootSound;
    [SerializeField] private GameObject _bullet;
    public GameObject projectile;
   // public GameObject spawner;
    public float _projSpeed = 200f;
    [SerializeField] int _damage = 20;
    private void FixedUpdate()
    {
        shootProjectile();
    }
    
    public void shootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Feedback();
            GameObject _bullet = Instantiate(projectile, transform.position, transform.rotation);
            _bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, _projSpeed));
            
        }
        
    }

    private void Feedback()
    {
        if (_shootParticles != null)
        {
            _shootParticles = Instantiate(_shootParticles, GameObject.Find("Ship").transform.position, Quaternion.identity);
            _shootParticles.Play();
        }
        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_shootSound, 1f);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        health health = other.gameObject.GetComponent<health>();
        health?.TakeDamage(_damage);
        //TODO consider Object Pooling here!
        Destroy(gameObject);
    }
}
