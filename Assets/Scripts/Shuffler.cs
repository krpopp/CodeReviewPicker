using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shuffler : MonoBehaviour
{
    [SerializeField]
    List<string> students;

    [SerializeField]
    TMP_Text nameField;

    int currentStudent = 0;

    private void Start()
    {
        int remainingStudents = PlayerPrefs.GetInt("studentCount");
        if (remainingStudents > 0)
        {
            students.Clear();
            for(int i = 0; i < remainingStudents; i++)
            {
                students.Add(PlayerPrefs.GetString("student" + i));
            }
        }
        //currentStudent = Random.Range(0, students.Count);
        ShuffleStudents();
        nameField.text = students[currentStudent];
    }

    void ShuffleStudents() {
        List<string> randomStudents = new List<string>();
        while(students.Count > 0)
        {
            int rand = Random.Range(0, students.Count);
            randomStudents.Add(students[rand]);
            students.RemoveAt(rand);
        }
        students = randomStudents;
    }


    public void RemoveName() {
        students.RemoveAt(currentStudent);
        nameField.text = students[currentStudent];
        SaveCurrentNames();
    }

    public void NextName()
    {
        currentStudent++;
        nameField.text = students[currentStudent];
        SaveCurrentNames();
    }

    private void SaveCurrentNames() {
        PlayerPrefs.SetInt("studentCount", students.Count);
        for (int i = 0; i < students.Count; i++) {
            PlayerPrefs.SetString("student" + i, students[i]);
        }
    }
}
