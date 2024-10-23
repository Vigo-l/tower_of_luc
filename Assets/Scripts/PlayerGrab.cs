using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform grabPointTransform;
    [SerializeField] private LayerMask pickupLayer;

    private Grabbable _grabbable;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_grabbable == null)
            { //grab object
                float pickupRange = 2f;
                if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit _hit, pickupRange))
                {
                    Debug.Log(_hit);
                    if (_hit.transform.TryGetComponent(out _grabbable))
                    {
                        Debug.Log("object has grab script");
                        _grabbable.Grab(grabPointTransform);
                    }
                }
            }
            else
            { //drop object
                _grabbable.Drop();
                _grabbable = null;
            }
        }   

    }
}
