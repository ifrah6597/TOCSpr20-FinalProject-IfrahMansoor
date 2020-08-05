using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
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
        bool flg = IsPalindrome(palString);

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



    public bool IsPalindrome(string string1)
    {
        char[] ch = string1.ToCharArray();
        Array.Reverse(ch);
        string rev = new string(ch);
        bool b = string1.Equals(rev, StringComparison.OrdinalIgnoreCase);
        if (b == true)
        {
            return true;
        }
        return false;
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


