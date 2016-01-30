using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

	public CanvasGroup gameOverText;
	bool countingDown = false;
	public float timeRemaining;


	void Update(){
		if(countingDown){
			if(timeRemaining<0.0f){
				Application.LoadLevel("StartScreen");
			}else{
				timeRemaining-=Time.deltaTime;
			}
		}
	}

	public void gameOver(){
		gameOverText.alpha = 1;
		countingDown = true;
	}
}
