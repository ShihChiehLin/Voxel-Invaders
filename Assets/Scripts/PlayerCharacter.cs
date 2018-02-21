using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

	public float movementSpeed;
	public MapLimits Limits;

	public GameObject bullet;
	public Transform pos1;
	public Transform posL;
	public Transform posR;
	public AudioClip shotSound;
	public float shotPower;
	AudioSource audioS;
	int power;
	public int hp;

	public int score;
	int highScore;
	public Text scoreText;

	public Text highScoreText;

	// Use this for initialization
	void Start () {
		power = 1;
		audioS = GetComponent<AudioSource> ();
		if (!PlayerPrefs.HasKey ("highscore")) {
			highScore = 0;
			PlayerPrefs.SetInt ("highscore", highScore);
		}
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
		highScoreText.text = PlayerPrefs.GetInt ("highscore").ToString ();
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("highscore",highScore);
		}
		if (hp <= 0) {
			Destroy (gameObject);
		}
		Movement ();
		Shooting ();
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, Limits.minimumX, Limits.maximumX),
			Mathf.Clamp (transform.position.y, Limits.minimumY, Limits.maximumY), 0.0f);
	}

	void Movement(){
		if(Input.GetKey(KeyCode.A)){
			transform.Translate (Vector3.right * -movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate (Vector3.right * movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Translate (Vector3.up * movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate (Vector3.up * -movementSpeed * Time.deltaTime);
		}
	}

	void Shooting(){
		if(Input.GetKeyDown(KeyCode.Space)){
			audioS.PlayOneShot (shotSound);
			switch (power) {
			case 1:
				{
					GameObject newBullet = Instantiate (bullet, pos1.position, transform.rotation);
					newBullet.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;
				}
				break;
			case 2:
				{
					GameObject bullet1 = Instantiate (bullet, posL.position, transform.rotation);
					bullet1.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;
					GameObject bullet2 = Instantiate (bullet, posR.position, transform.rotation);
					bullet2.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;

				}
				break;
			case 3:
				{
					GameObject bullet1 = Instantiate (bullet, posL.position, transform.rotation);
					bullet1.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;
					GameObject bullet2 = Instantiate (bullet, posR.position, transform.rotation);
					bullet2.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;
					GameObject bullet3 = Instantiate (bullet, pos1.position, transform.rotation);
					bullet3.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;

				}
				break;
			default:
				{
					GameObject newBullet = Instantiate (bullet, pos1.position, transform.rotation);
					newBullet.GetComponent<Rigidbody> ().velocity = Vector3.up * shotPower;
				}
				break;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "powerUp"){
			if (power < 3) {
				power++;
			}
			Destroy (col.gameObject);
		}
		if(col.gameObject.tag == "powerDown"){
			if (power > 1) {
				power--;
			}
			Destroy (col.gameObject);

		}

	}
}
