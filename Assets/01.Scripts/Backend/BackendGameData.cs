using System.Collections.Generic;
using System.Text;
using UnityEngine;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class UserData
{
    public int BestScore = GameManager.instance.BestScore;

    // �����͸� ������ϱ� ���� �Լ��Դϴ�.(Debug.Log(UserData);)
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"BestScore : {BestScore}");
        
        return result.ToString();
    }
}

public class BackendGameData
{
    private static BackendGameData _instance = null;

    public static BackendGameData Instance
    {   
        get
        {
            if (_instance == null)
            {
                _instance = new BackendGameData();
            }

            return _instance;
        }
    }

    public static UserData userData;

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        if (userData == null)
        {
            userData = new UserData();
        }

        Debug.Log("�����͸� �ʱ�ȭ�մϴ�.");
        userData.BestScore = GameManager.instance.BestScore;

        Debug.Log("�ڳ� ������Ʈ ��Ͽ� �ش� �����͵��� �߰��մϴ�.");
        Param param = new Param();
        param.Add("BestScore", userData.BestScore);
        


        Debug.Log("�������� ������ ������ ��û�մϴ�.");
        var bro = Backend.GameData.Insert("BestScore", param);

        if (bro.IsSuccess())
        {
            Debug.Log("�������� ������ ���Կ� �����߽��ϴ�. : " + bro);

            //������ ���������� �������Դϴ�.
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogError("�������� ������ ���Կ� �����߽��ϴ�. : " + bro);
        }
    }

    public void GameDataGet()
    {
        Debug.Log("���� ���� ��ȸ �Լ��� ȣ���մϴ�.");
        var bro = Backend.GameData.GetMyData("USER_DATA", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("���� ���� ��ȸ�� �����߽��ϴ�. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json���� ���ϵ� �����͸� �޾ƿɴϴ�.

            // �޾ƿ� �������� ������ 0�̶�� �����Ͱ� �������� �ʴ� ���Դϴ�.
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("�����Ͱ� �������� �ʽ��ϴ�.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //�ҷ��� ���������� �������Դϴ�.

                userData = new UserData();

                userData.BestScore = int.Parse(gameDataJson[0]["BestScore"].ToString());

                Debug.Log(userData.ToString());
            }
        }
        else
        {
            Debug.LogError("���� ���� ��ȸ�� �����߽��ϴ�. : " + bro);
        }
    }

    public void UpdateBestScore()
    {
        Debug.Log("�ְ������� ���ŵ˴ϴ�.");
        userData.BestScore = GameManager.instance.Score;
        
    }

    // �������� �����ϱ�
    public void GameDataUpdate()
    {
        if (userData == null)
        {
            Debug.LogError("�������� �ٿ�ްų� ���� ������ �����Ͱ� �������� �ʽ��ϴ�. Insert Ȥ�� Get�� ���� �����͸� �������ּ���.");
            return;
        }

        Param param = new Param(); 
        param.Add("BestScore", userData.BestScore);
        
        BackendReturnObject bro = null;

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("�� ���� �ֽ� �������� ������ ������ ��û�մϴ�.");

            bro = Backend.GameData.Update("USER_DATA", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}�� �������� ������ ������ ��û�մϴ�.");

            bro = Backend.GameData.UpdateV2("USER_DATA", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.LogError("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }
    }
}
