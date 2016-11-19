using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mover : MonoBehaviour {
	private float camHalfHeight;
	private float camHalfWidth;
	void Awake()
	{
		this.camHalfHeight=Camera.main.orthographicSize;
		this.camHalfWidth=Camera.main.aspect*camHalfHeight;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move(Input.mousePosition);
		print(this.transform.position);
	}
	public void Move(Vector2 pos)
	{
		Vector3 poss=new Vector3(pos.x,pos.y,0);
		Vector3 pz=Camera.main.ScreenToWorldPoint(poss);
		transform.position=new Vector3(pz.x,pz.y,902);
	}
	void OnMouseDown(){
		Debug.Log("Down");
	}
	void OnMouseUp(){
		Debug.Log("Up");
	}
}