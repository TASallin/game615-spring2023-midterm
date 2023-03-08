using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreDisplay;
    public TMP_Text healthDisplay;
    public GameObject winDisplay;
    public GameObject loseDisplay;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore() {
        score += 1;
        scoreDisplay.text = "Pizzas: " + score;
        if (score >= 10) {
            winDisplay.SetActive(true);
        }
    }

    public void SetHealth(int hp) {
        healthDisplay.text = "HP: " + hp;
        if (hp <= 0) {
            loseDisplay.SetActive(true);
        }
    }
}
