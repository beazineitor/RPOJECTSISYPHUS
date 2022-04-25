using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    [SerializeField] public float health = 100;
    
    public void applyDamage(float damage)
    {
        health -= damage;
        if (health<=0)
        {
      
            Destroy(gameObject, 4f);
        }
    }
  
}
