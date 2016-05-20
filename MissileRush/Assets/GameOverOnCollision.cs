using UnityEngine;
public class GameOverOnCollision : MonoBehaviour {

	[SerializeField]
	private GameObject gameOver;

    [SerializeField]
    private GameObject gameWin;

	[SerializeField]
	private GameObject pauseButton;

	void OnEnable()
	{
		Time.timeScale = 1;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == GameTags.enemy) {
			//GameOver ();
		}

        if(coll.gameObject.tag == GameTags.mShip)
        {
            GameWon();
        }
	}

    void OnMouseDown()
    {
        GameWon();
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        gameWin.SetActive(true);
        pauseButton.SetActive(false);
    }

	public void GameOver()
	{
		Time.timeScale = 0;
		gameOver.SetActive (true);
		pauseButton.SetActive (false);
	}

}
