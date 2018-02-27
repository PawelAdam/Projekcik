using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour {

    public GameObject specialWeapon;
    public GameObject bulletPosition;
    public GameObject bullet;
    public float force;
    private float lastWeaponUsage;
    public float TimeToNextShoot;
    public AudioSource shoot;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        
        lastWeaponUsage = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Time.time > lastWeaponUsage + TimeToNextShoot)
            {
                shoot.Play();
                float camDis = Camera.main.transform.position.y - Player.transform.position.y;
                Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

                float AngleRad = Mathf.Atan2(mouse.y - Player.transform.position.y, mouse.x - Player.transform.position.x) - (Player.transform.rotation.eulerAngles.z-90) * Mathf.Deg2Rad;

                float y = -1 * Mathf.Cos(AngleRad);
                float x = Mathf.Sin(AngleRad);

                GameObject b = Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
                b.SetActive(true);
                b.GetComponent<Rigidbody2D>().AddForce(new Vector2(force*x, force*y));
                
                lastWeaponUsage = Time.time;

                Destroy(b, 10);
            }
        }
    }
}
