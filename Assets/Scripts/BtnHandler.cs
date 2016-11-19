using UnityEngine;
using System.Collections;

public class BtnHandler : MonoBehaviour {
	public bool isDown;
	void OnMouseDown()
	{isDown=true;}
	void OnMouseUp()
	{isDown=false;}
	public bool getState()
	{return isDown;}
}
