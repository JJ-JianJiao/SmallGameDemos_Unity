using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStar : MonoBehaviour
{

    public Texture2D texture;

    private void OnGUI()
    {
        Rect rect = new Rect(Input.mousePosition.x - (texture.width / 2), Screen.height - Input.mousePosition.y - (texture.height / 2), texture.width, texture.height);

        GUI.DrawTexture(rect, texture);
    }

}
