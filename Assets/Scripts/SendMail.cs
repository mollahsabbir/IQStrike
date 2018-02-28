using UnityEngine;
using System.Collections;

public class SendMail : MonoBehaviour
{

    public void EmailUs()
    {
        //email Id to send the mail to
        string email = "team.tritek@gmail.com";
        //subject of the mail
        string subject = MyEscapeURL("FEEDBACK/SUGGESTION");
        //body of the mail which consists of Device Model and its Operating System
        string body = MyEscapeURL("Please Enter your message here\n\n\n\n" +
         "________" +
         "\n\nPlease Do Not Modify This\n\n" +
         "Model: " + SystemInfo.deviceModel + "\n\n" +
            "OS: " + SystemInfo.operatingSystem + "\n\n" +
         "________");
        //Open the Default Mail App
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }

    public void FacebookButton()
    {
        Application.OpenURL("http://facebook.com/TritekTeam");
    }
}

