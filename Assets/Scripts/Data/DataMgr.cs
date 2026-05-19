using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家数据结构类
public class PlayerData
{
    public int coin;  //全局金币数
    public List<int> listUnlockedId = new List<int>();  //已解锁id
}



/*
 * 1.做成单例，便于全局使用
 * 2.读取、更改、保存 玩家数据
 * 3.单向读取配置数据
 */
public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance => instance;
    
    //数据变量
    public PlayerData playerData;

    DataMgr() {

        //初始化读取数据
        playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData");//第一次不存在，直接返回一个新对象，等待之后创建文件
    }


    //更改玩家数据(因为通常都是金币和解锁卡牌在同一个时间点更改，所以封装到一起）
    public void ChangePlayerData(int newCoin,int newUnlockedId)
    {
        playerData.coin = newCoin;
        playerData.listUnlockedId.Add(newUnlockedId);
        //永久保存数据(因为不确定玩家是不是就直接离开）
        JsonMgr.Instance.SaveData(playerData, "PlayerData");
    }

    
}
