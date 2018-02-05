using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    public GameObject[] HP;
    public int EnemyHP;
    public bool collided;
    public GameObject weapon;
    // Use this for initialization
    void Start () {
        collided = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyHP == 0)
        {
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && weapon.GetComponent<Weapon>().currentAngle > 0)
        {
            if (!collided)
            {
                EnemyHP--;
                Destroy(HP[EnemyHP]);
                collided = true;
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            collided = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyHP--;
            Destroy(HP[EnemyHP]);
            collided = true;
        }
    }
}
