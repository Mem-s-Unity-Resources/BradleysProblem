using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    bool grounded = false;
    public float walk_speed = 4.0f;
    public float run_speed = 8.0f;
    public float turnSensitivity = 5.0f;
    Vector3 velocity= Vector3.zero;
    float currspeed;
    public AnimationCurve accelaration;
    // Start is called before the first frame update
    float currentRotation = 0; //Stores current rotation value calculated by the functions below
    bool collision;
    public float displacement = 0.5f;
    // Update is called once per frame
    void Update()
    {
        float h= Input.GetAxis("Horizontal");
        float v=Input.GetAxis("Vertical");
        Ray ray = new Ray(new Vector3(transform.position.x, 1f, transform.position.z), transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f))
        {
            // collision = true;
            Debug.DrawRay(new Vector3(transform.position.x, 1f, transform.position.z), transform.forward * 1f, Color.red);
            //Debug.Log("RayHit: "+ hit.collider.name);
        }
        else {
            Debug.DrawRay(new Vector3(transform.position.x, 1f, transform.position.z), transform.forward * 1f, Color.green);
            currspeed = Mathf.Lerp(0, v, Time.deltaTime) * (Input.GetKey(KeyCode.LeftShift) ? run_speed : walk_speed);
            transform.position += transform.forward * accelaration.Evaluate(currspeed);
            transform.position = new Vector3(transform.position.x, displacement, transform.position.z);
            //Debug.Log("Player: " + v + " " + currspeed);
        }



        //float h = Input.GetAxisRaw("Horizontal"); //left & right input from either keyboard or controller

        Quaternion newRotation;

        currentRotation += h * turnSensitivity;
        //currentRotation = Mathf.Repeat(currentRotation, 360);
        newRotation = Quaternion.Euler(0, currentRotation, 0);
        transform.rotation = newRotation;
    }

}
