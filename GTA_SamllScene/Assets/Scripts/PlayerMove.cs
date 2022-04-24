using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float vInput, hInput, movementSpeed, rotationSpeed;

    public Camera cam;
    [SerializeField]
    private float mouseXInput, mouseYInput;
    [SerializeField]
    private GameObject barrel;
    float xAngle;
    float yAngle;

    private bool isFire;
    private float timeStamp;
    private float fireRate;

    private bool isJump;
    private bool needFallAudio;
    private bool isGround;

    internal bool isWeaponed;


    // Start is called before the first frame update
    void Start()
    {
        isWeaponed = false;
        fireRate = 0.5f;
        timeStamp = 0f;
        movementSpeed = 3.0f;
        rotationSpeed = 100.0f;
        isFire = false;
        isGround = true;
        needFallAudio = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ExitGame();
    }

    void ExitGame() {

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Application.Quit();
        }
    
    }

    private void FixedUpdate()
    {
        Movement();
        CamControl();
        Fire();
        Jump();

    }

    void GetInput() {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

        if (Input.GetAxis("Fire1") != 0 && Time.time > timeStamp + fireRate && isWeaponed) {
            isFire = true;
            timeStamp = Time.time;
        }

        if (Input.GetAxis("Jump") != 0 && isGround ) {
            isJump = true;
            isGround = false;
        }
    }

    void Movement() {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * movementSpeed * vInput);

        transform.Rotate(Vector3.up * Time.fixedDeltaTime * rotationSpeed * hInput);

        //if (vInput != 0)
        if (Mathf.Abs(vInput) >0.9f && isGround)
        {
            PlayerSoundsManager.instance.Run();

        }
        float xAngle = rotationSpeed * Time.fixedDeltaTime * mouseYInput;
        float yAngle = rotationSpeed * Time.fixedDeltaTime * mouseXInput;
    }

    void Jump() {

        if (isJump) {
            isJump = false;
            needFallAudio = true;
            PlayerSoundsManager.instance.Jump();
            gameObject.transform.GetComponent<Rigidbody>().velocity = transform.up * Time.fixedDeltaTime * 200f;
        }
        //Debug.Log(gameObject.transform.GetComponent<Rigidbody>().velocity.y);


    }
    void Fire() {

        if (isFire) {

            isFire = false;
            BroadcastMessage("GenerateBullet");
        
        }
    
    }

    void CamControl() {
        //cam.transform.Rotate(-rotationSpeed * Time.fixedDeltaTime * mouseYInput, rotationSpeed * Time.fixedDeltaTime * mouseXInput, 0);
        cam.transform.Rotate(-rotationSpeed * Time.fixedDeltaTime * mouseYInput, 0, 0);
        Vector3 camAngle = cam.transform.localEulerAngles;
        if (camAngle.z != 0) {
            cam.transform.localEulerAngles = new Vector3(camAngle.x, camAngle.y, 0);
        }
        if (camAngle.x > 30 && camAngle.x < 90)
        {
            cam.transform.localEulerAngles = new Vector3(30.0f, camAngle.y, 0);
        }
        else if (camAngle.x < 330 && camAngle.x > 270)
        {
            cam.transform.localEulerAngles = new Vector3(330.0f, camAngle.y, 0);
        }

        //if (camAngle.y > 30 && camAngle.y < 90)
        //{
        //    cam.transform.localEulerAngles = new Vector3(camAngle.x, 30.0f, 0);
        //}
        //else if (camAngle.y < 330 && camAngle.y > 270)
        //{
        //    cam.transform.localEulerAngles = new Vector3(camAngle.x, 330.0f, 0);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground")) {
            //if()
            //Debug.Log(gameObject.transform.GetComponent<Rigidbody>().velocity.y);
            StartCoroutine("PlayFallClip");
        }
    }

    IEnumerator PlayFallClip() {
        //if(gameObject.GetComponent<Rigidbody>().velocity.y != 0)
        if (needFallAudio)
        {
            PlayerSoundsManager.instance.Fall();
            needFallAudio = false;
        }
        yield return new WaitForSeconds(0.481f);
        isGround = true;
    }

    public void GetWeapon() {
        isWeaponed = true;
        barrel.SetActive(true);
    }
}
