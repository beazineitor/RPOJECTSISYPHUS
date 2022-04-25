using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aliencontrol : MonoBehaviour
{
    NavMeshAgent nav;
    Transform player;
    public Animator controller;
    [SerializeField] public float health;
    public GAMEMANAGEMENT round;
    bool isDead = false;
    CapsuleCollider capsuleCollider;
    int pointValue = 10;
    public float timeToAttack;
    public float distance;
    public playerhealth FPSHelath;
    public float timeRemaining = 1;
    public GameObject[] pickups;
    public static bool instaKillActivated;
 
    
   
    //public float attackTimer;


    // Start is called before the first frame update

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponentInParent<Animator>();
        health = 90 + (10 * GAMEMANAGEMENT.round);
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav.speed = 1f + (Random.Range(0f, 3f));
        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        //         anim.GetComponent<Animator>();

    }
    void Update()
    {
        print(health + " la salud del bicho");
        
        if (!isDead)
        {
            nav.SetDestination(player.position);
            controller.SetFloat("Walk_Cycle_2", Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
           
            float distance = Vector3.Distance(transform.position, player.position);

           if(nav.speed>=1 && nav.speed<= 4 && !isDead)
            {
                controller.SetTrigger("Walk_Cycle_1");
            }

            if (Vector3.Distance(player.transform.position, transform.position) <= 4)
            {
                
                print("estamos dentro");
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    print("estamos dentro 2");


                }
                
                else
                {
                   
                    controller.SetTrigger("Attack_1");
                    playerhealth.TakeDamage(20);
                    timeRemaining = 1;
                    
                }
                
            }
            else
            {
                timeRemaining = 1;
                
                print("estamos fuera");
            }
           
        }
        

    }
   
   
    public void applyDamage(float damage)
    {
        //health -= damage;
        health -= (instaKillActivated) ? health : damage;
        if (!isDead)
        {
            GAMEMANAGEMENT.AddPoints(pointValue);
            if (health <= 0)
            {
                Death();
            }
        }
    }
    public void applyRPGDamage(float damage)
    {
        health -= damage;
        if (!isDead)
        {
            GAMEMANAGEMENT.AddPoints(pointValue);
            if (health <= 0)
            {
                Death();
            }
        }
    }

   public void Death()
    {
        isDead = true;
        
        nav.Stop();
        controller.SetTrigger("Die");
        nav.speed = 0f;
        capsuleCollider.enabled = false;
       
        GAMEMANAGEMENT.sombiesLeftInRound -= 1;
        GAMEMANAGEMENT.enemiesKilled++;
        GAMEMANAGEMENT.AddPoints(100);
        
        int randomDrop = Random.Range (1,1);
        int randomPickUp = Random.Range(0,pickups.Length);
        if(randomDrop < 2)
        {
            Instantiate(pickups[randomPickUp],transform.position+ new Vector3 (0,1f,0),Quaternion.Euler(0,0,0));
        }

        Destroy(gameObject, 4f);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "splashHit")
        {

            applyRPGDamage(100);
        }
    }

}
