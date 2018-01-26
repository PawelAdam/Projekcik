using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkryptZycia : MonoBehaviour {
    public Image[] HP;
    public int PlayerHP;
    private bool enemyCollision;
    public Text GameOver;

	// Use this for initialization
	void Start () {
        enemyCollision = false;
        GameOver.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (enemyCollision)
        {
            
            enemyCollision = false;
           if(PlayerHP > 0)
            {
                PlayerHP--;
                HP[PlayerHP].enabled = false;
            }
        }

        if(PlayerHP == 1)
        {
            //Koniec Gry  
            GameOver.enabled = true;
        }
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemyCollision = true;
        }
    }
}
