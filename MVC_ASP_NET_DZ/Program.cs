public class Note
{
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public List<string> Tags { get; set; }

    public Note()
    {
        Name = "testname";
        Text = "testtext";
        Date = DateTime.Now;
        Tags = new List<string>();
        Tags.Add("test1");
        Tags.Add("test2");
        Tags.Add("test3");

    }
}

public class View
{
    Controler controler =  new Controler();

    public void PrintData()
    {
        var temp = controler.Print();
        Console.WriteLine(temp);
    }
    public void SaveFile()
    {
        var temp = controler.Print();
        using (StreamWriter sw = new StreamWriter("temp.txt"))
        {
            sw.WriteLine(temp.ToString());

        }
    }

}
public class Controler
{
    public string Print()
    {
        Model model = new Model();
        return model.GetData();
    }
}
public class Model
{
    public string GetData()
    {
        Note note = new Note();
        string str = note.Name + " " + note.Text + " " + Convert.ToString(note.Date) + " ";
        foreach(var i in note.Tags)
        {
            str += i + " ";
        }
        return str;
    }
}

public class Program
{
    public static void Main()
    {

        View view = new View();
        while (true)
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Print");
            Console.WriteLine("2 - Save to File");
            Console.Write("Enter menu__ ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if(x == 0)
            {
                Console.WriteLine("Goodbaye");
                break;
            }
            else if(x == 1)
            {
                
                view.PrintData();
            }
            else if(x==2)
            {
                view.SaveFile();
            }
            else
            {
                Console.WriteLine("ERROR!");
                continue;
            }
        }
    }
}
