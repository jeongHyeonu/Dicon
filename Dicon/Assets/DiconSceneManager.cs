using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiconSceneManager : MonoBehaviour
{
    public void MoveDroneFire()
    {
        SceneManager.LoadScene("DroneFire");
    }

    public void MoveDroneMountain()
    {
        SceneManager.LoadScene("DroneMountain");
    }

    public void MoveDroneCollapse()
    {
        SceneManager.LoadScene("DroneCollapse");
    }

    public void MoveStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
