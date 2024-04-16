using System;
using System.Reflection.Metadata.Ecma335;
class Student
{
    string ?_name;
    string ?_surName;
    List<List<int>> Grade = new List<List<int>>();
    enum Lesson { Administrationer = 0, Designer = 1, Programmers = 2 };
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


}

