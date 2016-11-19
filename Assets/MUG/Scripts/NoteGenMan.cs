using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
public class Gei_data
{
	public string name;
	public int len;
	public ArrayList note;
	public Gei_data()
	{
		note=new ArrayList();
	}
}
public class Note_data
{
	public int flag;
	public int type;
	public int pos;
	public int len;

}
public class NoteGenMan : MonoBehaviour {
	public TextAsset geiT,mapT;
	public myUGUI l;
	public float dt,pt;
	public int bpm,beatCount,pn,pg,bn;
	public static int GEN_COUNT=4;
	public float speed;
	public ArrayList gens,map,gei;
	public string path;
	public Animator avatar;
	public bool isChanging;
	// Use this for initialization
	void Start () {
		l=GameObject.Find("HUD").GetComponent<myUGUI>();
		pt=Time.time;
		pn=0;
		pg=0;
		bn=4;
		beatCount=0;
		avatar=GameObject.Find("t2").GetComponent<Animator>();
		isChanging=false;
//		#if UNITY_EDITOR
//		string filepath = Application.dataPath +"/StreamingAssets";
//		 
//		#elif UNITY_IPHONE
//		  string filepath = Application.dataPath +"/Raw";
//		 
//		#elif UNITY_ANDROID
//		  string filepath = "jar:file://" + Application.dataPath + "!/assets/";
//		 
//		#endif
//		path=filepath;
		gens=new ArrayList();
		for(int i=0;i<GEN_COUNT;i++)
		{
			NoteGen s=GameObject.Find("Stream"+i).GetComponentInChildren<NoteGen>();
			s.speed=this.speed;
			gens.Add(s);
		}
//		foreach(NoteGen g in gens)
//		{
//			g.hello();
//		}
		bool isStart=true;
		//TODO:xiugai
		ArrayList info=LoadFile("gei");
		gei=new ArrayList();
		Gei_data t_gei=new Gei_data();
		foreach (string str in info)
		{
			//Debug.Log(str);
			if(str.Length>0&&str[0]=='/')
			{
			}else if(isStart)
			{
				if(str.Length>0)
				{
					//Debug.Log(str);
					t_gei=new Gei_data();
					isStart=false;
					t_gei.name=str;
				}
			}else{
				if(str.Length<1)
				{
					gei.Add(t_gei);
					isStart=true;
				}else{
					string t=str;
					string[] temp=t.Split(new char[]{' '});
					if(temp.Length==4)
					{
						Note_data nd=new Note_data();
						nd.flag=int.Parse(temp[0]);
						nd.type=int.Parse(temp[1]);
						nd.pos=int.Parse(temp[2]);
						nd.len=int.Parse(temp[3]);
						t_gei.note.Add(nd);
					}else if(temp.Length==3)
					{
						Note_data nd=new Note_data();
						nd.flag=int.Parse(temp[0]);
						nd.type=int.Parse(temp[1]);
						nd.pos=int.Parse(temp[2]);
						t_gei.note.Add(nd);						
					}else if(temp.Length==1)
					{
						t_gei.len=int.Parse(str);
					}
				}
			}
		}
//		foreach(Gei_data g in gei)
//		{
//			Debug.Log(g.name);
//			Debug.Log(g.len);
//			Debug.Log(g.note.Count);
//			foreach(Note_data n in g.note)
//			{
//				Debug.Log(n.flag);
//				Debug.Log(n.type);
//				Debug.Log(n.pos);
//				if(n.type==1)
//					Debug.Log(n.len);
//				Debug.Log('\n');
//			}
//			Debug.Log('\n');
//			Debug.Log('\n');
//		}
//




		//map loading
		//TODO:xiugai
		info=LoadFile("map");
		bool isFirst=true;
		map=new ArrayList();

		foreach(string str in info)
		{
			
//			Debug.Log(str);
			if(str.Length>0&&str[0]=='/')
			{}else{
				if(isFirst)
				{

					bpm=int.Parse(str);
					isFirst=false;
				}else{
					map.Add(int.Parse(str));
				}
			}
		}
//		Debug.Log(bpm);
//		foreach(int num in map)
//		{
//			Debug.Log(num);
//		}
		dt=60f/bpm;
		InvokeRepeating("UpdateNote",0,dt);
	}
	
	// Update is called once per frame
	void Update () {
		if(pg<map.Count)
		{
//			if(Time.time-pt>=dt)
//			{
//			//Debug.Log("UPDate");
//
//				UpdateNote();
//				pt=Time.time;
//			}

		}else{
			CancelInvoke();
		}
	}



