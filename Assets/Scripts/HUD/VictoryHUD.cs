using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryHUD : MonoBehaviour
{
    [SerializeField] private TMP_InputField registerUser;
    [SerializeField] private TextMeshProUGUI registerInfo;
    [SerializeField] private Button registerButton;
    [SerializeField] private GameObject errorPage;

    [Header("Pages")]
    [SerializeField] private GameObject registerPage;
    [SerializeField] private GameObject lastPage;

    private string username;
    // Start is called before the first frame update
    void Start()
    {
        registerUser.onEndEdit.AddListener(delegate { username = registerUser.text; });
        registerButton.onClick.AddListener(checkUsername);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkUsername()
    {
        if (username == "noah001" || username == "rexthemonster" || username == "sophia")
        {
            errorPage.SetActive(true);
        }
        else
        {
            errorPage.SetActive(false);
            registerPage.SetActive(false);
            lastPage.SetActive(true);
            registerInfo.text = "Username:" + username + ", Password:87654321";
        }
    }
}
