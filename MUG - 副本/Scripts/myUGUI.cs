using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class myUGUI : MonoBehaviour {
	[SerializeField] private Text tScore,tStatus,tLog;
	private string str,myInfo;
	private int score,combo;
	void Start()
	{
		score=0;
		combo=0;
	}
	// Use this for initialization
	public void exit()
	{
		Application.Quit();
	}
	public void setStr(string s)
	{
		if(s=="Miss")
		{
			combo=0;
		}else{
			combo++;
		}
		str=s;
		tStatus.text=s+'\n'+combo.ToString();
	}
	public void setScore(int s)
	{
		score+=s;
		tScore.text="Score:"+score.ToString();
	}
	public void setInfo(string s)
	{
		myInfo=s;
		tLog.text=s;
	}
}
