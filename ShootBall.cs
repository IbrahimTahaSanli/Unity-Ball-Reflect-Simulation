using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Rigidbody rigid;

    [SerializeField] float forceMultiplier;

    public void Shoot(Vector3 forceDirection){
        Debug.Log(forceDirection);
        this.rigid.velocity = Vector3.zero;

        this.transform.position = camera.position;
        Debug.Log(this.transform.position);
        this.rigid.AddForce(forceDirection * forceMultiplier);
    }
}
