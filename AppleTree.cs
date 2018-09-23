using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    //apple prefab
    public GameObject applePrefab;

    //AppleTree movement speed m/s
    public float speed = 1f;

    //Distance where tree turns around
    public float leftAndRightEdge = 10f;

    //chance of AppleTree changing directions
    public float chanceToChangeDirections = 0.1f;

    //rate at which apples are instantiated (seconds)
    public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
        //Drop apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}
	
	// Update is called once per frame
	void Update () {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Change Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//move left
        }
	}

    //Called 50 times per second
    void FixedUpdate()
    {
        //Changing Direction Randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;//change direction
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
}
