using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerCheck : MonoBehaviour
{

    public string answer_string;
    private string field_in;

    
    public Text goodjob;

    

    public void check_input(string input)
    {
        field_in = input;
        bool ans = answer_string.Equals(input);
        if(ans){
            Debug.Log("Correct");
            
            goodjob.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong answer");

        }
        
    }
}
