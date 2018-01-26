using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private float currentAngle;
    public float maxAngle;
    public float weaponSpeed;

	// Use this for initialization
	void Start () {
        currentAngle = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if(currentAngle < maxAngle)
            {
                currentAngle += weaponSpeed * Time.deltaTime;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAngle));
            }else
            {
                currentAngle = 0.0f;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
    }
}
