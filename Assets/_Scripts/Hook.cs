using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    public GameObject HookHead;
    public GameObject HookBody;
    public GameObject Player;
    public float HookSpeed;
    public float HookTime;
    private Camera cam;
    private float CurrentHookTime;
    private Vector2 movementVector;
    public bool Hooked;
    public bool Triggered;
    public Vector3 StayPosition;
    private DistanceJoint2D dj2d;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        CurrentHookTime = 0.0f;
        Hooked = false;
        Triggered = false;
        //HookBody.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Triggered)
        {
            HookHead.transform.position = StayPosition;

        }
        if (Input.GetMouseButtonDown(0) && Hooked == false)
        {

            float camDis = cam.transform.position.y - transform.position.y;
            Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

            float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) - transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

            movementVector.y = -1 * Mathf.Cos(AngleRad);
            movementVector.x = Mathf.Sin(AngleRad);
            Hooked = true;
        }

        if (Input.GetMouseButton(0) && Hooked)
        {
            if (CurrentHookTime < HookTime)
            {
                if (!Triggered)
                {
                    CurrentHookTime += Time.deltaTime;
                    HookHead.transform.Translate(movementVector.x * HookSpeed * Time.deltaTime, movementVector.y * HookSpeed * Time.deltaTime, 0);
                }else
                {
                    Hooked = false;
                    if (Player.GetComponent<DistanceJoint2D>() == null)
                    {
                        DistanceJoint2D dj2d = Player.AddComponent<DistanceJoint2D>();
                        dj2d.autoConfigureDistance = false;
                        dj2d.autoConfigureConnectedAnchor = false;
                        dj2d.connectedAnchor = new Vector2(StayPosition.x, StayPosition.y);
                        dj2d.enableCollision = true;
                        dj2d.distance = 2.0f;
                    }
                }
            }
            else
            {
                Hooked = false;
                CurrentHookTime = 0.0f;
                HookHead.transform.localPosition = new Vector3(0, 0.0f, 0);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Hooked = false;
            CurrentHookTime = 0.0f;
            HookHead.transform.localPosition = new Vector3(0, 0.0f, 0);
            Triggered = false;
            Destroy(Player.GetComponent<DistanceJoint2D>());

        }
    }

   public void TriggerEnter(HeadHook head)
    {
        if (Hooked)
        {
            StayPosition = head.transform.position;
            Triggered = true;
        }
    }

    public void TriggerExit(HeadHook head)
    {
        if (Hooked)
        {
            Triggered = false;
        }
    }
}
