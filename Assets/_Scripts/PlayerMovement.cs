using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public float jumpForce;
    public GameObject Eyes;
    public GameObject Hook;
    private bool isGrounded;
    private Camera cam;
    public int disabledLeft;
    public int disabledRight;
    public AudioSource jump;

    void Start () {
        isGrounded = false;
        cam = Camera.main;
        disabledLeft = 0;
        disabledRight = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A) && disabledLeft == 0)
        {
            transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (isGrounded)
            {  
                isGrounded = false;
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                jump.Play();
            }
        }

        float camDis = cam.transform.position.y - transform.position.y;
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad - 90.0f;

        Eyes.transform.eulerAngles = new Vector3(0, 0, angle);

        if (Hook.GetComponent<Hook>().Hooked == false && Hook.GetComponent<Hook>().Triggered == false)
            Hook.transform.eulerAngles = new Vector3(0, 0, angle);
       else if(Hook.GetComponent<Hook>().Triggered == true)
        {
            float NewAngleRad = Mathf.Atan2(Hook.GetComponent<Hook>().StayPosition.y - transform.position.y, Hook.GetComponent<Hook>().StayPosition.x - transform.position.x);
            float NewAngle = (180 / Mathf.PI) * NewAngleRad - 90.0f;
            Hook.transform.eulerAngles = new Vector3(0, 0, NewAngle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
