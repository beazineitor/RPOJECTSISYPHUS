using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
   
    public float maxAmount;
    public float amount;
    public float smoothAmount;
    private Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.localPosition;   
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        print(Input.GetAxis("Mouse X"));
        float movementY = -Input.GetAxis("Mouse Y") * amount;
        print(Input.GetAxis("Mouse Y"));
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);



        Vector3 finalPosition = new Vector3 (movementX, movementY, 0);
        
        transform.localPosition = Vector3.Lerp(transform.localPosition,finalPosition + initialPosition, Time.deltaTime *smoothAmount);
    }
}
