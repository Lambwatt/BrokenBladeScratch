using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public Marks[] marks = new Marks[MARKS.num];
	public int hitPoints;

	// Use this for initialization
	void Start () {
		if(hitPoints == 0)
			hitPoints = 100;

		for(int i = 0; i<MARKS.num; i++){
			marks[i] = new Marks();
		}
	}
	
	// Update is called once per frame
	void Update () {
	 	if(hitPoints<=0){
			Destroy(this.gameObject);
		}

		for(int i = 0; i<MARKS.num; i++){
			marks[i].decay(Time.deltaTime);
		}
	}

	public void dealDamage(int d){
		hitPoints -= d;
	}
}
