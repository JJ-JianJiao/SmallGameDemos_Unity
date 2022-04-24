using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponStorePanelControl : MonoBehaviour
{
    private Image m_image;
    private bool isOpen;

    [SerializeField]
    private GameObject vendingMachinePanel;
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Image mainImage;
    [SerializeField]
    Image leftWeaponImage;
    [SerializeField]
    Image rightWeaponImage;
    [SerializeField]
    Button leftBtn;
    [SerializeField]
    Button equipBtn;
    [SerializeField]
    Button rightBtn;
    [SerializeField]
    TMP_Text tmpText;    
    [SerializeField]
    Button closeBtn;
    [SerializeField]
    GameObject playerbarrel;
    [SerializeField]
    private AudioSource welcomAudio, browserWeaponAudio;

    [SerializeField]
    private Animator mainImageAnim,leftImageAnim,rightImageAnim;


    private int weaponIndex;
    private int leftWeaponIndex;
    private int rightWeaponIndex;

    private void Awake()
    {
        leftBtn.gameObject.SetActive(false);
        leftWeaponImage.gameObject.SetActive(false);
        tmpText.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        rightWeaponImage.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        mainImage.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
        weaponIndex = 0;
        //leftWeaponIndex = weaponIndex + 1;
        //rightWeaponIndex = sprites.Length - 1;
        leftWeaponIndex = sprites.Length - 1;
        rightWeaponIndex = weaponIndex + 1;
        mainImage.sprite = sprites[weaponIndex];
        leftWeaponImage.sprite = sprites[leftWeaponIndex];
        rightWeaponImage.sprite = sprites[rightWeaponIndex];
        m_image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        isOpen = false;
        m_image.fillAmount = 0;
        Cursor.visible = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (m_image.fillAmount < 1 && !isOpen)
        {
            isOpen = true;
            StartCoroutine("PanelShowProcess");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeSelf && m_image.fillAmount==1) {
            ClosePanel();
            gameObject.SetActive(false);
            //vendingMachinePanel.SetActive(true);
        }
    }    

    IEnumerator PanelShowProcess() {
        while (m_image.fillAmount < 1)
        {
            m_image.fillAmount += 0.01f;
            if (m_image.fillAmount > 0.25 && !leftBtn.gameObject.activeSelf && !leftWeaponImage.gameObject.activeSelf) {
                leftBtn.gameObject.SetActive(true);
                leftWeaponImage.gameObject.SetActive(true);
            }
            if (m_image.fillAmount > 0.5 && !tmpText.gameObject.activeSelf) {
                tmpText.gameObject.SetActive(true);
                closeBtn.gameObject.SetActive(true);
            }
            if (m_image.fillAmount > 0.75 && !rightBtn.gameObject.activeSelf && !rightWeaponImage.gameObject.activeSelf)
            {
                rightBtn.gameObject.SetActive(true);
                rightWeaponImage.gameObject.SetActive(true);
            }
            //yield return new WaitForSeconds(0.001f);
            yield return new WaitForSecondsRealtime(0.001f);
            //yield return new WaitForSeconds(1f);
        }
        mainImage.gameObject.SetActive(true);
        equipBtn.gameObject.SetActive(true);
        welcomAudio.Play();
    }

    public void LeftBtnOnClick() {
        //mainImageAnim.SetBool("goLeft", true);
        //browserWeaponAudio.Play();
        StartCoroutine("leftBtnAnimEvent");
    }

    IEnumerator leftBtnAnimEvent() {
        //mainImageAnim.SetBool("goLeft", true);
        //rightImageAnim.SetBool("goLeft", true);
        mainImageAnim.SetBool("goRight", true);
        leftImageAnim.SetBool("goRight", true);
        browserWeaponAudio.Play();
        yield return new WaitForSecondsRealtime(0.22f);
        //mainImageAnim.SetBool("goLeft", false);
        //rightImageAnim.SetBool("goLeft", false);
        mainImageAnim.SetBool("goRight", false);
        leftImageAnim.SetBool("goRight", false);
        weaponIndex--;
        if (weaponIndex < 0)
        {
            weaponIndex = sprites.Length - 1;
        }
        mainImage.sprite = sprites[weaponIndex];

        leftWeaponIndex--;
        if (leftWeaponIndex < 0)
        {
            leftWeaponIndex = sprites.Length - 1;
        }
        leftWeaponImage.sprite = sprites[leftWeaponIndex];

        rightWeaponIndex--;
        if (rightWeaponIndex < 0)
        {
            rightWeaponIndex = sprites.Length - 1;
        }
        rightWeaponImage.sprite = sprites[rightWeaponIndex];
    }

    public void RightBtnOnClick()
    {
        StartCoroutine("RightBtnAnimEvent");

    }

    IEnumerator RightBtnAnimEvent() {
        //leftImageAnim.SetBool("goRight", true);
        //mainImageAnim.SetBool("goRight", true);
        rightImageAnim.SetBool("goLeft", true);
        mainImageAnim.SetBool("goLeft", true);
        browserWeaponAudio.Play();
        yield return new WaitForSecondsRealtime(0.22f);
        //mainImageAnim.SetBool("goRight", false);
        //leftImageAnim.SetBool("goRight", false);
        mainImageAnim.SetBool("goLeft", false);
        rightImageAnim.SetBool("goLeft", false);

        weaponIndex++;
        if (weaponIndex == sprites.Length)
        {
            weaponIndex = 0;
        }
        mainImage.sprite = sprites[weaponIndex];

        leftWeaponIndex++;
        if (leftWeaponIndex == sprites.Length)
        {
            leftWeaponIndex = 0;
        }
        leftWeaponImage.sprite = sprites[leftWeaponIndex];

        rightWeaponIndex++;
        if (rightWeaponIndex == sprites.Length)
        {
            rightWeaponIndex = 0;
        }
        rightWeaponImage.sprite = sprites[rightWeaponIndex];

    }

    public void ClosePanel() {
        leftBtn.gameObject.SetActive(false);
        leftWeaponImage.gameObject.SetActive(false);
        tmpText.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        rightWeaponImage.gameObject.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        mainImage.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
        Time.timeScale = 1;
        vendingMachinePanel.SetActive(true);
        Cursor.visible = false;
    }

    public void EquipBtnOnClick() {

        PlayerMove playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        if (!playerMove.isWeaponed)
            playerMove.GetWeapon();
        WeaponSoundManager.instance.ChangeWeapon();
        playerbarrel.GetComponent<PlayerBarrel>().ChangeWeaponMateria(weaponIndex);
        ClosePanel();
        gameObject.SetActive(false);
    }


}
