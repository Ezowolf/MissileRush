using UnityEngine;
public class GameOverOnCollision : MonoBehaviour {

	[SerializeField]
	private GameObject gameOver;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == GameTags.enemy) {
			GameOver ();
		}
	}


	public void GameOver()
	{
		Time.timeScale = 0;
		gameOver.SetActive (true);
	}

}
