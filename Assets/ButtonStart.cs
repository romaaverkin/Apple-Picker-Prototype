using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void PlayPressed()
    {
        //Debug.Log("Start pressed!");
        SceneManager.LoadScene("_Scene_1");
    }
}
