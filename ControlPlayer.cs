using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlPlayer : MonoBehaviour
{
    public static bool isGameOver, grounded;//khai bao bien trang thai
    public float jumpHeigh, speed;//nhay, chay
    private Animator player;//khai bao nhan vat
    int score = 0;
    public Text txtText;
    
    void Start()
    {
        isGameOver=false;
        grounded=true;//dieu kien nhay cao
        player = GetComponent<Animator>();//findByViewID (anh xa)   
        Time.timeScale=1;//thoi gian thuc 
        txtText = GameObject.Find("txtScore").GetComponent<Text>();//anh xa
       
    }
    private void OnCollisionEnter2D(Collision2D other) {//xu ly va cham
        if(other.gameObject.tag=="Tien")//neu va cham voi tag Tien
        {
            score++;//tang diem
            Destroy(other.gameObject);//xoa coin
            txtText.text = "Score: "+score.ToString();
        }
        if(other.gameObject.tag=="ground")//neu va cham voi san
        {
             grounded=true;
        }
        
        if(other.gameObject.tag=="CNV")//neu va cham voi tag CNV
        {
            score-=10;//tru 10 diem
            Destroy(other.gameObject);//xoa CNV
            txtText.text = "Score: "+score.ToString();//cap nhat text
            if(score <=0)
            {
                Application.LoadLevel("menu");//goi gameover
            }
        }
     
    }

    void Update()
    {
        //grounded=true;
        if(!isGameOver)//neu nhan vat chua chet
        {
            if(Input.GetKey(KeyCode.LeftArrow))//khi nhan phim mui ten trai
            {
                player.SetBool("isRunning",true);//thay doi thanh trang thai chay
                player.SetBool("isIdle",false);
                player.SetBool("isDead",false);
                //di chuyen
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                //quay dau
                if(gameObject.transform.localScale.x > 0)//huong di duyen duong
                {
                    gameObject.transform.localScale = 
                    new Vector3(gameObject.transform.localScale.x * -1,
                                gameObject.transform.localScale.y,
                                gameObject.transform.localScale.z);
                }

            }
            else if(Input.GetKey(KeyCode.RightArrow))//khi nhan phim mui ten trai
            {
                player.SetBool("isRunning",true);//thay doi thanh trang thai chay
                player.SetBool("isIdle",false);
                player.SetBool("isDead",false);
                //di chuyen
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                //quay dau
                if(gameObject.transform.localScale.x < 0)//huong di duyen am
                {
                    gameObject.transform.localScale = 
                    new Vector3(gameObject.transform.localScale.x * -1,
                                gameObject.transform.localScale.y,
                                gameObject.transform.localScale.z);
                }

            }
            else if(Input.GetKey(KeyCode.Space))//khi nhan phim cach
            {
               if(grounded==true){
                   grounded=false;
                //tinh van toc
                gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,jumpHeigh);
               }
            }
            else
            {
                player.SetBool("isRunning",false);//thay doi thanh trang thai chay
                player.SetBool("isIdle",true);
                player.SetBool("isDead",false);
            }
        }
    }
}
