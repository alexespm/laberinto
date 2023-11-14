using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public float velocidad = 2;
    Rigidbody personajerigidbody;
    // Start is called before the first frame update
    void Start()
    {
        personajerigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
	float horizontal = Input.GetAxis("Horizontal");
	
	personajerigidbody.AddForce(new Vector3(horizontal,0,vertical)*velocidad);
    }
}
