using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Globalization;

public class FinalScore : MonoBehaviour {

	public Text ScoreLabel;
    string fstr = "highscores.txt";
	// Use this for initialization
	void Start () {
		float score = ScoreManager.Instance.Score;
        Update_Highscores(fstr, score);
		if (score < 52732) {
			ScoreLabel.text = "You only paid $" + score + ". Subra is sad. :-(";
		} else {
			ScoreLabel.text = "You paid $" + score + ". You have successfully supported the bureaucracy!!!";
		}
		
	}
    private void Update_Highscores(string fst, float score)
    {
        float[] temper = new float[10];
        int placed = 0;
        int inc = 0;
        int inc1 = 0;
        string[] temps;
        temps = new string[10];

        FileStream F = new FileStream(fst, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        foreach (string line in File.ReadAllLines(fst))
        {
            temper[inc] = float.Parse(line, CultureInfo.InvariantCulture.NumberFormat);
            inc += 1;
        }
        foreach (float tempf in temper)
        {
            if (placed == 1)
            {
                temper[inc1] = score;
                score = tempf;
            }
            else
            {
                if (score > temper[inc1])
                {
                    placed = 1;
                    temper[inc1] = score;
                    score = tempf;
                }
            }
            inc1 += 1;
        }
        if (inc1 < 10)
        {
            temper[inc1] = score;
        }

        File.WriteAllText(fst, "");
        inc = 0;
        foreach (float tempf in temper)
        {
            temps[inc] = tempf.ToString();
        }
        File.WriteAllLines(fst, temps);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
