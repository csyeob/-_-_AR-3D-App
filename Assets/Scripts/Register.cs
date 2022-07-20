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

public class Register : MonoBehaviour
{
    public DynamoDBContext context;
    public AmazonDynamoDBClient DBclient;

    public InputField Id;
    public InputField Pwd;
    public InputField Name;
    public InputField Email;
    public InputField Phone;
    public InputField Check_pwd;

    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        //gameObject.AddComponent<CustomUnityMainThreadDispatcher>(); //얘때문에 1번 안하면 namespace 에러뜹니다.
        //AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        CognitoAWSCredentials credentials = new CognitoAWSCredentials(
        "자신의 자격 증명 풀ID", // 자격 증명 풀 ID
        RegionEndpoint.APNortheast2 // 리전
        );
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }

    //TODO AWS DynamoDB에 user정보 업로드

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

    public void UploadDB() //캐릭터 정보를 DB에 올리기
    {   
        Character c1 = new Character
        {   
            id = Id.text,
            pwd = Pwd.text,
            name = Name.text,
            email = Email.text,
            phone = Phone.text
        };
        
        if (Phone.text == "") Toast.Show("전화번호를 입력해주세요.", 2f, ToastColor.Red);
        if (Email.text == "") Toast.Show("이메일를 입력해주세요.", 2f, ToastColor.Red);
        if (Name.text == "") Toast.Show("이름을 입력해주세요.", 2f, ToastColor.Red);
        if (Pwd.text == "") Toast.Show("비밀번호를 입력해주세요.", 2f, ToastColor.Red);
        if (Id.text == "") Toast.Show("아이디를 입력해주세요.", 2f, ToastColor.Red);
      
        if (Pwd.text != Check_pwd.text) Toast.Show("비밀번호가 일치하지 않습니다.");
        else if (Id.text != "" && Pwd.text != "" && Name.text != "" && Email.text != "" && Phone.text != "")
        {
            context.SaveAsync(c1, (result) =>
            {
                //저장 확인
                if (result.Exception == null)
                {
                    Debug.Log("Success!");
                    Toast.Show("회원가입 성공", 2f, ToastColor.Yellow);
                    StartCoroutine(loadScene());
                }
                else
                    Debug.Log(result.Exception);
            });
        }
    }


    //TODO ID중복 처리
        public void CheckID() //DB에서 user 정보 받기
        {
            Character c;
            context.LoadAsync<Character>(Id.text, (AmazonDynamoDBResult<Character> result) =>
            {
                // id가 abcd인 캐릭터 정보를 DB에서 받아옴
                c = result.Result;
                if(c == null)
                {
                    Toast.Show("사용가능한 아이디 입니다.", 2f, ToastColor.Green);
                }
                else
                {
                    Toast.Show("사용중인 아이디 입니다.", 2f, ToastColor.Red);
                }
                Debug.Log(c.pwd); //찾은 캐릭터 정보 중 아이템 정보 출력
            }, null);
        }

    //TODO scene 전환 딜레이
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Login");
    }

}