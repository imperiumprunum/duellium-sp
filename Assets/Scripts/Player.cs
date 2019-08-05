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
    Object bulletPrefab;

	// Use this for initialization
	void Start () {
        bulletPrefab = Resources.Load("Prefabs/PLAYER_BULLET");
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        TrackCursor();
        Shoot();
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
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position ,transform.rotation);
        }
    }
}
