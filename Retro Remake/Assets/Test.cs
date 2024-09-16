using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private bool _thrusting;
    
    private float _turnDirection;

    private void Update()
    {
        _thrusting =  (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0f;
        } else if ()
        
    }
}
