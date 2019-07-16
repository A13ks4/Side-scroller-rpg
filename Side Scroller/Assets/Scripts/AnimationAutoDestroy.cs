using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys an object after the animation finishes
public class AnimationAutoDestroy : MonoBehaviour {

    public float delay;

	void Start () {
        Destroy(gameObject, transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
	}
	
	
}
