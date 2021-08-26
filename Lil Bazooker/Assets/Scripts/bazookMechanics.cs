using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazookMechanics : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject Shell;
    private Vector3 mousePos;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Shell, shootPoint.position , transform.rotation);
        }
    }
}
