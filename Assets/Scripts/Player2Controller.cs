using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class Player2Controller : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    public int count;
    private AudioSource source;
    public Vector3 jump;
    public bool isGrounded;
    public float jumpForce = 2.0f;
    public Text Playertext;
    public Text finalresult;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;
        SetCountText();
        winText.text = " ";




}


void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }




    void OnTriggerEnter(Collider other)
    {

        string palString = other.GetComponentInChildren<TextMesh>().text;
        bool flg = IsBalanced(palString);

        if (flg.Equals(true) && other.gameObject.CompareTag("Pick Up"))
        {
                source.Play();
                other.gameObject.SetActive(false);
                count += 1;
                Playertext.text = count.ToString();

            SetCountText();
            
        }

        
    }

    void SetCountText()
    {
        
        countText.text = "Your Score: " + count.ToString();

        winText.text = "COLLECTED CUBES : " + count.ToString();

        string score = countText.text;
        if(count>=3)
        {
            winText.color = Color.cyan;
            winText.fontSize = 25;

            winText.text = "!!!!...YOU WIN...!!!!";
            string c = count.ToString();
            finalresult.text = "You have collected " + c + " Palindromes";

        }

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    static Boolean isMatchingPair(char character1, char character2)
    {
        if (character1 == '(' && character2 == ')')
            return true;
        else if (character1 == '{' && character2 == '}')
            return true;
        else if (character1 == '[' && character2 == ']')
            return true;
        else
            return false;
    }

    public bool IsBalanced(string string1)
    {
        char[] exp = string1.ToCharArray();
        /* Declare an empty character stack */
        Stack<char> st = new Stack<char>();

        /* Traverse the given expression to  
            check matching parenthesis */
        for (int i = 0; i < exp.Length; i++)
        {

            /*If the exp[i] is a starting  
                parenthesis then push it*/
            if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                st.Push(exp[i]);

            /* If exp[i] is an ending parenthesis  
                then pop from stack and check if the  
                popped parenthesis is a matching pair*/
            if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
            {

                /* If we see an ending parenthesis without  
                    a pair then return false*/
                if (st.Count == 0)
                {
                    return false;
                }

                /* Pop the top element from stack, if  
                    it is not a pair parenthesis of character  
                    then there is a mismatch. This happens for  
                    expressions like {(}) */
                else if (!isMatchingPair(st.Pop(), exp[i]))
                {
                    return false;
                }
            }
        }

        /* If there is something left in expression  
            then there is a starting parenthesis without  
            a closing parenthesis */

        if (st.Count == 0)
            return true; /*balanced*/
        else
        { /*not balanced*/
            return false;
        }
    }

   


    

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


    }




}

    



