using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanwsystemyellowroom : MonoBehaviour
{
    [SerializeField] private Transform firstSpawn;
    [SerializeField] private Transform secondSpawn;
    [SerializeField] private Transform thirdSPawn;
    [SerializeField] private Transform fourthSpawn;



    [SerializeField] private Transform newFirstSPawn;
    [SerializeField] private Transform newSecondSpawn;
    [SerializeField] private Transform newThrirdSpawn;
    [SerializeField] private Transform newFourthSpawn;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstSpawn.transform.position = newFirstSPawn.transform.position;
            secondSpawn.transform.position = newSecondSpawn.transform.position;
            thirdSPawn.transform.position = newThrirdSpawn.transform.position;
            fourthSpawn.transform.position = newFourthSpawn.transform.position;
            Physics.SyncTransforms();

        }
    }
}
