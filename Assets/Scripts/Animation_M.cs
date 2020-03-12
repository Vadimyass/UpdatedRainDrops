using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Animation_M : MonoBehaviour
{
    public GameObject BG, Load_screen;

    public Button PlayBtn;
    private System.Random random;

    private bool b_Load_screen;
    //Coordinate for "Load Screen"
    float x_Ls, y_Ls, speed_Ls, size_Ls, SpeedSize_Ls, condition_Ls;

    float y_BG, speed_BG;

    public string Scene_str;
    
    

    // Start is called before the first frame update
    void Start()
    {
        BG.GetComponent<RectTransform>().localPosition = new Vector3(0, -326);
        Load_screen.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f);
        Load_screen.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
        PlayBtn.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
        PlayBtn.onClick.AddListener(PlayBtn_Click);

        random = new System.Random();
        b_Load_screen = false;

        SpeedSize_Ls = 0;
        size_Ls = 1.5f;
        x_Ls = 0;
        y_Ls = 0;
        speed_Ls = 0.03f;
        condition_Ls = 1.16f;

        y_BG = -130;
        speed_BG = 0.04f;

    }

    // Update is called once per frame
    void Update()
    {
        VibrationsPos_Load_screen(x_Ls, y_Ls, speed_Ls);

        VibrationsPos_PlayBtn(0, 0, speed_Ls);

        SpeedPos_BG(y_BG, speed_BG);

        Condition_Scale(0.3f, 0.1f, condition_Ls);

        SizeLoad_screen(size_Ls, SpeedSize_Ls);

        if(Load_screen.GetComponent<RectTransform>().localPosition.y < -231){
            Scene_selection(Scene_str);
        }
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Return)){
            PlayBtn_Click();
        }
    }

    void VibrationsPos_Load_screen(float x, float y, float speed){
        Load_screen.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
            Load_screen.GetComponent<RectTransform>().localPosition, new Vector3(
                x + random.Next(-5, 5), 
                y + random.Next(-5, 5)
            ), speed
        );
    }

    void VibrationsPos_PlayBtn(float x, float y, float speed){
        PlayBtn.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
            PlayBtn.GetComponent<RectTransform>().localPosition, new Vector3(
                x + random.Next(-5, 5), 
                y + random.Next(-5, 5)
            ), speed
        );
    }

    void SpeedPos_BG(float y, float speed){
        BG.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
            BG.GetComponent<RectTransform>().localPosition, new Vector3(0, y), speed
        );
    }

    void Condition_Scale(float ReductionRate, float IncreaseRate, float condition){
        if(BG.GetComponent<RectTransform>().localPosition.y > -130.5f){
            if(!b_Load_screen){
                size_Ls = 1.15f;
                SpeedSize_Ls = ReductionRate;
                SizePlayBtn(0, 0.7f);

                if(Load_screen.GetComponent<RectTransform>().localScale.x < condition){
                    b_Load_screen = true;
                    y_BG = 0;
                    speed_BG = 0.8f;
                    Load_screen.SetActive(false);
                }
            }else {
                size_Ls = 30;
                SpeedSize_Ls = IncreaseRate;
                PlayBtn.GetComponent<RectTransform>().localScale = Vector3.Lerp(
                    PlayBtn.GetComponent<RectTransform>().localScale, new Vector3(1, 1), 0.08f
                );
                SizePlayBtn(1, 0.08f);
            }
        }
    }

    void SizeLoad_screen(float size, float speed){
        Load_screen.GetComponent<RectTransform>().localScale = Vector3.Lerp(
                    Load_screen.GetComponent<RectTransform>().localScale, new Vector3(size, size), speed //0.03f is normal
        );
    }

    void SizePlayBtn(float size, float speed){
        PlayBtn.GetComponent<RectTransform>().localScale = Vector3.Lerp(
                    PlayBtn.GetComponent<RectTransform>().localScale, new Vector3(size, size), speed
        );
    }

    void PlayBtn_Click(){
        b_Load_screen = !b_Load_screen;
        condition_Ls = 1.15f;

        x_Ls = 0;
        y_Ls = -234;
        speed_Ls = 0.06f;

        y_BG = -234;
        speed_BG = 0.1f;
    }

    void Scene_selection(string Scene){
        SceneManager.LoadScene(Scene);
        //SceneManager.LoadScene(index);
    }
}
