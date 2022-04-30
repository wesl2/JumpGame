using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField]float speed = 3000;
    [SerializeField] float Rs = 120f;


    Rigidbody rb;AudioSource As;
    // Start is called before the first frame update
    void Start()
    {
        startContent();
    }

    private void startContent()
    {
        rb = GetComponent<Rigidbody>();
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }
    void ProcessThrust()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            
             //相对自身坐标的力 相对世界坐标的用addForce
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
 
            //if (!As.isPlaying)
            //{ As.Play(); }
            ////相对自身坐标的力 相对世界坐标的用addForce
            //else
            //    As.Stop();
        }

    }
    void ProcessRotate()
    { 
         if(Input.GetKey(KeyCode.A))
        {
            ApplyRotate(Rs);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotate(-Rs);
        }
    }

    private void ApplyRotate(float rs)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rs * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
