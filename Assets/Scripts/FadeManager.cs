﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{ 

    public bool enableFade = false;
    public bool enableFadeIn = false;
    public bool enableFadeOut = false;
    public bool enableFadeOn = false;

    public float speed = 0.02f;

    public Image FadeImage;

    private float count = 1f;

    private bool enableAlphaTop = false;

    // ---------------------------

    void Start()
    {
        enableFade = true;
        enableFadeIn = true;
        setAlpha(FadeImage, count);
    }

    void Update()
    {

        if (enableFadeOn)
        {
            FadeInAndOut(FadeImage);
        }

        if (enableFadeIn)
        {
            FadeIn(FadeImage);
        }

        if (enableFadeOut)
        {
            FadeOut(FadeImage);
        }
    }

    void setAlpha(Image image, float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public void FadeOut(Image image)
    {
        if (enableFade)
        {
            count += speed;
            setAlpha(image, count);
            if (image.color.a >= 1f)
            {
                enableFade = false;
                if (enableFadeOut)
                {
                    // フェードアウトした時の処理をここに書く
                    if(Application.loadedLevelName == "TitleScene")
                        SceneManager.LoadScene("PlayScene");
                    else if (Application.loadedLevelName == "PlayScene")
                        SceneManager.LoadScene("ResultScene");

                }
            }
        }
    }

    void FadeIn(Image image)
    {
        if (enableFade)
        {
            count -= speed;
            setAlpha(image, count);
            if (image.color.a <= 0f)
            {
                enableFade = false;
                enableFadeIn = false;
            }
        }
    }

    void FadeInAndOut(Image image)
    {

        if (enableFade)
        {
            if (!enableAlphaTop)
            {
                count += speed;
            }
            else
            {
                count -= speed;
                if (image.color.a <= 0f)
                {
                    enableFade = false;
                    enableFadeOn = false;
                    enableAlphaTop = false;
                }
            }
            setAlpha(image, count);
            if (image.color.a >= 1f)
            {
                enableAlphaTop = true;
            }
        }
    }
}