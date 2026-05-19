using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 面板的通用特性
 * 单例、显示、隐藏
 */
public class BasePanel : MonoBehaviour
{
    private static BasePanel instance;
    public static BasePanel Instance => instance;


    private void Awake() //细节：如果面板在初始时就隐藏，是不会执行Awake的
    {
        instance = this;
    }

    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
