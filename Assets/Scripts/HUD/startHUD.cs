using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class startHUD : MonoBehaviour
{
    public VipClubHUD vipClubHUD;
    
    [Header ("button")]
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject vipClub;

    [Header("Menu")]
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject vipMenu;
    [SerializeField] private GameObject LoginButton;
    [SerializeField] private GameObject errorLog;
    public GameObject vipClubPanel;
    public bool isNoah = false;

    [Header("Blankspace")]
    [SerializeField] private GameObject username;
    [SerializeField] private GameObject password;

    [Header("if Tutorial")]
    [SerializeField] private Button yesTutorial;
    [SerializeField] private Button noTutorial;

    private TMP_InputField _username;
    private TMP_InputField _password;
    [HideInInspector] public string currentUsername;
    private string currentPassword;

    // Start is called before the first frame update
    void Start()
    {
        _username = username.GetComponent<TMP_InputField>();
        _password = password.GetComponent<TMP_InputField>();

        play.GetComponent<Button>().onClick.AddListener(PlayButton);
        credits.GetComponent<Button>().onClick.AddListener(CreditButton);
        vipClub.GetComponent<Button>().onClick.AddListener(VipClubButton);
        LoginButton.GetComponent<Button>().onClick.AddListener(canLogin);
        LoginButton.GetComponent<Button>().onClick.AddListener(vipClubHUD.CheckNoah);

        yesTutorial.GetComponent<Button>().onClick.AddListener(_yesTutorial);
        noTutorial.GetComponent<Button>().onClick.AddListener(_noTutorial);

        _username.onEndEdit.AddListener(delegate{ currentUsername = _username.text; });
        _password.onEndEdit.AddListener(delegate { currentPassword = _password.text; });
     
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void PlayButton()
    {

    }

    public void CreditButton()
    {
        creditMenu.SetActive(true);
    }

    public void VipClubButton()
    {
        vipMenu.SetActive(true);
    }


    public void canLogin()
    {
        if(currentUsername == "noah001" && currentPassword == "qwer2690")
        {
            isNoah = true;
            Debug.Log("Noah log in.");
            vipClubPanel.SetActive(true);
            vipMenu.SetActive(false);
            errorLog.SetActive(false);
        }

        else if (currentPassword == "87654321" && currentUsername != "noah001")
        {
            isNoah = false;
            Debug.Log("Player log in.");
            vipClubPanel.SetActive(true);
            vipMenu.SetActive(false);
            errorLog.SetActive(false);
        }

        else
        {
            Debug.Log("Can't log in.");
            errorLog.SetActive(true);
        }

        //Debug.Log("username:"+currentUsername+",password:"+currentPassword);
    }

    public void _yesTutorial()
    {

    }

    public void _noTutorial()
    {

    }

}
