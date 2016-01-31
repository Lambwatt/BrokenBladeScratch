using UnityEngine;
using System.Collections;

public class Siphon : MonoBehaviour, Ability {

	float m_cooldownRemaining;
	public float m_cooldown = 0.0f;

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Updated?");
		if(m_cooldown>0.0f){
			Debug.Log ("Updated?");
			m_cooldownRemaining-=Time.deltaTime;
		}
	}

	public void setShot(Projectile p){
		p.effect = transferHealth;
		m_cooldownRemaining = m_cooldown;
	}
	
	public bool canShoot(){
		Debug.Log ("Can shoot? "+m_cooldownRemaining);
		return  m_cooldownRemaining<=0.0f;
	}

	public void transferHealth(Entity e){
		int n = e.marks[MARKS.water].getCount();
		e.dealDamage(n*5);
		GameObject.FindWithTag("Player").GetComponent<Entity>().dealDamage(-5*n);
		e.marks[MARKS.water].consume();
	}
}
