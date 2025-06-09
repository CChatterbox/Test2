using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject player;
    public float maxHP = 100f;
    public float curHP = 100f;
    public Vector3 offset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(player.transform.position+offset);
        GetComponent<Slider>().value = curHP/maxHP;

        if(curHP <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
