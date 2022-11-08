using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class SMS_Auth : MonoBehaviour
{

    public InputField Phone;
    string sender_mobile_number;
    int num = 1234;
    string sms_body;

    //TODO 전화번호로 인증문자 보내기
    public void sendSingleSMS()
    {
        sender_mobile_number = Phone.text;
        sms_body = "신인사(신비한 인테리어 사전) 인증번호는 [" + num.ToString() + "]입니다.";
        //Open the native SMS default app
        string URL = string.Format("sms:{0}?&body={1}", sender_mobile_number, WWW.EscapeURL(sms_body));
        //Application.OpenURL(string.Format("sms:" + sender_mobile_number + "?body=" + sms_body));
        Application.OpenURL(URL);
        num++;
    }
}
