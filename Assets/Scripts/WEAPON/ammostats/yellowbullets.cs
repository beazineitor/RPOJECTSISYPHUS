using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yellowbullets : MonoBehaviour
{
    public yellowrifle yellowAmmo;
    public GameObject rifle;
    Text ammoText;
    // Start is called before the first frame update
    private void Awake()
    {
        ammoText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = yellowAmmo.currentBullets.ToString();
    }
}
