using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float currentAngle;
    private float direct;
    public float maxAngle;
    public float weaponSpeed;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        currentAngle = 0.0f;
        direct = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 x_mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x_player = Player.transform.position.x;

        // Obracaj bronią
        if(currentAngle == 0)
        {
            if(x_mouse.x < x_player)
            {
                direct = 0;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }else
            {
                direct = 180.0f;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
        }

        
        if (Input.GetMouseButton(0))
        {
            if(currentAngle < maxAngle)
            {
                currentAngle += weaponSpeed * Time.deltaTime;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, direct, currentAngle));
            }else
            {
                currentAngle = 0.0f;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, direct, 0f));
            }
        }
        if (Input.GetMouseButtonUp(0) && currentAngle != 0.0f)
        {
            currentAngle = 0.0f;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }
}
