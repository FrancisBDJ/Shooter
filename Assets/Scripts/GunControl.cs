using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public GameObject bullet;
    public float bulletSpeed = 20.0f;
    public GameObject bulletSpawner;
    private Vector3 _angles = Vector3.zero;
    private readonly float _maxAngles = 60.0f;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) | Input.GetMouseButtonDown(1))
        {

            FireBullet();
        }
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");

            _angles.y += rotateHorizontal ;
            _angles.y = Math.Clamp(_angles.y, -_maxAngles, _maxAngles);
            
            _angles.x -= rotateVertical ;
            _angles.x = Math.Clamp(_angles.x, -_maxAngles, _maxAngles);
            
            gameObject.transform.rotation = Quaternion.Euler(_angles);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        void FireBullet()
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletSpawner.transform.position;
            newBullet.transform.rotation =  transform.rotation;
            
            

            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
        }
    }
    
}
