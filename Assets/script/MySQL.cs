using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;                   // Exception
using MySql.Data;               // MySQL関連
using MySql.Data.MySqlClient;

using MathNet.Numerics.Statistics;

namespace MathNetTest
{
    public class MySQL : MonoBehaviour
    {
        MySqlConnection con = new MySqlConnection("Server =127.0.0.1; UserID =root; Password =experiment; Database =test");
        public double sdnn;

        void Start()
        {
        
        
            try
            {
                con.Open();

            }catch(MySqlException e)
            {
                Debug.Log(e.ToString());
            }
        
            Debug.Log("");
        }

        void Update()
        {
            try
            {
                string sql = "Select * from yoneda order by count desc limit 1;";
                MySqlCommand com = new MySqlCommand(sql, con);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Debug.Log(reader[0] + "," + reader[1] + "," + reader[2]);
                    var data = new double[] { (int)reader[0], (int)reader[1], (int)reader[2] };
                    sdnn = data.PopulationStandardDeviation();
                    Debug.Log("sdnn "+sdnn);
                }
                reader.Close();
            }catch(MySqlException e)
            {
                Debug.Log(e.ToString());
            }
        
            Debug.Log("");
        }
    }
}