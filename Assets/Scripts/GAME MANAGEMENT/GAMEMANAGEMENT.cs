 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGEMENT : MonoBehaviour
{
    public static int round = 1;
    int zombiesInround = 5;
    public static int sombiesLeftInRound = 5;
    int zombiesSpawnedInRound = 0;
    public float zombieSpawnTimer;
    public Transform [] zombieSpawnPoints;
    public GameObject zombieEnemy;
    float countDown = 0;
    public static int playerScore = 10000000; 
    public static int enemiesKilled = 0;
    //public GUISkin mySkin;
    public aliencontrol life;
    public static bool doublePointACtivated = false;


    // Start is called before the first frame update


    // Update is called once per frame
     void Update()
    {
        zombieSpawnTimer+=Time.deltaTime;
        if (zombiesSpawnedInRound < zombiesInround && countDown ==0)
        {
            if(zombieSpawnTimer > Random.Range (3,10))
            {
                spawnZombie();
                zombieSpawnTimer = 0;
            }
            else
            {
                zombieSpawnTimer += Time.deltaTime;
            }
       

       
        }
        else if (sombiesLeftInRound == 0)
        {
            startNextRound();
        }
        

        

        if (countDown > 0)   
            countDown -= Time.deltaTime;
            else
                countDown = 0;
            
        
    }
   
    public static void AddPoints(int pointValue)
    {
        
       
        if  (doublePointACtivated)
        {
            playerScore += pointValue * 2;
        }
        else
        {
            playerScore += pointValue;
        }
    }
   
    void spawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints [Random.Range(0, zombieSpawnPoints.Length)].position;
        Instantiate(zombieEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesSpawnedInRound++;
        zombieSpawnTimer = 0;
    }
    void startNextRound()
    {
        zombiesInround = sombiesLeftInRound = round * 5;
        zombiesSpawnedInRound = 0;
        countDown = 10;
        round++;
    }
  
}
