using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;                   // Exception
using MySql.Data;               // MySQL関連
using MySql.Data.MySqlClient;


public class GameStart : MonoBehaviour
{

    // Start is called before the first frame update
    public void Onclick(){
       SceneManager.LoadScene("WCST");

       MySqlConnection con = new MySqlConnection("Server =127.0.0.1; UserID =root; Password =experiment; Database =test");
        
        try
        {
            con.Open();
            string sql = "Select * from user";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log(reader[0]);
                 Debug.Log("Done");
            }
            reader.Close();
        }catch(MySqlException e)
        {
            Debug.Log(e.ToString());
        }
        
        Debug.Log("");
    }
}
