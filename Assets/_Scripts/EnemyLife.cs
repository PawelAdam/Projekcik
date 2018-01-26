using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    public GameObject[] HP;
    public int EnemyHP;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyHP == 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnMouseDown()
    {
        EnemyHP--;
        Destroy(HP[EnemyHP]);
    }
}
