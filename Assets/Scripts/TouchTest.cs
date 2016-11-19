#if UNITY_ANDROID && !UNITY_EDITOR
#define ANDROID
#endif
 
 
#if UNITY_IPHONE && !UNITY_EDITOR
#define IPHONE
#endif
 
 
 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class TouchTest : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
	
	}
	
 
	void Update()
	{
		if (Input.GetMouseButtonDown(0)||(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
#if IPHONE || ANDROID
			if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
			if (EventSystem.current.IsPointerOverGameObject())
#endif
				Debug.Log("当前触摸在UI上");
			
			else 
				Debug.Log("当前没有触摸在UI上");
		}
	}
}


