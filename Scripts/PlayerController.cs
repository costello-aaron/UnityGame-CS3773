using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private Rigidbody rb;
    private int speed = 5;
    private UIManager UImanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        UImanager = UIManager.GetInstance();
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
     
        //sprint
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
        }
        Vector3 move = transform.TransformDirection(input) * speed * Time.deltaTime;
        cc.Move(move);

        

        //look
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = Mathf.Clamp(mouseX, -89, 89);

        
        Camera cam = Camera.main;
        if (cam != null && Time.deltaTime > 0)//dont look if paused
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + mouseX, 0);
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x - mouseY, cam.transform.eulerAngles.y, 0);
        }

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5);
        if(hit.collider != null && hit.collider.tag == "Interactable")
        {
            UImanager.DisplayEventText("Press Left Mouse to Interact!");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interact(hit);
            }
        }
        else
        {
            UImanager.DisplayEventText("");
        }
       
    }

    public void Interact(RaycastHit hit)
    {
        if( hit.collider.gameObject.GetComponent<Interactable>() != null)
        {

            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            interactable.OnInteract();
                
                
        }
        
    }
}
