using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject bombParticleSystem;
    //private ParticleSystem part;

    //private void Start()
    //{
    //    part = bombParticleSystem.GetComponent<ParticleSystem>();
    //}


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.CompareTag("Coll")) {
        //    gameObject.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 4.0f);
        //}
        //if(collision.transform.CompareTag)
        //var partSystem = Instantiate(bombParticleSystem, collision.collider.ClosestPoint(transform.position), Quaternion.identity);

        if (collision.transform.tag == "Paintable")
        {
            WallStatus wallStatus = collision.gameObject.GetComponentInParent<WallStatus>();
            if (wallStatus != null)
                wallStatus.GetPainted();
            //else {
            //    gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000, transform.position, 4.0f);
            //}
        }
        //else {

        //    gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000, transform.position, 4.0f);

        //}
        var partSystem = Instantiate(bombParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
