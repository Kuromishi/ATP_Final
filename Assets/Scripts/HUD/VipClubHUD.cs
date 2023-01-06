using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VipClubHUD : MonoBehaviour
{
    public startHUD startHUD;

    [Header("Noah")]
    [SerializeField] private GameObject noahPage;

    [Header("Begin Puzzle")]
    [SerializeField] private GameObject beginPuzzlePage;
    [SerializeField] private TextMeshProUGUI helloText;
    [SerializeField] private TMP_InputField firstAnswer;
    [SerializeField] private Button fisrtSubmit;
    private string _firstAnswer;

    [Header("Puzzle One")]
    [SerializeField] private GameObject puzzleOnePage;
    [SerializeField] private TMP_InputField answer1_1;
    [SerializeField] private TMP_InputField answer1_2;
    [SerializeField] private Button submit1;
    private string _answer1_1;
    private string _answer1_2;

    [Header("Puzzle Two")]
    [SerializeField] private GameObject puzzleTwoPage;
    [SerializeField] private TMP_InputField answer2_1;
    [SerializeField] private TMP_InputField answer2_2;
    [SerializeField] private TMP_InputField answer2_3;
    [SerializeField] private TMP_InputField answer2_4;
    [SerializeField] private TMP_InputField answer2_5;
    [SerializeField] private Button submit2;
    private string _answer2_1;
    private string _answer2_2;
    private string _answer2_3;
    private string _answer2_4;
    private string _answer2_5;

    [Header("End")]
    [SerializeField] private GameObject endPage;
    private bool isPassAll = false;

    [Header("Error")]
    [SerializeField] private GameObject errorPage;

    

    // Start is called before the first frame update
    void Start()
    {
        //CheckNoah();

        firstAnswer.onEndEdit.AddListener(delegate { _firstAnswer = firstAnswer.text; });
        answer1_1.onEndEdit.AddListener(delegate { _answer1_1 = answer1_1.text; });
        answer1_2.onEndEdit.AddListener(delegate { _answer1_2 = answer1_2.text; });
        answer2_1.onEndEdit.AddListener(delegate { _answer2_1 = answer2_1.text; });
        answer2_2.onEndEdit.AddListener(delegate { _answer2_2 = answer2_2.text; });
        answer2_3.onEndEdit.AddListener(delegate { _answer2_3 = answer2_3.text; });
        answer2_4.onEndEdit.AddListener(delegate { _answer2_4 = answer2_4.text; });
        answer2_5.onEndEdit.AddListener(delegate { _answer2_5 = answer2_5.text; });

        fisrtSubmit.onClick.AddListener(checkFirstSubmit);
        submit1.onClick.AddListener(checkSubmit1);
        submit2.onClick.AddListener(checkSubmit2);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckNoah();

        fisrtSubmit.onClick.AddListener(checkFirstSubmit);
        submit1.onClick.AddListener(checkSubmit1);
        submit2.onClick.AddListener(checkSubmit2);
    }

    public void checkFirstSubmit()
    {
        if (_firstAnswer == "0812")
        {
            beginPuzzlePage.SetActive(false);
            puzzleOnePage.SetActive(true);
            Debug.Log("0812");
        }
        else
        {
            errorPage.SetActive(true);
        }
    }

    public void checkSubmit1()
    {
        if (_answer1_1 == "loneliness" && _answer1_2 == "sorrow")
        {
            puzzleOnePage.SetActive(false);
            puzzleTwoPage.SetActive(true);
        }
        else
        {
            errorPage.SetActive(true);
        }
    }

    public void checkSubmit2()
    {
        if (_answer2_1 == "14" && _answer2_2 == "depravity" && _answer2_3 == "mania" && _answer2_4 == "sinner" && _answer2_5 == "wrecker")
        {
            puzzleTwoPage.SetActive(false);
            endPage.SetActive(true);
            isPassAll = true;
        }
        else
        {
            errorPage.SetActive(true);
        }
    }

    public void CheckNoah()
    {
        if (startHUD.isNoah)
        {
            noahPage.SetActive(true);
            beginPuzzlePage.SetActive(false);
            endPage.SetActive(false);
            helloText.text = "Hi,noah001!";
        }
        else
        {
            if (isPassAll)
            {
                endPage.SetActive(true);
                noahPage.SetActive(false);
                helloText.text = "Hi," + startHUD.currentUsername + "!";
            }
            else
            {
                beginPuzzlePage.SetActive(true);
                noahPage.SetActive(false);
                helloText.text = "Hi," + startHUD.currentUsername + "!";
            }
            
        }
    }
}
