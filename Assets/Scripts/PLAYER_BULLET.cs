using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_BULLET : MonoBehaviour {

    float bulletSpeed = 4f;
    bool IS_BOUNCED = false;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
                transform.Rotate(Vector3.forward * 240, Space.World);

            if (IS_BOUNCED)
                Destroy(gameObject);
            IS_BOUNCED = true;
    }

    }

    int QuadrantToAngle(int x, int y)
    {
        if (x > 0 && y > 0)
            return 300;
        if (x > 0 && y < 0)
            return 60;
        if(x < 0 && y < 0)
            return 45;
        if (x < 0 && y > 0)
            return 240;

        return 0;

    }
}
