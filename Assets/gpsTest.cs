using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class gpsTest: MonoBehaviour
{
    public float lat;
    public float lon;


	public Text textoDistancia;
    IEnumerator coroutine;

    IEnumerator Start()
    {
        coroutine = updateGPS();
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start(0.1f,0.1f);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {

            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
        	textoDistancia.text = "Lat: " + lat + "      Lon:" + lon;
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            StartCoroutine(coroutine);
        }

        
    }

    IEnumerator updateGPS()
    {
        float UPDATE_TIME = 3f; //Every  3 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);

        while (true)
        {
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            textoDistancia.text = "Lat: " + lat + "      Lon:" + lon;
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            yield return updateTime;
        }
    }

    void stopGPS()
    {
        Input.location.Stop();
        StopCoroutine(coroutine);
    }

    void OnDisable()
    {
        stopGPS();
    }
}


    