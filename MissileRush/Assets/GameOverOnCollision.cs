using UnityEngine;
using System.Collections;
public class GameOverOnCollision : MonoBehaviour {

	[SerializeField]
	private GameObject gameOver;

    [SerializeField]
    private GameObject gameWin;

    [SerializeField]
    private GameObject explosion;

	[SerializeField]
	private GameObject pauseButton;

    [SerializeField]
    private SpriteRenderer sRender;

    [SerializeField]
    private BoxCollider2D bc2D;
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
			GameOver();
            Time.timeScale = 0.4f;
            StartCoroutine(LoseRoutine());
			GameOver ();
		}

        if(coll.gameObject.tag == GameTags.mShip)
        {
            GameWon();
        }
	}

    IEnumerator LoseRoutine()
    {
        //play particle
        sRender.enabled = false;
        bc2D.enabled = false;
        explosion.SetActive(true);
        yield return new WaitForSeconds(1f);
        GameOver();
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
