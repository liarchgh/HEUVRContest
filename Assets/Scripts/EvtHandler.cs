using UnityEngine;
using System.Collections;

public class EvtHandler : MonoBehaviour {
	public BtnHandler LB,RB,FB,JB;
	public Transform sphere;
	public Rigidbody2D sr,ld;
	public bool isLanded;
	// Use this for initialization
	void Start () {
		isLanded=true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(LB.getState())
		{
			sphere.Translate(-1.0f*Time.deltaTime,0,0);
		}
		if(RB.getState())
		{
			sphere.Translate(1.0f*Time.deltaTime,0,0);
		}
		if(FB.getState())
		{
			if(isLanded)
			{
				sr.AddForce(new Vector2(-15.0f,0.0f));
			}
		}
	}
}
