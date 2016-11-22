using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class myUGUI : MonoBehaviour {
	[SerializeField] private Text tScore,tStatus,tLog,tName,tFinalScore;
	[SerializeField] private GameObject tPanel,tBtn;
	[SerializeField] private AudioSource audio;
	private string str,myInfo;
	private int score,combo;
	void Start()
	{
		score=0;
		combo=0;
		tPanel.SetActive(false);
		FirstDisplay();
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
		score+=(int)(s*(1+(float)combo/10));
		tScore.text="Score:"+score.ToString();
	}
	public void setInfo(string s)
	{
		myInfo=s;
		tLog.text=s;
	}
	public void FinalDisplay()
	{
        tFinalScore.text = score.ToString();
        tScore.gameObject.SetActive(false);
		tStatus.gameObject.SetActive(false);
		tLog.gameObject.SetActive(false);
		tBtn.SetActive(false);
		tPanel.SetActive(true);
	}
	public void FirstDisplay()
	{
		tName.text=audio.clip.name;
		Destroy(tName.gameObject,3.0f);
	}
	public void Retry()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
