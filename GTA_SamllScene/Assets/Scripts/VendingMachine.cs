using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject vendingMachinePanel;
    [SerializeField]
    private GameObject weaponStorePanel;
    [SerializeField]
    private AudioSource openWeaponStorePanelAudio;

    //private bool isInTrigger;

    //private void Start()
    //{
    //    isInTrigger = false;
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && vendingMachinePanel.activeSelf) {
            //TODO: Open Weapon Selection Panel
            //Debug.Log("Open the weapon Selection Panel");
            weaponStorePanel.SetActive(true);
            openWeaponStorePanelAudio.Play();
            Time.timeScale = 0;
        }
        if (weaponStorePanel.activeSelf) {
            vendingMachinePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //isInTrigger = true;
        if (other.CompareTag("Player"))
            vendingMachinePanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //isInTrigger = false;
        if (other.CompareTag("Player"))
            vendingMachinePanel.SetActive(false);
    }
}
