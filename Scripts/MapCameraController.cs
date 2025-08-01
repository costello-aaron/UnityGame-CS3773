using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    Vector3 lastPosition = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //zoom in
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //for some reason scroll down is positive while scroll up is negative
        if((-scroll < 0 && Camera.main.fieldOfView > 10) || (-scroll > 0 && Camera.main.fieldOfView < 60))
        {
            Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * -10;
        }
        

        //move
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            delta *= Time.deltaTime;
            if(Camera.main.transform.position.y + delta.y > -10 && Camera.main.transform.position.y + delta.y < 10) //vertical bounding box
            {
                if(Camera.main.transform.position.x + delta.x > -10 && Camera.main.transform.position.x + delta.x < 10)//horizontal bounding
                    transform.Translate(delta.x, delta.y, 0);
            }


            
            lastPosition = Input.mousePosition;
        }
        
        
    }
}
