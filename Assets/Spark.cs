using UnityEngine;
using System.Collections;

public class Spark : UnityEngine.MonoBehaviour, Ability {

	float m_cooldownRemaining;
	public float m_cooldown;

	// Update is called once per frame
	void Update () {
		if(m_cooldown>0.0f){
			m_cooldownRemaining-=Time.deltaTime;
		}
	}

	public void setShot(Projectile p){
		p.effect = damageAndAddFireMark;
		m_cooldownRemaining = m_cooldown;
	}
	
	public bool canShoot(){
		return m_cooldownRemaining<=0.0f;
	}

	public void damageAndAddFireMark(Entity e){
		e.marks[MARKS.fire].add(1);
		e.dealDamage(20);
	}
}
