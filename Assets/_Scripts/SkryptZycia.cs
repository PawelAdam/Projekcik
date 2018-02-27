using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkryptZycia : MonoBehaviour {
    public Image[] HP;
    public int PlayerHP;
    private bool enemyCollision;
    public Text GameOver;
    public Material background;
    public float takeHPTime; // IN seconds
    private float currentTakeHPTime;
    private bool takeHP;
    private Color materialColor;
    private bool czy_przegrał;
    // Use this for initialization
    void Start () {
        enemyCollision = false;
        GameOver.enabled = false;
        currentTakeHPTime = 0;
        takeHP = true;
        materialColor = Color.white;
        background.color = materialColor;
        czy_przegrał = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(!takeHP)
        {
            if(currentTakeHPTime < takeHPTime)
            {
                materialColor.g = 1 - ((currentTakeHPTime / takeHPTime));
                materialColor.b = 1- ((currentTakeHPTime / takeHPTime));
                currentTakeHPTime += Time.deltaTime;
                background.color = materialColor;
            }
            else
            {
                background.color = Color.white;
                currentTakeHPTime = 0;
                takeHP = true;
            }
        }
        if (enemyCollision && takeHP)
        { 
            enemyCollision = false;
           if(PlayerHP > 0)
            {
                takeHP = false;
                PlayerHP--;
                HP[PlayerHP].enabled = false;
            }
        }

        if(PlayerHP <= 0)
        {
            Time.timeScale = 0;
            //Koniec Gry  
            if (!czy_przegrał)
            {
                GameOver.enabled = true;
                czy_przegrał = true;
            }

            if (Input.GetKey(KeyCode.Escape))
                GameOver.enabled = false;
        }
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet") && takeHP)
        {
            enemyCollision = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "addLife"){
            if(PlayerHP < 5 && PlayerHP > 0)
            {
                HP[PlayerHP].enabled = true;
                PlayerHP++;
                Destroy(collision.gameObject);
            }
        }
    }
}
