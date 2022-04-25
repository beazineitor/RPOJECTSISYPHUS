using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionForce = 10;
    public float radius = 10f;
    public bool explode;
    public GameObject SPLASHAREA;
    public GameObject smokeTrail;
    //public BAZOOKA isLaunched;
    
    

    public AudioSource hit;
    
    

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);

        
        if (collision.gameObject.tag != "Player")
        {
            if (explode)
            {
                Explode();
                hit.Play();
               


            }
            
        }
    }
   
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            if (rig != null)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            

        }
        Instantiate(SPLASHAREA, transform.position, transform.rotation);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        

    }
    private void Update()
    {
        //if(isLaunched.launched == true)
        //{
            //smokeTrail.SetActive(true);
        //
        //}
        if (BAZOOKA.launched == true)
        {
            smokeTrail.SetActive(true);
        }
    }


}
