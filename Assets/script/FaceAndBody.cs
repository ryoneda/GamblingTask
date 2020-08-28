using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAndBody : MonoBehaviour {

    //表情のアニメを入れる
    public AnimationClip[] faceAnime;
    //ポーズのアニメを入れる
    //public AnimationClip[] bodyAnime;
    //Animatorコンポーネントを入れる
    Animator anim;

    void Start () {
        //Animatorコンポーネントを取得
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        //(レイヤーの番号、どれだけアニメを出すか0～１）
        anim.SetLayerWeight(1, 1f);

        //Wキーで出す
        if (Input.GetKeyDown(KeyCode.W))
        {
            //.nameでアニメーションの名前を取得する
            anim.Play(faceAnime[0].name);
            
            //anim.Play(bodyAnime[0].name);
        }

        //Aキーで出す
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play(faceAnime[1].name);
            
            //anim.Play(bodyAnime[1].name);
        }

        //Sキーで出す
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(faceAnime[2].name);
            
            //anim.Play(bodyAnime[2].name);
        }

        //Dキーで出す
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play(faceAnime[3].name);
            //anim.Play(bodyAnime[3].name);
        }

        //Zキーで出す
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.Play(faceAnime[4].name);
            
            //anim.Play(bodyAnime[4].name);
        }
    }
}
