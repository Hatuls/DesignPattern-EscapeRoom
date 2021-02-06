using System.Collections;
using TMPro;
using UnityEngine;

public class CodeHandler : MonoBehaviour
{
    static CodeHandler _instance;
    [SerializeField] InputButton[] btns;
    [SerializeField] int[] playersInput = new int[3];
    [SerializeField] int[] password;
    [SerializeField] TextMeshPro tmp;
    int currentInsert = 0;
    [SerializeField]
    private GameObject Parent;

    private void Awake()
    {
        _instance = this;
        ResetPassword();
        Parent.SetActive(true);
    }
    public static CodeHandler GetInstance => _instance;

    public void CheckPassword()
    {
        bool checkAnswer = true;



        for (int i = 0; i < playersInput.Length; i++)
        {

            checkAnswer &= playersInput[i] == password[i];
            if (!checkAnswer || playersInput[i] == -1)
            {
                WrongPassword();
                return;
            }
        }
        CorrectPassword();
    }


    void ResetPassword()
    {

        for (int i = 0; i < playersInput.Length; i++)
            playersInput[i] = -1;

        currentInsert = 0;
        PrintDebug();
    }

    void WrongPassword()
    {

        Debug.Log("Wrong Answer");

        ShowAnswer(false);
        ResetPassword();
    }
    void CorrectPassword()
    {
        Debug.Log("Correct Answer");
        ShowAnswer(true);
        StartCoroutine(DisableParent());
    }

    public void InsertNumber(int input)
    {
        if (input == 11)
        {
            CheckPassword();
            return;
        }
        else if (input == 12)
        {
            ResetPassword();
            return;
        }
        if (currentInsert >= password.Length)
            return;

        playersInput[currentInsert] = input;
        currentInsert++;



        PrintDebug();
    }

    public void PrintDebug()
    {
        string playerInputsCache = "";

        for (int i = 0; i < playersInput.Length; i++)
        {
            if (playersInput[i] != -1)
                playerInputsCache += playersInput[i].ToString();
        }


        tmp.text = playerInputsCache;
        //Debug.Log(string.Format("The Password is {0}, {1} , {2}", password[0], password[1], password[2]));
        //Debug.Log(string.Format("The player input is {0}, {1} , {2} ", playersInput[0], playersInput[1], playersInput[2]));
        //Debug.Log(currentInsert);
    }



    void ShowAnswer(bool isCorrect)
    {
        foreach (var item in btns)
        {
            item.ActivateButtonColor(isCorrect);
        }


    }

    IEnumerator DisableParent()
    {
        yield return new WaitForSeconds(0.3f);
        Parent.SetActive(false);
    }



}
