using UnityEngine;
using System.Collections;

public class EnemyAIMG : MachineGun {
	
	void Start(){
		
		RWStart();
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AIFireMG(){
		FireFunc ();
	}
}
