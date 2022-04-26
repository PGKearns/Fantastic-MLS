using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //code to start coroutines

        //StartCoroutine(Login("admin", "admin"));
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://fantasymls.000webhostapp.com/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else //i could make this an if else to say if dowloadhandler text = login success set global variables for Manager info
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    //public void function to wrap the co-routine (so we can tie these to buttons)
    public void LoginWrap()
    {
        StartCoroutine(Login("admin", "admin"));
    }

    //This coroutine is for pulling data based on the account that is logged in.

    public IEnumerator PlayerWebAccess(string username, string password)
    {
        //adjust this to use variables set by login.
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://fantasymls.000webhostapp.com/PlayerQuery.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    public void PlayerWebAccessWrap()
    {
        StartCoroutine(PlayerWebAccess("peter", "peterp"));
    }
}