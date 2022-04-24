using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CononController : MonoBehaviour
{
    public float hInput;
    public float vInput;
    public float barrelInput;
    public float rotateSpeed;
    public float fireSpeed;
    public float barrelRotateSpeed;
    public Vector3 barrelAngles;
    public float movementSpeed;
    public float fireRate;
    public AudioSource fireAudio;
    private float timeStamp;
    private Animator anim;

    public GameObject fireParticleSystem;
    private ParticleSystem firePart;

    public GameObject barrel;
    public GameObject projectile;
    public Transform barrelEnd;

    [Header("Recoil")]
    public Transform origianlPos;
    public Transform recoilPos;
    public float recoilSpeed;

   

    // Start is called before the first frame update
    void Start()
    {
        firePart = fireParticleSystem.GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {


        Movement();
        Shoot();
        BarrelRecoil();
    }

    void Movement() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * movementSpeed * Time.fixedDeltaTime * -vInput);
        transform.Rotate(transform.up * rotateSpeed * Time.fixedDeltaTime * hInput);

        barrelInput = Input.GetAxis("Barrel");
        barrel.transform.Rotate(-transform.up * Time.fixedDeltaTime * barrelInput * barrelRotateSpeed);
        barrelAngles = barrel.transform.localRotation.eulerAngles;
        //Debug.Log(barrelAngles);
        if (barrelAngles.y > 12 && barrelAngles.y < 180)
        {
            barrel.transform.localRotation = Quaternion.Euler(barrelAngles.x, 12.0f, barrelAngles.z);
        }
        else if (barrelAngles.y < 330 && barrelAngles.y > 180)
        {
            barrel.transform.localRotation = Quaternion.Euler(barrelAngles.x, 330f, barrelAngles.z);

        }
    }

    void BarrelRecoil()
    {

        barrel.transform.Translate(barrel.transform.right * recoilSpeed * Time.fixedDeltaTime);
        //barrel.transform.SetParent(null);
        //barrel.transform.Translate(barrel.transform.up * recoilSpeed * Time.fixedDeltaTime);

    }
    void Shoot() {

        if (Input.GetKey(KeyCode.Space) && Time.fixedTime > timeStamp + fireRate) {
            firePart.Play();
            fireAudio.Play();
            //anim.SetTrigger("Fire2");
            anim.SetBool("Fire", true);
            //Invoke("StopFireAnim", 0.05f);
            var bullet = Instantiate(projectile, barrelEnd.position, barrelEnd.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * fireSpeed;
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), bullet.gameObject.GetComponent<Collider>(), true);
            timeStamp = Time.fixedTime;

        }
        //else
        //{
        //    anim.SetBool("Fire", false);


        //}
        //anim.SetBool("Fire", false);

    }

    void StopFireAnim() {
        anim.SetBool("Fire", false);
    }


}
