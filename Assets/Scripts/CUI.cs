using UnityEngine;
using System.Collections;

public class CUI : MonoBehaviour {
	string text="";
	string myName="";
	public Transform target;
	void OnGUI()
	{
		GUILayout.Label("Input your name:");
		text=GUILayout.TextField(text);
		if(GUILayout.Button("Submit"))
		{
			myName=text;
		}
		if(!string.IsNullOrEmpty(myName))
		{
			GUILayout.Label("Name:"+myName);
		}
		if(GUILayout.Button("Create",GUILayout.Height(50)))
		{
			GameObject obj=GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.AddComponent<Rigidbody>();
			obj.GetComponent<Renderer>().material.color=Color.red;
			obj.name="Cube";
			obj.transform.position=new Vector3(0,5f,0);
		}
		if(GUILayout.Button("Sphere",GUILayout.Height(50)))
		{
			GameObject obj=GameObject.CreatePrimitive(PrimitiveType.Sphere);
			obj.AddComponent<Rigidbody>();
			obj.GetComponent<Renderer>().material.color=Color.green;
			obj.name="Sphere";
			obj.transform.position=new Vector3(0,5f,0);
		}
		if(GUILayout.Button("TimeScale",GUILayout.Height(50)))
		{
			Time.timeScale*=0.9f;
		}


	}
	// Use this for initialization
	void Start () {
		Debug.Log("Log");
		Debug.LogWarning("Warning");
		Debug.LogError("Error");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Random.Range(0,10));
		Debug.Log(Random.Range(0f,10f));
		float smooth = 1.0F;
		transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smooth);
	}
}
