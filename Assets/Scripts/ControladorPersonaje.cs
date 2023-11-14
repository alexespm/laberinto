using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    CharacterController controladorpersonaje;

    [Header("Ajuste de opciones de Personaje")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity =20.0f;
    
    [Header("Ajuste de opciones de Camara")]
    public Camera camara;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float hmouse, vmouse;

    private Vector3 move = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        controladorpersonaje = GetComponent<CharacterController>();
	Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        hmouse = mouseHorizontal * Input.GetAxis("Mouse X");
        vmouse += mouseVertical * Input.GetAxis("Mouse Y");
        vmouse = Mathf.Clamp(vmouse, minRotation, maxRotation);
        
        camara.transform.localEulerAngles = new Vector3(-vmouse, 0, 0);
        transform.Rotate(0, hmouse, 0);
	
	if(controladorpersonaje.isGrounded)
	{
		move = new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
		if(Input.GetKey(KeyCode.LeftShift))
		  move = transform.TransformDirection(move)*runSpeed;
		else
		  move = transform.TransformDirection(move)*walkSpeed;
		if(Input.GetKey(KeyCode.Space))
		  move.y = jumpSpeed;
	}
	move.y -= gravity *Time.deltaTime;
	controladorpersonaje.Move(move*Time.deltaTime);
	
    }
}
