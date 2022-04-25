using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAZOOKA : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject missile;
    public GameObject currentMissile;
    public float speed = 20f;
    public static bool launched;
    public int rocketsLeft = 20;
    public int currentRockets;
    public AudioSource _AudioSource;
    


    //public GameObject bulletImpact;
    //public GameObject bulletTrail;




    private void Start()
    {
       
        
            Load();
        
   
        currentRockets = rocketsLeft;
    }
   
    private void FixedUpdate()
    {
        if (!launched)
        {


            if (Input.GetButtonDown("Fire1") && currentRockets > 0)
            {
                launched = true;
                Launch();
                

                currentRockets--;
            }
        }
         
    }

    
    private void Load()
    {
        if (currentRockets >= 1)
        {
            GameObject missileInstance = Instantiate(missile, spawnPoint.position, spawnPoint.rotation);
            missileInstance.transform.parent = spawnPoint;
            currentMissile = missileInstance;
            Rigidbody rig_m = currentMissile.GetComponent<Rigidbody>();
            rig_m.isKinematic = true;
            print("Load");
            launched = false;
        }
    }
    private void Launch()
    {
        Rigidbody rig_m = currentMissile.GetComponent<Rigidbody>();
        currentMissile.transform.parent = null;
        currentMissile.GetComponent<missile>().explode=true;
        rig_m.isKinematic = false;
        rig_m.AddForce(transform.forward * speed, ForceMode.Impulse);
 
        
        _AudioSource.Play();
        print("Launch");
        Invoke("Load", 2f);
        


    }


}
