using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class players1 : MonoBehaviour {
    //khai bao bien xac dinh xem co phai gameover
    public static bool isGameOver = false;
    //khai bao toc do chay, nhay
    public float speed, jumpHeight;
    //anh xa doi tuong nhan vat tu giao dien game
    private Animator player_ini;



	// Use this for initialization
	void Start () {
        //anh xa
        player_ini = GetComponent<Animator>();
        //ty le thoi gian trong game
        Time.timeScale = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
        //neu game dang hoat dong
        if (isGameOver == false)
        {
            //neu an phim mui ten ben trai
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //set trang thai
                player_ini.SetBool("isRunning", true);
                player_ini.SetBool("isIdle", false);
                //di chuyen sang ben trai
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                //thao tac quay dau
                if (gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale = 
                        new Vector3(gameObject.transform.localScale.x * -1, 
                        gameObject.transform.localScale.y, gameObject.transform.localScale.z);   
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //set trang thai
                player_ini.SetBool("isRunning", true);
                player_ini.SetBool("isIdle", false);
                //di chuyen sang ben trai
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                //thao tac quay dau
                if (gameObject.transform.localScale.x < 0)
                {
                    gameObject.transform.localScale =
                        new Vector3(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                }
            }

        }
		
	}
}
