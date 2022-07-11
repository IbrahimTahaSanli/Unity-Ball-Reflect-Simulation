using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] Transform cube;
    [SerializeField] Vector3 angle;
    [SerializeField] float rotateSpeed;
    [SerializeField] float spaceBetween;

    [SerializeField] ShootBall ballShot;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.mousePosition.x > 0) && (Input.mousePosition.x < Screen.width) && (Input.mousePosition.y > 0) && (Input.mousePosition.y < Screen.height))
        {
            angle.y = (((Input.mousePosition.y / Screen.height) - 0.5f) * rotateSpeed) * 2;
            angle.x = (((Input.mousePosition.x / Screen.width) - 0.5f) * rotateSpeed) * 2;

            angle.z = Mathf.Sin(angle.x) * Mathf.Cos(angle.y);
            angle.x = Mathf.Cos(angle.x) * Mathf.Cos(angle.y);
            angle.y = Mathf.Sin(angle.y);


            this.transform.position = angle.normalized * spaceBetween;
            this.transform.LookAt(cube.position);
        }
        if(Input.GetMouseButtonDown(0)){
            Debug.Log(this.cube.position + " - " + this.transform.position);
            ballShot.Shoot((this.cube.position - this.transform.position)/this.spaceBetween);
        }
    }
}
