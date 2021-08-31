using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    private CharacterController _player;

    private float _holdDownStartTime;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            //Debug.Log("Attack!");
            _holdDownStartTime =  Time.time;
        }  
        
        if (Input.GetKeyUp(KeyCode.K)) {

            float holdDownTime = Time.time - _holdDownStartTime;

            //Debug.Log($"Release! - {CalculateHoldDownForce(holdDownTime)}s");
        }
    }

    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceTime);
        float force = holdTimeNormalized * CharacterController.MAX_FORCE;
        return force;
    }
}
