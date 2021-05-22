using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    //Khai báo các biến sử dụng
    public static bool isGameOver = false;//trang thai ket thuc game
    public float jumpHeigh, speed;//toc do chay, nhay
    private Animator player;
    void Start()
    {
         //findByViewId->anh xa id tu thiet ke sang code
        player = GetComponent<Animator>();
        Time.timeScale=1;//ti le voi thoi gian thuc
        isGameOver=false;
    }

    // Update is called once per frame
    void Update()
    {
       if(!isGameOver)//neu game chua ket thuc
       {
           if(Input.GetKey(KeyCode.LeftArrow))//khi nguoi dung nhan Left
           {
               player.SetBool("isRunning",true);//chay-> true
               player.SetBool("isIdle",false);//dung yen->false
               gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);//di chuyen
               //quay dau
               if(gameObject.transform.localScale.x > 0)
               {
                   gameObject.transform.localScale = new
                   Vector3(gameObject.transform.localScale.x * -1,
                   gameObject.transform.localScale.y,
                   gameObject.transform.localScale.z);
               }
           }
           else if(Input.GetKey(KeyCode.RightArrow))//khi nguoi dung nhan righ
            {
               player.SetBool("isRunning",true);//chay-> true
               player.SetBool("isIdle",false);//dung yen->false
               gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);//di chuyen
            //quay dau
               if(gameObject.transform.localScale.x < 0)
               {
                   gameObject.transform.localScale = new
                   Vector3(gameObject.transform.localScale.x * -1,
                   gameObject.transform.localScale.y,
                   gameObject.transform.localScale.z);
               }           
            }
            else if(Input.GetKey(KeyCode.Space))//nhay cao
            {
                gameObject.GetComponent<Rigidbody2D>().velocity
                = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,jumpHeigh);
            }
            else//neu khong nhan phim nao
            {
                player.SetBool("isRunning",false);//chay-> false
               player.SetBool("isIdle",true);//dung yen->true
            }
       }
    }
}
