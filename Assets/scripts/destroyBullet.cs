using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    [SerializeField] ParticleSystem _destroyParticles;
    [SerializeField] AudioClip _destroySound;
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Feedback();
    }
    private void Feedback()
    {
        if (_destroyParticles != null)
        {
            _destroyParticles = Instantiate(_destroyParticles, GameObject.Find("Sphere(Clone)").transform.position, Quaternion.identity);
            _destroyParticles.Play();
        }
        if (_destroySound != null)
        {
            AudioHelper.PlayClip2D(_destroySound, 1f);
        }
    }

}
