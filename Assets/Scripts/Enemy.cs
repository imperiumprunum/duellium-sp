using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject player;
    //  MOVEMENT
    Vector3 input;
    Vector3 direction;
    Vector3 velocity;
    float magnitiude;
    [SerializeField]
    float speed;
    //  BULLETS
    bool isRunning;
    [SerializeField]
    float timeBetweenShots;


    GameObject bulletPrefab;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("PLAYER");
        bulletPrefab = (GameObject)Resources.Load("Prefabs/PLAYER_BULLET");


	}
	
	// Update is called once per frame
	void Update () {
       Movement();
       HeadTowardsPlayer();
        if (!isRunning)
            StartCoroutine(shotBullets(timeBetweenShots));
    }

    void Movement()
    {
        direction = (player.transform.position - transform.position).normalized;
        velocity = speed * direction;
        transform.Translate(velocity * Time.deltaTime);
    }

    void HeadTowardsPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }


    IEnumerator shotBullets(float timeBetweenShots)
    {
        isRunning = true;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenShots);
        isRunning = false;
    }
}
