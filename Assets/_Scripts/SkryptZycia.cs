using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptZycia : MonoBehaviour {
    public GameObject zdrowie1, zdrowie2, zdrowie3, zdrowie4, zdrowie5, GameOver;
    private int zycie;
	// Use this for initialization
	void Start () {
        zycie = 5;
        GameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            switch (zycie)
            {
                case 1:
                    {
                        Debug.Log("GameOver");
                        zdrowie1.SetActive(false);
                        zycie--;
                        GameOver.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        zdrowie2.SetActive(false);
                        zycie--;
                        break;
                    }
                case 3:
                    {
                        zdrowie3.SetActive(false);
                        zycie--;
                        break;
                    }
                case 4:
                    {
                        zdrowie4.SetActive(false);
                        zycie--;
                        break;
                    }
                case 5:
                    {
                        zdrowie5.SetActive(false);
                        zycie--;
                        break;
                    }
            }
        }
		
	}
}
