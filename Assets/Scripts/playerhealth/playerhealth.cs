using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerhealth : MonoBehaviour
{

    [SerializeField] public static float maxHealth = 100;
    [SerializeField] public static float currentHealth;
    public static float pointsIncreadPerSecond;
    public static float contador = 2;
    
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPS;
    public weapon Weapon;
    
    public GameObject damage1;
    public GameObject damage2;
    public GameObject damage3;
    
    // Start is called before the first frame update
    void Start()
    {
        FPS = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        currentHealth = maxHealth;
        pointsIncreadPerSecond = 5F;

    }

    // Update is called once per frame

    public static void TakeDamage(int damage)
    {

        currentHealth -= damage;
        contador = 2;

    }
    public void Update()
    {
        if (contador <= 0)
        {
            regenHealth();
        }
        else if (currentHealth < maxHealth)
        {
            contador -= Time.deltaTime;
        }
        showDamage();
        print("la vida:" + currentHealth + "Contador:" + contador);
        gameIsPaused();
        endgame();
    }

    public void regenHealth()
    {


        //if (currentHealth >= maxHealth)
        //{
            //currentHealth = 100;

        //}

        if (currentHealth < maxHealth && currentHealth >= 0)
        {

            currentHealth += pointsIncreadPerSecond * Time.deltaTime;

        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }


    }
    public  void gameIsPaused()
    {
        if (PAUSEMENU.gameIsPause == true)
        {
           FPS.enabled = false;
            Weapon.enabled = false;
            print("playerPause");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
        }
        else
        {
            FPS.enabled = true;
            Weapon.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    } 
    public void endgame()
    {
        if(currentHealth <= 0)
        {
            FPS.enabled = false;
            Weapon.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MENU");
        }
    }
    public void showDamage()
    {
        if (currentHealth > 75)
        {
            damage1.SetActive(false);
            damage2.SetActive(false);
            damage3.SetActive(false);
        }
        else if (currentHealth <= 75 && currentHealth > 50)
        {
            damage1.SetActive(true);
            damage2.SetActive(false);
            damage3.SetActive(false);
        }

        else if (currentHealth <= 50 && currentHealth > 25)
        {

            damage2.SetActive(true);
            damage1.SetActive(false);
            damage3.SetActive(false);

        }
        else if (currentHealth <= 25)
        {
            damage3.SetActive(true);
            damage2.SetActive(false);
            damage1.SetActive(false);

        }


    }
}

       



