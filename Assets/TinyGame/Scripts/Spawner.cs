using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject ob,sub;
	public float interv,p;
	// Use this for initialization
	void Start () {
		p=Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time-p>=interv)
		{
			sub=Instantiate(ob,this.transform.position,Quaternion.identity) as GameObject;
			sub.transform.localScale=new Vector2(0.3f,Random.Range(0.1f,1.5f));
			p=Time.time;
			interv=Random.Range(2.0f,4.0f);
			//Debug.Log(interv);
		}
	}
}
