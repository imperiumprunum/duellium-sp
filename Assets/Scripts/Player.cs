using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //  MOVEMENT
    Vector3 input;
    Vector3 direction;
    Vector3 velocity;
    [SerializeField]
    float speed;

    //  BULLET
    GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        bulletPrefab = (GameObject)Resources.Load("Prefabs/PLAYER_BULLET");
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        //TrackCursor();
        Shoot();
        Debug.DrawLine(Vector3.zero, transform.position, Color.green);
        Dash(250);
        Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.blue);
        Rotate();
    }

    void Rotate()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

    }

    void Movement()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        direction = input.normalized;
        velocity = direction * speed * Time.deltaTime;
       transform.Translate(velocity, Space.World);
    }

    void TrackCursor()
    {
        Vector3 camDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = -(Mathf.Atan2(camDir.x, camDir.y) * Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * 4000 * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
             Instantiate(bulletPrefab, transform.position ,transform.rotation);
        }
    }

    void Dash(float dashLength)
    {
        LayerMask mask = LayerMask.GetMask("Obstacles");
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        dir = new Vector3(dir.x, dir.y, 0);
        Debug.DrawRay(dir, Vector3.up * 20);


        //Debug.DrawRay(transform.position, dir * 200, Color.red);
        Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.white);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, dir, 1000, mask);


        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.position += (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * dashLength * Time.deltaTime;
            }
            else
            {
                transform.position += (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * dashLength * Time.deltaTime * -1;
            }
            //  prevent Z-axis translation
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            dashLength = 250;
        }


    }
    







}
