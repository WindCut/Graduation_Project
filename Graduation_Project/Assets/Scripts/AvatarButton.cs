﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AvatarButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  Change()
    {
        Debug.Log(gameObject);
    }
    public void OnValueChanged(bool isOn)
    {
        if (!isOn)
        {
            //Debug.Log(gameObject);
            return;
        }
        string[] name = gameObject.name.Split('-');
        //string[] part 
        AvatarSys._instance.onChagePeople(name[0],name[1]);
        switch (name[0])
        {
            case "pants":
                PlayAnimation("item_pants");
                break;
            case "shoes":
                PlayAnimation("item_boots");
                break;
            case "top":
                PlayAnimation("item_shirt");
                break;
            default:
                break;
        }
    }
    public void PlayAnimation(string animName)
    { //换装动画名称

        Animation anim = GameObject.FindWithTag("Player").GetComponent<Animation>();
        if (!anim.IsPlaying(animName))
        {
            anim.Play(animName);
            anim.PlayQueued("idle1");
        }

    }
    public void LoadScenes()
    {
        DateManager.GetInstance().SaveCloth();
        SceneManager.LoadScene(1);
    }
}
