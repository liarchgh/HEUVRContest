using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	public Char c;
	public string n;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("enter");
		if(other.gameObject.name==n)
		{
			c.isLanded=true;
			//Debug.Log("land");
		}
	}
}
