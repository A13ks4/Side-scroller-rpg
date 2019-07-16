using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For picking up specific items
public class PickUp : MonoBehaviour {

    public GameObject pickUp;
    public int offsetY = 3;
    new public string name;
    private bool inArea;

    // Use this for initialization
    void Start() {
        name = this.gameObject.name;
    }

    // Update is called once per frame
    void Update() {
        if (inArea) {
            if (Input.GetButtonDown("E")) {
                if (PlayerInventory.Instance().AddToInventory(name))
                    Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            pickUp.transform.position = new Vector2(transform.position.x, transform.position.y+offsetY);
            pickUp.SetActive(true);
            inArea = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            pickUp.SetActive(false);
            inArea = false;
        }
    }
}
