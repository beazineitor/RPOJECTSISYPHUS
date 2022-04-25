using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour
{
    public GAMEMANAGEMENT checkRound; 
    public Text pointsEarned;
    public Text killStreak;
    public Text currentRound;
    // Start is called before the first frame update
    private void Awake()
    {
        pointsEarned = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsEarned.text = GAMEMANAGEMENT.playerScore.ToString();
        killStreak.text = GAMEMANAGEMENT.enemiesKilled.ToString();
        currentRound.text = GAMEMANAGEMENT.round.ToString();

    }
}
