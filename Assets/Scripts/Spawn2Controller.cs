﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawn2Controller : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait; 
    public int startWait;
    public bool stop;
    int randEnemy;
    public int enemyCount;
    public TextMesh Cubetext;
    private static int palindromeLength;
    private string randomString;
    public int thestringlength;
    public int countPalindrome;
    public Text palindrometext;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());


        Cubetext = GameObject.Find("Pickup").GetComponentInChildren<TextMesh>();
        Cubetext.text = " ";


    }





    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);


        palindromeLength = Random.Range(3, 10);
        spawn();



    }




    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (enemyCount < 26)
        {
            randEnemy = Random.Range(0, 6);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
            enemyCount += 1;
        }
    }


    public void spawn()
    {
        int randomNumber;
        countPalindrome = 0;


        randomNumber = Random.Range(0,4);
        randomString = "";

            string[] characters = new string[] {"(" ,"i", "6",")" };
        if (randomNumber == 1)
        {
            countPalindrome = countPalindrome + 1;
            palindrometext.text = countPalindrome.ToString();

            Cubetext.text =  GenerateParenthesis(characters);

        }

        if(randomNumber == 3)
        {
            Cubetext.text = GenerateParenthesis(characters);

        }
        else
        {
            Cubetext.text = "x"+ GenerateRandomString(characters);
            }
    }


    string GenerateParenthesis(string[] s)
    {
        randomString = "";

        thestringlength = Random.Range(6,7 );
      
            for (int m = 0; m < thestringlength / 2; m++)
            {
                randomString = randomString + s[Random.Range(0, s.Length)];
            }
        randomString = randomString + new string(randomString.Reverse().ToArray())+randomString ;
  
        

        return "x"+randomString;


    }

    string GenerateRandomString(string[] s)
    {
        randomString = "";

        thestringlength = Random.Range(9, 15);

        for (int m = 0; m < thestringlength; m++)
        {
            randomString = randomString + s[Random.Range(0, s.Length)];
        }
        Cubetext.color = Color.black;

        return randomString;

    }




}


