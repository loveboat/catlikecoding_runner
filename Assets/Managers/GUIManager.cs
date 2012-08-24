using UnityEngine;

public class GUIManager : MonoBehaviour {

	public GUIText gameOverText, instructionsText, runnerText;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		gameOverText.enabled = false;
	}

	void Update () {
		if(Input.GetButtonDown("Jump")){
			GameEventManager.TriggerGameStart();
		}
	}
	
	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		runnerText.enabled = false;
		enabled = false;
	}
}
