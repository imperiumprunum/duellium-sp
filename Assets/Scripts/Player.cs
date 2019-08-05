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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        direction = input.normalized;
        velocity = direction * speed * Time.deltaTime;
        transform.Translate(velocity, Space.World);
        Debug.Log(input);
    }
}
