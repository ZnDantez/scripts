using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float ver, hor, jump;
    public float moveSpeed = 10, jumpSpeed = 200;
    public bool isOnGround;

    private void OnCollisionStay(Collision otherCollision)
    {
        if (otherCollision.gameObject.tag == "Ground")
            isOnGround = true;
    }

    private void OnCollisionExit(Collision otherCollision)
    {
        if (otherCollision.gameObject.tag == "Ground")
            isOnGround = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnGround)
        {
            ver = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            hor = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;

            GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Impulse);
        }

        transform.Translate(new Vector3(hor, 0, ver));


    }
}
