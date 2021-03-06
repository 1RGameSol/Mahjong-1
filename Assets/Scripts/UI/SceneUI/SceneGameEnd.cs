﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGameEnd : SceneBase {

    private Text WinName;

    private Text WinNum; 

    public override void OnInit()
    {
        setSkinPath("UI/Scenes/" + SceneState.SceneGameEnd.ToString());
        base.OnInit();
    }

    protected override void OnInitData()
    {
        WinName = skin.transform.Find("WinName").GetComponent<Text>();
        WinNum = skin.transform.Find("WinNum").GetComponent<Text>();

        ActionParam param = new ActionParam();
        param["roomID"] = GameSetting.Instance.roomID;

        WebLogic.Instance.Send((int)ActionType.getWinName, param);

    }

    protected override void onClick(GameObject BtObject)
    {
        if (BtObject.name.Equals("GameOver"))
        {
            SceneManager.Instance.SceneSwitch(SceneType.Type.Room);
        }
    }

    protected override bool Event(ActionParam param)
    {
        int id = (int)param["ActionType"];

        if (id == (int)ActionType.getWinName)
        {
            WinName.text = (string)param["WinName"];
            WinNum.text = "1";
        }

        return false;
    }

}
