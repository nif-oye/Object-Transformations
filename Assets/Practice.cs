using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Practice : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    public float scaleSpeed = 1f;
    public TextMeshProUGUI transfromText;
    Vector3 position;
    Vector3 rotation;
    Vector3 scale;
    void Start()
    {
        
    }

    void Update()
    {
        moveObject();
        rotateObject();
        scaleObject();
        transformDisplay();
    }

    public void moveObject()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = 0f;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, moveZ);
    }

    public void rotateObject()
    {
        // rotation about y axis
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // rotation about x axis
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);
        }

        // rotation about z axis
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
    }

    public void scaleObject(){
        if (Input.GetKey(KeyCode.Equals))
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        }

        transform.localScale = new Vector3(
            Mathf.Clamp(transform.localScale.x, 0.1f, 10f),
            Mathf.Clamp(transform.localScale.y, 0.1f, 10f),
            Mathf.Clamp(transform.localScale.z, 0.1f, 10f)
        );
    }

    public void transformDisplay(){
        position = transform.position;
        rotation = transform.localEulerAngles;
        scale = transform.localScale;
        // transfromText.text = "Position: " + position + "\nRotation: " + rotation + "\nScale: " + scale;
        transfromText.text = $"Position: {position}\nRotation: {rotation} \nScale: {scale}";
    }
}
