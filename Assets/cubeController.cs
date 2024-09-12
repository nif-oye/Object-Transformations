using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cubeController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float scaleSpeed = 3;
    public TextMeshProUGUI textDisplay;
    void Start()
    {
        
    }

    void Update()
    {
        moveCube();
        rotateCube();
        scaleCube();
        displayTransform();
    }

    void moveCube(){
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = 0f;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, moveZ);
    } 

    void rotateCube(){
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(UnityEngine.Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)){
            transform.Rotate(UnityEngine.Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R)){
            transform.Rotate(UnityEngine.Vector3.right * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.T)){
            transform.Rotate(UnityEngine.Vector3.right * -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(UnityEngine.Vector3.forward * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(UnityEngine.Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }

    void scaleCube(){
        if (Input.GetKey(KeyCode.Equals))
        {
            transform.localScale += UnityEngine.Vector3.one * scaleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            transform.localScale += UnityEngine.Vector3.one * -scaleSpeed * Time.deltaTime;
        }

        transform.localScale = new UnityEngine.Vector3(
            Mathf.Clamp(transform.localScale.x, 0.1f, 10),
            Mathf.Clamp(transform.localScale.y, 0.1f, 10),
            Mathf.Clamp(transform.localScale.z, 0.1f, 10)
        );
    }

    void displayTransform(){
        UnityEngine.Vector3 position = transform.position; 
        UnityEngine.Vector3 rotation = transform.eulerAngles;
        UnityEngine.Vector3 scale = transform.localScale;

        textDisplay.text = $"Position: {position} \nRotation: {rotation} \nScale: {scale}";
    }
}
