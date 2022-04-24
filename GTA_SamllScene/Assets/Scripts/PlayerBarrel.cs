using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    //[SerializeField]
    //private List<Color> colors;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject shootPostion;

    [SerializeField]
    private ParticleSystem fireParticle;

    private void Start()
    {
        //colors.Add(Color.red);
        //colors.Add(Color.green);
        //colors.Add(Color.yellow);
        //colors.Add(Color.blue);
        //colors.Add(new Color(146f/255f,39f/255f,143f/255f,1));
    }

    public void ChangeWeaponMateria(int index) {
        //material.color = colors[index];
        gameObject.GetComponent<MeshRenderer>().material = materials[index];

    }

    private void GenerateBullet() {
        WeaponSoundManager.instance.Fire();
        fireParticle.Play();
        var bullet = Instantiate(projectile, shootPostion.transform.position, gameObject.transform.localRotation);
        bullet.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bullet.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().velocity = shootPostion.transform.forward * 15f;
    }
}
