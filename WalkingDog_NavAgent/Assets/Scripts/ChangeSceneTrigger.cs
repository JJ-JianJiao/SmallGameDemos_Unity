using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Application.LoadLevelAdditive(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.MoveGameObjectToScene()
        }
    }
}
