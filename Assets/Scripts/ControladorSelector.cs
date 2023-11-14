using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorSelector: MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    public Texture2D puntero;
    public GameObject TextoDetectado;
    GameObject ultimoReconocimiento=null;
    
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("RayCastDetectado");
	TextoDetectado.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
	
	if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,distancia,mask))
	{
	     DeseleccionarObjeto();
             SeleccionarObjeto(hit.transform);
	     if(hit.collider.tag == "AccesoInteractivo")
	     {
		if(Input.GetKeyDown(KeyCode.E))
	   	{
 	      	   hit.collider.transform.GetComponent<ObjetoInteractivo>().QuitarObjeto();
       	   	}	
             }
	     Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*distancia, Color.red);
	}
        else
	{
	   DeseleccionarObjeto();
	}
    }

    void SeleccionarObjeto(Transform transform)
    {
       transform.GetComponent<MeshRenderer>().material.color = Color.green;
       ultimoReconocimiento = transform.gameObject;
    }

    void DeseleccionarObjeto()
    {
       if(ultimoReconocimiento)
       {
          Color newColor = new Color32(120, 76, 7, 255);
	  ultimoReconocimiento.GetComponent<Renderer>().material.color = newColor;
	  ultimoReconocimiento = null;
       }
    }

    void OnGUI()
    {
       Rect rect = new(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
       GUI.DrawTexture(rect, puntero);
       if(ultimoReconocimiento)
       { 
          TextoDetectado.SetActive(true);
       }
       else
       {
    	  TextoDetectado.SetActive(false);
       }
    }
}
