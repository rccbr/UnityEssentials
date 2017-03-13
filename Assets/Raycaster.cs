using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public CubeInteractive currentObj;

    private float length = 100.0f;

    private int layerMask = 1 << 7;

	void Start ()
    {
	}
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * length, Color.yellow);

        if (Physics.Raycast(transform.position, transform.forward, out hit, length, ~layerMask))
        {
            currentObj = hit.collider.GetComponent<CubeInteractive>();

            if (currentObj.GetComponent<CubeItem>())
                layerMask = 1 << 8;

            if (currentObj != null)
                currentObj.Hover();
        }
        else
        {
            if (currentObj != null)
            {
                currentObj.Exit();

                if (currentObj.GetComponent<CubeItem>())
                    layerMask = 1 << 7;
            }
        }
    }
}
