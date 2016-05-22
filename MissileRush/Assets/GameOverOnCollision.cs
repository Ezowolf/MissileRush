using UnityEngine;
public class GameOverOnCollision : MonoBehaviour {

	[SerializeField]
	private GameObject gameOver;

    [SerializeField]
    private GameObject gameWin;

	[SerializeField]
	private GameObject pauseButton;

	[SerializeField]
	private AudioClip explode;
	private AudioSource audioSource;

	void OnEnable()
	{
		audioSource = GetComponent<AudioSource>();
		Time.timeScale = 1;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == GameTags.enemy) {
			GameOver ();
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
		audioSource.PlayOneShot (explode);
		Time.timeScale = 0;
		gameOver.SetActive (true);
		pauseButton.SetActive (false);
	}

}
