using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It is attached to player object
public class PlayerStats : MonoBehaviour {

    private Player player;

    public Player GetPlayer() { return player; }

	// Use this for initialization
	void OnEnable () {
        player = new Player(25, 0);
    }
	
	// Update is called once per frame
	void Update () {
        player.UpdateEfects();
	}
    
}
