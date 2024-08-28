using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamTransform : MonoBehaviour
{

    public Transform playerTransform;
    [Tooltip("% Threshold to trigger camera movement in Y direction")]
    [Range(0.0f, 1.0f)]
    public float thresholdY;
   


    private Camera camMain;
    private float _screenHeight;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        camMain = GetComponent<Camera>();
        _screenHeight = camMain.pixelHeight;
        Debug.Log(_screenHeight);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerTransform != null)
        {
            Vector3 screenPos = camMain.WorldToScreenPoint(playerTransform.position);
            //  Debug.Log(screenPos.y);
            if (screenPos.y > (_screenHeight * thresholdY))
            {

                Vector3 targetPosition = new Vector3(0.0f, playerTransform.position.y + 1000.0f, this.transform.position.z);

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 200.0f);
            }
        

        }
    }
}
