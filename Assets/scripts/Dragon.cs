using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(health))]
public class Dragon : MonoBehaviour, IDamageable
{
    [SerializeField] ParticleSystem _damageParticles;
    [SerializeField] AudioClip _damageSound;
    public GameObject enemy;

     public int damage;

    [SerializeField] Slider _healthSlider = null;

    [SerializeField] float _speed = 4f;

    Rigidbody _rb;

    public health health { get; private set; }

    private void Awake()
    {
        health = GetComponent<health>();

        _healthSlider.maxValue = health.MaxHealth;
        _healthSlider.value = health.StartingHealth;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        health.Damaged += OnTakeDamage;
    }

    private void OnDisable()
    {
        health.Damaged -= OnTakeDamage;
    }

    void OnTakeDamage(int damage)
    {
        _healthSlider.value = health.CurrentHealth;
    }

    void Update()
    {
        
    }

    

    

    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.name == "Sphere(Clone)")
        {
            Feedback();

            health.TakeDamage(10);
        }    
    }
    public void TakeDamage(int damage)
    {
      //  int amount = 5;
       // damage = amount;
    }
    private void Feedback()
    {
        if (_damageParticles != null)
        {
            _damageParticles = Instantiate(_damageParticles, GameObject.Find("Dragon").transform.position, Quaternion.identity) ;
            _damageParticles.Play();
        }
        if (_damageSound != null)
        {
            AudioHelper.PlayClip2D(_damageSound, 1f);
        }
    }
    
    
    

}
    
