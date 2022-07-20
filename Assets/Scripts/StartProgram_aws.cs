using UnityEngine;
using UnityEngine.SceneManagement;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime.Internal;
using UnityEngine.UI;
using EasyUI.Toast;
using System.Collections;

public class StartProgram_aws : MonoBehaviour
{
    public DynamoDBContext context;
    public AmazonDynamoDBClient DBclient;
    public  InputField Id;
    public  InputField Pwd;


    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        //gameObject.AddComponent<CustomUnityMainThreadDispatcher>(); //얘때문에 1번 안하면 namespace 에러뜹니다.
        //AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        CognitoAWSCredentials credentials = new CognitoAWSCredentials(
        "자신의 자격증명 풀 ID", // 자격 증명 풀 ID
        RegionEndpoint.APNortheast2 // 리전
        );
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }

   [DynamoDBTable("User_info")]
    public class Character
    {
        [DynamoDBHashKey] // Hash key.
        public string id { get; set; }
        public string pwd { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public void FindItem() //DB에서 캐릭터 정보 받기
    {
        Character c;
        context.LoadAsync<Character>(Id.text, (AmazonDynamoDBResult<Character> result) =>
        {
            c = result.Result;
            if(c == null)
            {
                Toast.Show("아이디 비밀번호를 다시 입력해주세요.",2f,ToastColor.Red);
            }
            else
            {
                if(Pwd.text == c.pwd)
                {
                    Toast.Show("로그인 성공", 2f, ToastColor.Green);
                    StartCoroutine(loadScene());
                }
                else
                {
                    Toast.Show("비밀번호를 확인해주세요", 2f, ToastColor.Red);
                }
            }
            //Debug.Log(c.pwd); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }
    //TODO scene 전환 딜레이
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Main");
    }

}