using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TimeSaver : MonoBehaviour {

	private float minutes;

	private float seconds;

	private float trueSeconds;

	private List<float> localScores;

	[SerializeField]
	private GameObject scoreContainer;

	void Update () {
		seconds += Time.deltaTime;
		trueSeconds = Mathf.Round (seconds);
		if (trueSeconds > 59) 
		{
			seconds = 0;
			minutes++;
		}
		if (trueSeconds < 10) {
			print (minutes+":0"+trueSeconds);
	

		} else {
			print(minutes+":"+trueSeconds);
		}
		if(Input.GetKey(KeyCode.Space))
		{
			print("TimeScore: "+TimeScoreSaver ());
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

	public float TimeScoreSaver()
	{
		float timeScore = minutes + trueSeconds / 100;
		return timeScore;
	}
		
}
