using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject player = null;

    public float dampTime = 1.5f;

    public float xAddition = 0;
    public float yAddition = 0;
    private Vector3 playerPos;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        playerPos = new Vector3(player.transform.position.x + xAddition, player.transform.position.y + yAddition,player.transform.position.z-10);
        transform.position = Vector3.Lerp(transform.position,playerPos,Time.deltaTime * dampTime);
	}
}
