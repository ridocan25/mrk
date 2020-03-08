using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed; 
	public Transform groundCheck; //  platform sınır kontrolu
	bool movingRight; // karakterin yönü
	public float distance;

	
	void Update () {
		// karaktere sağa doğru bir hareket veriyoruz
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		// karakterden aşşağı doğru bir laser atıyoz
		RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
		
		if (groundInfo.collider == false) // sınırdan dışarı çıktıysa
		{
			if(movingRight == true)// sağa doğru hareket kontrolu
			{
				transform.eulerAngles = new Vector3(0, -180, 0);// döndür yoksa düşücek
				movingRight = false;// sola döndü
			}else
			{
				transform.eulerAngles= new Vector3(0, 0, 0);// sağa döndür soksa düşücek
				movingRight = true;// sağa döndü
			}
		}
	}
}
