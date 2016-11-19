using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Test : MonoBehaviour {
	Button lb;
	// Use this for initialization
	void Start () {
		lb=transform.Find("LButton").GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		lb.transform.Translate(1.0f*Time.deltaTime,0,0);
	}
}
