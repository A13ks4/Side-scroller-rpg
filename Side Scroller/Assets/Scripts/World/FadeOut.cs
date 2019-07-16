using UnityEngine;
using System.Collections;

//Fades out objects when player is in front
public class FadeOut : MonoBehaviour {

	private PlayerStats player;
	private SpriteRenderer sprite;

	public float AlphaColor;
	public float distance;

	// Use this for initialization
	void Start () {
        player = GameControl.Instance.GetPlayerStats();
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x < this.transform.position.x && player.transform.position.x > this.transform.position.x - distance){
			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,AlphaColor);

		}else if(player.transform.position.x > this.transform.position.x && player.transform.position.x < this.transform.position.x + distance){
			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,AlphaColor);
        }
        else{
			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,1f);
		}
	}
}
