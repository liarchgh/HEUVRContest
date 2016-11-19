using UnityEngine;
using System.Collections;

public class MyBtn : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0)
		{
			Debug.Log("HERE TOUCHES");
			CheckTouch(Input.GetTouch(0).position);

		}
		if(Input.GetMouseButton(0))
		{
			CheckTouch(Input.mousePosition);
		}
	}
	void CheckTouch(Vector3 pos)
	{
		Vector3 wp=Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos=new Vector2(wp.x,wp.y);
		Collider2D hit=Physics2D.OverlapPoint(touchPos);
		if(hit)
		{
			Debug.Log(hit.gameObject.name);
			this.transform.Translate(new Vector2(1,0));
		}
	}

}
