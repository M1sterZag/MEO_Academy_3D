using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private ParticleSystem shootParticle; 
    [SerializeField] private float fireRate;
 
    private float nextFireTime = 0f; 
 
    void Update() 
    { 
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime) 
        { 
            Shoot(); 
            nextFireTime = Time.time + fireRate; 
        } 
    } 
 
    void Shoot() 
    { 
        shootParticle.Play();   
    } 
}
