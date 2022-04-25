using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionAfterSeconds : MonoBehaviour
{
    public GameObject splashSphere;
    
    // Start is called before the first frame update

  
   
    private void Update()
    {
        Destroy(splashSphere, 2f);
    }
    // Update is called once per frame
}
