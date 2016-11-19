using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Btn : MonoBehaviour {
	public Char c;
	public string n,b,f;
	public GameObject[] o;
	public Text t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			CheckTouch(Input.mousePosition);
		}
		if(Input.touchCount>0)
		{
			foreach(Touch touch in Input.touches)
				CheckTouch(touch.position);

		}
	}
	void CheckTouch(Vector3 pos)
	{
		Vector3 wp=Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos=new Vector2(wp.x,wp.y);
		Collider2D hit=Physics2D.OverlapPoint(touchPos);
		//Debug.Log(hit.gameObject.name);
		if(hit&&(hit.gameObject.name==n||hit.gameObject.name==b||hit.gameObject.name==f))
		{
			
			if(c.isLanded)
			{
				c.rb.AddForce(new Vector2(0,300f));
				//Debug.Log("jump");
				c.isLanded=false;
			}
		}
	}
	public void Retry()
	{
		t=GameObject.Find("Canvas/Text").GetComponent<Text>();
		t.text="";
		Time.timeScale=1;
		o=GameObject.FindGameObjectsWithTag("Ob");
		foreach(Object ob in o)
		{
			Destroy(ob);
		}
	}
}
