using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        //gravity 
        float vertical = rb.linearVelocity.y;
        if (cc.isGrounded)
        {
            vertical = 0f;
        }
        else
        {
            vertical -= 9.81f; // gravity
        }

        //move
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (input.magnitude > 1)
        {
            input.Normalize();
        }

        input.y = vertical; // apply gravity to input
        Vector3 move = transform.TransformDirection(input) * 5f * Time.deltaTime;
        cc.Move(move);

        

        //look
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = Mathf.Clamp(mouseX, -89, 89);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + mouseX, 0);
        Camera cam = Camera.main;
        if (cam != null)
        {
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x - mouseY, cam.transform.eulerAngles.y, 0);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if( hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                Debug.Log(hit.collider.gameObject.GetComponent<Interactable>().description);
                //talk to UI manager most likely
                UIManager uiManager = UIManager.GetInstance();
                
                StartCoroutine(uiManager.DisplayEventText(hit.collider.gameObject.GetComponent<Interactable>().description, 3));
                
            }
        }
    }
}
