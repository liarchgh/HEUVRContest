using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour {
	public Rigidbody2D rb;
	public bool isLanded;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		/*if(Input.GetMouseButtonDown(0)&&isLanded)
		{
			rb.AddForce(new Vector2(0,360f));
			Debug.Log("jump");
			isLanded=false;
		}*/
	}
}
