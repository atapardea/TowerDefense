using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance=null;
	public GameObject spawnPoint;
	public GameObject[] enemies;
	public int maxEnemiesOnScreen;
	public int totalEnemies;
	public int enemiesPerSpawin;

	private int enemiesOnScreen=0;
	const float spawnDelay=0.8f;

	void Awake(){
		if (instance==null)
			instance=this;
		else if (instance != this) 
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);	
		}

	
	// Use this for initialization
	void Start () {
		StartCoroutine(spawn());
	}

	IEnumerator spawn(){
		if (enemiesPerSpawin>=0 && enemiesOnScreen < totalEnemies){
			for (int i=0; i<enemiesPerSpawin ; i++){
				if (enemiesOnScreen < maxEnemiesOnScreen){
					GameObject newEnemy = Instantiate(enemies[2]) as GameObject;
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen+=1;
				}
			}
			yield return new WaitForSeconds(spawnDelay);
			StartCoroutine(spawn());
		}

	}
	
	
	// Update is called once per frame
	

	// void spawnEnemy(){
	// 	if (enemiesPerSpawin>=0 && enemiesOnScreen < totalEnemies){
	// 		for (int i=0; i<enemiesPerSpawin ; i++){
	// 			if (enemiesOnScreen < maxEnemiesOnScreen){
	// 				GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
	// 				newEnemy.transform.position = spawnPoint.transform.position;
	// 				enemiesOnScreen+=1;
	// 			}
	// 		}

	// 	}

	// }
	public void removeEnemyFromScreen(){
		if (enemiesOnScreen>0){
			enemiesOnScreen-=1;
		}
	}
}
