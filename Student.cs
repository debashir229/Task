using System;
using System.Reflection.Metadata.Ecma335;
class Student
{
    string ?_name;
    string ?_surName;
    List<List<int>> Grade = new List<List<int>>();
    enum Lesson { Administrationer = 0, Designer, Programmers };                            
    int ?_age;

    
    public string Name
    {
        get { return _name != null ? _name : "Не задано";  }
        set { _name = value.ToUpper(); }
    }

    
    public string SurName
    {
        get { return _surName != null ? _surName : "Не задано"; }
        set { _surName = value.ToUpper(); }
    }

    
    public int Age { get; set; }

    
    void RandGenerator()
    {
        Random count = new Random();
        Random grade = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = count.Next(15, 35); j >= 0; j--)
            {
                int num = grade.Next(2, 6);
                Grade[i].Add(num);
            }
        }
    }


}

