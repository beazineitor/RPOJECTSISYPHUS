using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnLightsOn : MonoBehaviour
{
    public GameObject lucesRojasPrimeraHabitacion;
    public GameObject lucesRojasSegundsHabitacion;
    public GameObject lucesRojasTerceraHabitacion;
    public GameObject lucesRojasCuartaHabitacion;
    public GameObject lucesRojasQuintaHabitacion;
    
    public GameObject lucesBlancasPrimeraHabitacion;
    public GameObject lucesBlancasSegundaHabitacion;
    public GameObject lucesBlancasTerceraHabitacion;
    public GameObject lucesBlancasCuartaHabitacion;
    public GameObject lucesBlancasQuintaHabitacion;

    public GameObject playerCharacter;
    public GameObject lightSwitch;
    public float distance_;
    public GameObject UI;

    public bool isTriggered;

    [SerializeField]private Animator anim;
    [SerializeField] private Animator doorAnimation;
    // Start is called before the first frame update

    void Update()
    {
        distance_ = Vector3.Distance(lightSwitch.transform.position, playerCharacter.transform.position);
        lightsOn();
        TurnOFF();
    }
    public void lightsOn()
    {
        if (distance_ <= 3.0f)
        {
            UI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //print("hasta aqui hemos llegao");
                anim.SetBool("switchActivated", true);

                lucesRojasPrimeraHabitacion.SetActive(false);
                lucesRojasSegundsHabitacion.SetActive(false);
                lucesRojasTerceraHabitacion.SetActive(false);
                lucesRojasCuartaHabitacion.SetActive(false);
                lucesBlancasQuintaHabitacion.SetActive(false);

                lucesBlancasPrimeraHabitacion.SetActive(true);
                lucesBlancasSegundaHabitacion.SetActive(true);
                lucesBlancasTerceraHabitacion.SetActive(true);
                lucesBlancasCuartaHabitacion.SetActive(true);
                lucesBlancasQuintaHabitacion.SetActive(true);
                
                isTriggered = true;

            }
        }
      
        else
        {
            UI.SetActive(false);
        }
    }
  
    // Update is called once per frame
    public void TurnOFF()
    {
        if (isTriggered == true)
        {
            UI.SetActive(false);
            this.enabled = false;
        }
    }
}
