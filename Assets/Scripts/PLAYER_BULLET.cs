using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_BULLET : MonoBehaviour {

    float bulletSpeed = 5f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
