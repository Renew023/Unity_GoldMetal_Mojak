using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float Speed;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;

    Rigidbody2D rd;

    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        
        Debug.Log(v);
        //이동기
        if(hDown)
            isHorizonMove = true;
        else if(vDown)
                isHorizonMove = false;
        else if (hUp || vUp)
                isHorizonMove = h != 0;

        if(anim.GetInteger("hAxisRaw") != h){
            anim.SetInteger("hAxisRaw", (int)h);
            anim.SetBool("isChange", true);
        } 
        else if(anim.GetInteger("vAxisRaw") != v){
            anim.SetInteger("vAxisRaw", (int)v);
            anim.SetBool("isChange", true);
        }
        else
            anim.SetBool("isChange", false);


    }

    void FixedUpdate(){
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rd.velocity = moveVec * Speed;
    }
}
