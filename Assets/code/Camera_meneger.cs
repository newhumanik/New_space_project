using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_meneger : MonoBehaviour
{
    /*float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;*/
    public GameObject ship_player;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
     /*   lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;*/
        transform.position = new Vector3(ship_player.transform.position.x + 0.03f, ship_player.transform.position.y - 0.25f, ship_player.transform.position.z + 0.43f);
        transform.rotation = Quaternion.Euler(ship_player.transform.rotation.x, ship_player.transform.rotation.y + 180f, ship_player.transform.rotation.z);
    }
}
