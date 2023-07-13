using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
    }
}
