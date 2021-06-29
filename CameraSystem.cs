using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag ("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //makes the Camera follow the player
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

    // FixCamera fixes the camera in place so that it doesn't follow the player
    public void FixCamera(float xMax, float yMax)
    {
        this.xMax = xMax;
        this.yMax = yMax;
        this.xMin = xMax;
        this.yMin = yMax;
    }

    // FreeCamera makes the camera follow the player again
    public void FreeCamera()
    {
        xMax = 100;
        yMax = 0;
        xMin = 0;
        yMin = 0;
    }
}
