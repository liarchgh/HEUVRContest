using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;
	public RectNote pre;
	public int Side{get;set;}
	public int Type{get;set;}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.Translate(new Vector3(0,-1*speed*Time.deltaTime,0));
	}
}
