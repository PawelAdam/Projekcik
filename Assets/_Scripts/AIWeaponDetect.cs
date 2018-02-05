using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponDetect : MonoBehaviour {

    public GameObject EnemyParent;
    private AIMovement Enemy;

    private void Start()
    {
        Enemy = EnemyParent.GetComponent<AIMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            if (Enemy.Direction == 0)
                Enemy.Direction = 1;
            else
                Enemy.Direction = 0;
        }
    }
}
