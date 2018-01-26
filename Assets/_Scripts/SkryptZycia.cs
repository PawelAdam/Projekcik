using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkryptZycia : MonoBehaviour {
    public Image[] HP;
    public int PlayerHP;
    private bool enemyCollision;
	// Use this for initialization
	void Start () {
        enemyCollision = false;
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
            }else
            {
              //Koniec Gry  
            }
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
