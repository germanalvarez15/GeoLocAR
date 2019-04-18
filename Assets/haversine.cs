using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class haversine : MonoBehaviour {

	public float latObjeto = -8.72304f;
    public float lonObjeto = -8.722305f;
    //public GameObject objeto;
    //public MeshRenderer objetoMesh;
    public GameObject medieval;
    public Text textoHaversine;
    public gpsTest posicionJugador;
	// Use this for initialization
	void Start () {
		
	//objetoMesh = GameObject.Find("PuertaCiudadela").GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		operacion();
	}
	void operacion(){
        float R = 6371000; // metres
        float omega1 = ((posicionJugador.lat/180)*Mathf.PI);
        float omega2 = ((latObjeto/180)*Mathf.PI);
        float variacionomega1 = (((latObjeto - posicionJugador.lat)/180)*Mathf.PI);
        float variacionomega2 = (((lonObjeto - posicionJugador.lon) / 180) * Mathf.PI);
        float a = Mathf.Sin(variacionomega1/2) * Mathf.Sin(variacionomega1/2) +
                    Mathf.Cos(omega1) * Mathf.Cos(omega2) *
                    Mathf.Sin(variacionomega2/2) * Mathf.Sin(variacionomega2/2);
        float c = 2 * Mathf.Asin(Mathf.Sqrt(a));

        float d = R * c;
        int dEnInt = Mathf.RoundToInt(d);
        if (dEnInt > 150){
         	//objetoMesh.enabled = false;
         	medieval.SetActive(false);

        }else{
        	//objetoMesh.enabled = true;
        	medieval.SetActive(true);

        } 

        textoHaversine.text = dEnInt.ToString();

       
    }
}
