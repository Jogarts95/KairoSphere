using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    private float velocity = 5f;

    private void Update() {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody>().AddForce(new Vector3(axisH * this.velocity, 0f, axisV * this.velocity));
    }
}