	void UpdateNote()
	{
		//Debug.Log("UPDate");
//		Gei_data tmp=(Gei_data)(gei[(int)(map[pg])]);
//		if(bn>=(tmp.len))
//		{
//			bn=0;
//			pg++;
//			pn=0;
//		}else{
//			if(pn<tmp.note.Count)
//			{
//				int temp=((Note_data)(tmp.note[pn])).flag;
//				Note_data t;
//				if(temp==bn)
//				{
//					while(pn<tmp.note.Count&&(t=((Note_data)(tmp.note[pn]))).flag==temp)
//					{
//						if(t.type==1)
//						{
//							((NoteGen)(gens[t.pos])).genNote(t.type,dt*t.len);
//						}else{
//							((NoteGen)(gens[t.pos])).genNote(t.type);
//						}
//						pn++;
//					}
//				}
//			}
//			bn++;
//		}
		//Debug.Log(t1);


		Gei_data tmp=(Gei_data)(gei[(int)(map[pg])]);
		if(bn>=(tmp.len))
		{
			bn=0;
			pg++;
			pn=0;
			StartCoroutine(AnimUpdate((int)map[pg],dt));
		}
		tmp=(Gei_data)(gei[(int)(map[pg])]);
			if(pn<tmp.note.Count)
			{
				int temp=((Note_data)(tmp.note[pn])).flag;
				Note_data t;
				if(temp==bn)
				{
					while(pn<tmp.note.Count&&(t=((Note_data)(tmp.note[pn]))).flag==temp)
					{
						if(t.type==1)
						{
							((NoteGen)(gens[t.pos])).genNote(t.type,dt*t.len);
						}else{
							((NoteGen)(gens[t.pos])).genNote(t.type);
						}
						pn++;
					}
				}
			}
			bn++;

	}
//	ArrayList LoadFile(string path,string name)
//	{
//		TextAsset TXTFile=UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/"+name,typeof(TextAsset)) as TextAsset;
//		if(TXTFile!=null)
//		{
//			Debug.Log(TXTFile.text);
//			string[] tmp=TXTFile.text.Split(Environment.NewLine.ToCharArray());
//			ArrayList arrlist=new ArrayList();
//			bool isBlank=false;
//			foreach(string t in tmp)
//			{
//				if(isBlank)
//				{
//					isBlank=false;
//				}else{
//					isBlank=true;
//					arrlist.Add(t);
//					Debug.Log(t);
//				}
//			}
//			return arrlist;
//		}else{
//			l.SendMessage("setInfo","loadFailed");
//			return null;
//		}
//
////		string url = Application.streamingAssetsPath + "/" + name;
////		#if UNITY_EDITOR
////
////		WWW www = new WWW(url);
////		while (!www.isDone) { }
////		Debug.Log(www.text);
////		string[] tmp=www.text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
////		ArrayList arrlist=new ArrayList();
////		foreach(string t in tmp)
////		{
////		arrlist.Add(t);
////		l.SendMessage("setInfo",t);
////		}
////		return arrlist;
////		#elif UNITY_ANDROID
////		StreamReader sr=null;
////		try{
////		sr=File.OpenText(url);
////		l.SendMessage("setInfo","Succeed");
////		}catch(Exception e)
////		{
////		Debug.Log(Application.dataPath);
////		Debug.Log("Load failed");
////		l.SendMessage("setInfo","Load failed");
////		return null;
////		}
////		string line;
////		ArrayList arrlist=new ArrayList();
////		while((line=sr.ReadLine())!=null)
////		{
////		arrlist.Add(line);
////		}
////		sr.Close();
////		sr.Dispose();
////		return arrlist;
////		#endif
//	}
	ArrayList LoadFile(string name)
	{
		TextAsset TXTFile=Resources.Load(name) as TextAsset;
		if(TXTFile!=null)
		{
			//Debug.Log(TXTFile.text);
			string[] tmp=TXTFile.text.Split(new char[]{'\r','\n'});
			ArrayList arrlist=new ArrayList();
			bool isBlank=false;
			foreach(string t in tmp)
			{
				if(isBlank)
				{
					isBlank=false;
				}else{
					isBlank=true;
					arrlist.Add(t);
					//Debug.Log(t);
				}
			}
			l.setInfo("success");
			return arrlist;
		}else{
			l.setInfo("failed to load map");
			return null;
		}
	}
	IEnumerator AnimUpdate(int t1,float dt)
	{
		yield return new WaitForSeconds(dt*4);
		if(t1==0)
		{
			avatar.SetBool("OAD",true);
			avatar.SetBool("Knee",false);
			avatar.SetBool("Check",false);
		}else if(t1==1)
		{
			avatar.SetBool("Knee",true);
			avatar.SetBool("OAD",false);
		}else if(t1==2)
		{
		}else if(t1==3)
		{
		}else if(t1==4)
		{
		}else if(t1==5)
		{
		}else if(t1==6)
		{
		}else if(t1==7)
		{
		}else if(t1==8)
		{
			avatar.SetBool("Amaterasu",true);
		}else if(t1==9)
		{
		}else if(t1==10)
		{
		}else if(t1==11)
		{
		}else if(t1==12)
		{
			avatar.SetBool("Rozario",true);
		}else if(t1==13)
		{
			avatar.SetBool("LosAngeles",true);
		}
	}

}
