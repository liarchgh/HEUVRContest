using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public Transform box;
	public Button lb,rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void LBHandler(){
		box.Translate(-10*Time.deltaTime,0,0);
	}
	public void RBHandler(){
		box.Translate(10*Time.deltaTime,0,0);
	}
}
