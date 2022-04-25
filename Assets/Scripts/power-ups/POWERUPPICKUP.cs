using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POWERUPPICKUP : MonoBehaviour
{
    public float TIMER;
    public float FLASHTIMER;
    public float FLASHDURATION;
    public float SPINSPEED;
    public float ROTATION;
    public bool noEstoyDentro = true;

    // Update is called once per frame
    void Update()
    {
        TIMER -= Time.deltaTime;
        if(TIMER > 10f)
        {
            ROTATION += SPINSPEED * Time.deltaTime;
        }
        else if (TIMER>0)
        {
            FLASHTIMER -= Time.deltaTime;
            if (FLASHTIMER <= 0)
            {
                FLASHTIMER = FLASHDURATION;
                Flash();
            }
            ROTATION += SPINSPEED*2 * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0, ROTATION, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            noEstoyDentro = false;
        }
    }
   
    void Flash()
    {
        if (noEstoyDentro)
        {
            
            MeshRenderer renderer = GetComponentInParent<MeshRenderer>();
            renderer.enabled = !renderer.enabled;
            Light light = GetComponentInParent<Light>();
            light.enabled = !light.enabled;
        }
      
       
    }
   public void disablePickUp()
    {
        MeshRenderer renderer = GetComponentInParent<MeshRenderer>();
        renderer.enabled = false;
        Light light = GetComponentInParent<Light>();
        light.enabled = false;
        BoxCollider collider = GetComponentInParent<BoxCollider>();
        collider.enabled = false;
        Destroy(gameObject);
    }

}
