using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ExportCSV : MonoBehaviour
{
    private StreamWriter sw;

    void Start()
    {
        sw = new StreamWriter(@"saveData.csv",true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "time", "Answer Type", "field", "hand", "Correctness" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        sw.Close();
    }
    void Update()
    {
    }

    public void WriteCSV(string txt1, string txt2, string txt3, string txt4, string txt5){
        sw = new StreamWriter(@"saveData.csv",true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { txt1, txt2, txt3, txt4, txt5 };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        sw.Close();
	}

    public void FinishWritingCSV(){
        sw.Close();
	}
}
