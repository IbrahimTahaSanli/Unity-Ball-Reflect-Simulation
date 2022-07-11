using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] SphereCollider colli;
    [SerializeField] Rigidbody rigid;

    [SerializeField] float raycastMaxDistance;

    private void OnTriggerEnter(Collider other){
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, this.rigid.velocity.normalized, out hit, raycastMaxDistance))
        {
            //Aç?ya ses ayarlamak için
            float mag = this.rigid.velocity.magnitude;
            Debug.DrawRay(hit.point, -this.rigid.velocity *10000, Color.red, 100000);
            Debug.DrawRay(hit.point, hit.normal * 1, Color.blue, 100000);
            Vector3 refl =-2*(Vector3.Dot( this.rigid.velocity.normalized, hit.normal) * hit.normal) +this.rigid.velocity.normalized;
            Debug.DrawRay(hit.point, refl*100000, Color.green, 10000);
            this.rigid.velocity = refl * mag;

        }
    }
}
