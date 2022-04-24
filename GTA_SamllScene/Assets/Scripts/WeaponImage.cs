using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponImage : MonoBehaviour
{
    public void FinishLeftAnimation() {
        this.gameObject.GetComponent<Animator>().SetBool("goLeft", false);
    }
}
