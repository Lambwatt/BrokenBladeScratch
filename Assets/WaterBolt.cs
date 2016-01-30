using UnityEngine;
using System.Collections;

public class WaterBolt : UnityEngine.MonoBehaviour, Ability {

	float m_cooldownRemaining;
	public float m_cooldown;

	// Update is called once per frame
	void Update () {
		if(m_cooldown>0){
			m_cooldownRemaining-=Time.deltaTime;
		}
	}

	public void setShot(Projectile p){
		p.effect = damageAndAddWaterMark;
		m_cooldownRemaining = m_cooldown;
	}
	
	public bool canShoot(){
		return false;
	}

	public void damageAndAddWaterMark(Entity e){
		e.marks[MARKS.water].add(1);
		e.dealDamage(5);
	}
}
