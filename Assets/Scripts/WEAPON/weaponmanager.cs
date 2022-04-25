using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponmanager : MonoBehaviour
{
    //[SerializeField] private GameObject [] weapons;
    [SerializeField] public  List <GameObject> weapons; 
    [SerializeField] public float switchDelay = 1f;
    private int index;
    public bool isSwitching;
    
    // Start is called before the first frame update
    void Start()
    {
        initializeWeapons();
    }
    private void initializeWeapons()
    {
        for (int i = 0; i < weapons.Count; i++) {
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
        
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
        {
            index++;
            if (index >= weapons.Count)
            {
                index = 0;
            }
            StartCoroutine(SwitchAfterDelay(index));
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
        {
            index--;
            if (index < 0)
            {
                index = weapons.Count - 1;
            }
            StartCoroutine(SwitchAfterDelay(index));
        }
    }
    private IEnumerator SwitchAfterDelay(int newIndex)
    {
        isSwitching = true; 

        yield return new WaitForSeconds(switchDelay);

        isSwitching = false;
        switchWeapons(newIndex);

    }
    public void addWeapon(GameObject weapon)
    {
       /* for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }*/
        weapons.Add(weapon);
        index = weapons.Count - 1;
        // weapons[index].SetActive(true);
        switchWeapons(index);
    }
    private void switchWeapons(int newIndex)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[newIndex].SetActive(true);
    } 
    
}
