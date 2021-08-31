using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform player;

    public GameObject habilityPreview;
    public GameObject hability;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            habilityPreview.SetActive(true);

            RaycastHit hitAttack;
            Ray rayAttack = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(rayAttack, out hitAttack, Mathf.Infinity))
            {
                float floorHeight = hitAttack.point.y;
                Vector3 center = new Vector3(transform.position.y, floorHeight, transform.position.z);

                Vector3 dir = hitAttack.point - center;
                dir = new Vector3(dir.x, 0, dir.z);

                Vector3 castDir = habilityPreview.transform.position - center;
                castDir = new Vector3(castDir.x,0, castDir.z);

                float sAngle = Vector3.SignedAngle(dir, castDir, Vector3.up);

                int sign = (sAngle >= 0) ? 1 : -1;
                float angle = Mathf.Abs(sAngle);
                if (angle > 0.3f) 
                    habilityPreview.transform.RotateAround(center, Vector3.up, -sign * angle);
            }
        }
    }
}
