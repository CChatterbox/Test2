using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour {

	public float maxHP = 100f;
	public float curHP = 100f; 

	public GameObject Enemy;
	public Vector3 offset;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Enemy.transform.position+offset);
	GetComponent<Slider>().value = curHP/maxHP;
	}
}
