﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Get current screen position of the mouse
        Vector3 mousePos2D = Input.mousePosition;

        //Camera's z pos sets how far to push the mouse into 3D
        mousePos2D.z = Camera.main.transform.position.z;
        
        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x pos of this Basket to the x pos of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
	}

    //Unity function
    void OnCollisionEnter(Collision collision)
    {
        //Find out what hit the basket
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            //Add to the score
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();//get reference to our apple picker
            apScript.AppleCaught();//call our public function to represent an apple getting caught
        }
    }
}
