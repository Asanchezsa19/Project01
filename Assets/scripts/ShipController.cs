using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(health))]
public class ShipController : MonoBehaviour, IDamageable
{
    [SerializeField] ParticleSystem _damageParticles;
    [SerializeField] AudioClip _damageSound;
    public GameObject ship;
    [SerializeField] float _maxSpeed = .25f;
    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;
    }

    [SerializeField] float _moveSpeed = .25f;
    [SerializeField] float _turnSpeed = .25f;
    public int damage;
    [SerializeField] Slider _healthSlider = null;

    Rigidbody _rb;

    public health health { get; private set; }

    public Transform camTransform;

    public float shakeDuration = 0f;

    public float shakeAmount = 0f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    private void Awake()
    {
        health = GetComponent<health>();

        _healthSlider.maxValue = health.MaxHealth;
        _healthSlider.value = health.StartingHealth;
        _rb = GetComponent<Rigidbody>();

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable()
    {
        health.Damaged += OnTakeDamage;

        originalPos = camTransform.localPosition;
    }
    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    private void OnDisable()
    {
        health.Damaged -= OnTakeDamage;
    }

    void OnTakeDamage(int damage)
    {
        _healthSlider.value = health.CurrentHealth;
        shakeDuration = .5f;
}
    public void TakeDamage(int damage)
    {
        //  int amount = 5;
        // damage = amount;
    }

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
        
    }

    public void MoveTank()
    {
        // calculate the move amount
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _moveSpeed;
        // create a vector from amount and direction
        Vector3 moveOffset = transform.up * moveAmountThisFrame;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset);
        // technically adjusting vector is more accurate! (but more complex)
    }

    public void TurnTank()
    {
        // calculate the turn amount
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        Vector3 turnOffset = transform.right * turnAmountThisFrame;
        // apply quaternion to the rigidbody
        _rb.MovePosition(_rb.position + turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Sphere(Clone)")
        {
           Feedback();

            health.TakeDamage(10);
        }

        if (ship != null)
        {

            //gameObject.SetActive(false);
        }

    }
    private void Feedback()
    {
        if (_damageParticles != null)
        {
            _damageParticles = Instantiate(_damageParticles, GameObject.Find("Ship").transform.position, Quaternion.identity);
            _damageParticles.Play();
        }
        if (_damageSound != null)
        {
            AudioHelper.PlayClip2D(_damageSound, 1f);
        }
    }

}

