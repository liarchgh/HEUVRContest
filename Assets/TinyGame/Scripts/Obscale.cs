using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Obscale : MonoBehaviour {
	public float speed;
	public Text t;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector2(-1*speed*Time.deltaTime,0));
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag=="Char")
		{
			//Debug.Log("enter");
			Time.timeScale=0;
			t=GameObject.Find("Canvas/Text").GetComponent<Text>();
			t.text="你坚持了:"+Time.timeSinceLevelLoad+"秒";
		}
	}
}
