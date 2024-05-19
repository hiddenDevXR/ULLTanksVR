using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RayCastPlacer : MonoBehaviour
{
    public GameObject prefabToSpawn;
    GameObject spawnedObject;
    bool objectIsSpawned;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    int detected = 0;

    private void Start()
    {
        objectIsSpawned = false;
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && detected == 0)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;
                if(!objectIsSpawned)
                {
                    spawnedObject = Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
                    objectIsSpawned = true;
                    detected = 1;
                }

                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }
}
