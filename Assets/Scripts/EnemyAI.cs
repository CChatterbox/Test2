using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private float speed = 0.7f;
    public GameObject playerHP;
    public GameObject enemyHP;
    public EnemyHP HPslider;
    public GameObject loot;

    public float maxHP = 100;
	  public float curHP = 100; 
	  public Vector3 offset;

    
    void Start()
    {
      player = GameObject.FindWithTag("Player"); 
      playerHP = GameObject.FindWithTag("PlayerHP"); 
      GameObject hp = Instantiate(enemyHP,Vector3.zero,Quaternion.identity) as GameObject;
      hp.transform.SetParent(GameObject.Find("Canvas").transform);
      HPslider = 	hp.GetComponent<EnemyHP>();
      hp.transform.SetAsFirstSibling();
      hp.GetComponent<EnemyHP>().maxHP = maxHP;
      hp.GetComponent<EnemyHP>().curHP = curHP;
      hp.GetComponent<EnemyHP>().Enemy = gameObject;
      hp.GetComponent<EnemyHP>().offset = offset;
      
    }

    
    void Update()
    {
      
       distance = Vector3.Distance(player.transform.position, transform. position);
       if(distance < 10f)
       {
        transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
       } 
       if(HPslider.curHP <= 0)
       {
        
        Dead();
       }

       
    }
    void OnTriggerStay2D(Collider2D other)
    {
      if(other.CompareTag("Player"))
      {
         Damage();

      }
    }
    void Damage()
    {
      playerHP.GetComponent<PlayerHP>().curHP -= 0.2f;
    }
    void Dead()
    {
      Instantiate(loot, gameObject.transform.position, transform.rotation);
      gameObject.SetActive(false);
      Destroy(HPslider.gameObject);
    }
    


  
}
