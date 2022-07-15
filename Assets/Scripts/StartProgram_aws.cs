using UnityEngine;
using UnityEngine.SceneManagement;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime.Internal;

public class StartProgram_aws : MonoBehaviour
{
    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;
    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        //gameObject.AddComponent<CustomUnityMainThreadDispatcher>(); //얘때문에 1번 안하면 namespace 에러뜹니다.
        //AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        CognitoAWSCredentials credentials = new CognitoAWSCredentials(
        "자신의 증명 풀 ID", // 자격 증명 풀 ID
        RegionEndpoint.APNortheast2 // 리전
);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
        CreateCharacter();
        FindItem();


    }

    [DynamoDBTable("User_info")]
    public class Character
    {
        [DynamoDBHashKey] // Hash key.
        public string id { get; set; }
    }

    private void CreateCharacter() //캐릭터 정보를 DB에 올리기
    {
        Character c1 = new Character
        {
            id = "happy"
        };
        context.SaveAsync(c1, (result) =>
        {
            //id가 happy, item이 1111인 캐릭터 정보를 DB에 저장
            if (result.Exception == null)
                Debug.Log("Success!");
            else
                Debug.Log(result.Exception);
        });
    }

    public void FindItem() //DB에서 캐릭터 정보 받기
    {
        Character c;
        context.LoadAsync<Character>("happy", (AmazonDynamoDBResult<Character> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
            c = result.Result;
            //Debug.Log(c.pwd); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }
}