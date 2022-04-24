using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem bombParticle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    //[System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        var blast = Instantiate(bombParticle, transform.position,transform.rotation);
        //blast.startColor = gameObject.GetComponent<MeshRenderer>().material.color;
        var main = blast.main;
        main.startColor = gameObject.GetComponent<MeshRenderer>().material.color;
        blast.Play();
        Destroy(this.gameObject);
    }
}
