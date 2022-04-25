using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyLight : MonoBehaviour
{
    public GameObject initialiLight;
    public void Update()
    {
        deactivateLight();
    }
    void deactivateLight()
    {
        Destroy(initialiLight,4f);
    }
}
