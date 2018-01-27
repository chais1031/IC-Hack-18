using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sc : MonoBehaviour

{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        FixedUpdate();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*100);
    }
}
