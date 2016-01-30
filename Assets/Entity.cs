using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

	public Marks[] marks = new Marks[MARKS.num];
	public int hitPoints;
	public Canvas canvas;
	Text water;
	Text fire;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;

		if(hitPoints == 0)
			hitPoints = 100;

		for(int i = 0; i<MARKS.num; i++){
			marks[i] = new Marks();
		}

		water = Instantiate(Resources.Load<Text>("MarkText"));
		water.transform.SetParent(canvas.transform);
		water.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(-.5f, 0.0f, 0.5f));

		fire = Instantiate(Resources.Load<Text>("MarkText"));
		fire.transform.SetParent(canvas.transform);
		fire.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.5f, 0.0f, 0.5f));
	}
	
	// Update is called once per frame
	void Update () {
	 	if(hitPoints<=0){
			Destroy(this.gameObject);
		}

		for(int i = 0; i<MARKS.num; i++){
			marks[i].decay(Time.deltaTime);
		}

		if(marks[MARKS.water].getCount()>0)
			water.text = ""+marks[MARKS.water].getCount();
		else
			water.text = "";
		water.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(-.5f, 0.0f, 0.5f));

		if(marks[MARKS.fire].getCount()>0)
			fire.text = ""+marks[MARKS.fire].getCount();
		else
			fire.text = "";
		fire.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.5f, 0.0f, 0.5f));

	}

	public void dealDamage(int d){
		hitPoints -= d;
	}

	void OnDestroy(){
		Destroy(water);
	}
	
}
