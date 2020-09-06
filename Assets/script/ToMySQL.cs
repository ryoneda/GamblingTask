using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;                   // Exception
using MySql.Data;               // MySQL関連
using MySql.Data.MySqlClient;

using MathNet.Numerics.Statistics;

    public class ToMySQL : MonoBehaviour
    {
        MySqlConnection con = new MySqlConnection("Server =127.0.0.1; UserID =root; Password =experiment; Database =test");
        public double sdnn;
        public double baseline;
        public double max=0;

        void Start()
        {
            try
            {
                con.Open();
                Baseline();
            }catch(MySqlException e)
            {
                Debug.Log(e.ToString());
            }
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
                    //Debug.Log(reader[0] + "," + reader[1] + "," + reader[2]);
                    //var data = new double[] { (int)reader[0], (int)reader[1], (int)reader[2] };
                    List<double> data = new List<double>();
                    for(int i=0; i<3; i++){
                        CheckAndAddRRI(data, (int)reader[i]);
					}
                    if(data != null){
                        sdnn = data.PopulationStandardDeviation();
                        max = Mathf.Max((float)sdnn, (float)max);
					}
                    
                    //Debug.Log("sdnn "+sdnn);
                }
                reader.Close();
            }catch(MySqlException e)
            {
                //Debug.Log(e.ToString());
            }
        }

        void Baseline(){
        try
        {
                string sql = "Select * from yoneda;";
                List<double> bdata = new List<double>();
                MySqlCommand com = new MySqlCommand(sql, con);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    List<double> tmpdata = new List<double>();

                    for(int i=0; i<3; i++){
                        CheckAndAddRRI(bdata, (int)reader[i]);
                        CheckAndAddRRI(tmpdata, (int)reader[i]);
					}
                    /*
                    bdata.Add((int)reader[0]);
                    bdata.Add((int)reader[1]);
                    bdata.Add((int)reader[2]);
                    */
                    max = Mathf.Max((float)tmpdata.PopulationStandardDeviation(), (float)max);
                }
                reader.Close();
                baseline = bdata.PopulationStandardDeviation();
                //Debug.Log("baseeeeee"+baseline);
		}catch(MySqlException e)
            {
                Debug.Log(e.ToString());
            }        
        }

        void CheckAndAddRRI(List<double> data, int rri){
            
            if(250<rri && rri<1500){
                data.Add(rri);     
			}
		}
    }
