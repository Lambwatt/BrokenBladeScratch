using UnityEngine;
using System.Collections;

public class WaterBolt : MonoBehaviour, Ability {

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
		p.effect = damageAndAddWaterMark;
		m_cooldownRemaining = m_cooldown;
	}
	
	public bool canShoot(){
		Debug.Log ("Can shoot? "+m_cooldownRemaining);
		return  m_cooldownRemaining<=0.0f;
	}

	public void damageAndAddWaterMark(Entity e){
		e.marks[MARKS.water].add(1);
		e.dealDamage(10);
	}
}
x