using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Oxxxy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> lines = new List<string>();
            FileStream file = new FileStream("C:/Users/ASUS/Desktop/вечный жид..txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);

            while (!readFile.EndOfStream)
            {
                string s = readFile.ReadLine().ToLower();
                string[] words = s.Split(new char[] { ' ', ',' , '.', '\0' , '-', '—' , '\"',
                '&','*', '!', '?' ,'(', ')', '\n', '»', '«' });
                foreach (string WORD in words)
                    if (WORD != "" && WORD != null)
                        lines.Add(WORD);
            }
            readFile.Close();
        
            var newlist = lines.GroupBy(g => g).OrderByDescending(g =>g.Count()).Select(g => $"{g.Key} {g.Count()}");


            gwq.Text = string.Join(Environment.NewLine , newlist);

        }
    }
}
