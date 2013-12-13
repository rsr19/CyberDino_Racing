using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour {
	
	public float heartBeatRate = 1;
	private float heartBeatTime;
	private EnemyAI[] enemyAI;
	
	// Use this for initialization
	void Start () {
		enemyAI = GetComponents<EnemyAI>();
		heartBeatTime = heartBeatRate;
	}
	
	// Update is called once per frame
	void Update () {
		heartBeatTime = heartBeatTime - Time.deltaTime;
		if (heartBeatTime <= 0){
			for (int i = 0; i < enemyAI.Length; i++){
				enemyAI[i].Act();
			}
		}
	}
}
