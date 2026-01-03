// Путь к файлу
using System.Diagnostics.Tracing;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

string pathToRaed = "C:\\Code\\Repose\\Task13_6_2\\Task13_6_2\\input.txt";
string pathToWrite = "C:\\Code\\Repose\\Task13_6_2\\Task13_6_2\\output.txt"; // возможно не потребуется

// Создаем список, который будет содержать все строки из исходного текста, без знаков пунктуации 
List<string> textNoPunctuation = new List<string>();

//Создаем словарь для учета уникальных слов и количества их повторений
Dictionary<string, int> uniqueWords = new Dictionary<string, int>();

// Откроем файл и прочитаем его содержимое
using (StreamReader sr = File.OpenText(pathToRaed))
{
    string str = "";
    while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
    {
        var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
        textNoPunctuation.Add(noPunctuationText);
    }
}

// Записываем полученный список слов без знаков пунктуации в файл.
using (StreamWriter sw = File.CreateText(pathToWrite))  // Конструкция Using (будет рассмотрена в последующих юнитах)
{
    foreach (var str in textNoPunctuation)
    {
        sw.WriteLine(str); 
    }
}


//// Основной метод для поиска уникальных слов и количества их повторений
//foreach (string str in textNoPunctuation)
//{
//    var strInText = str;
//    Console.WriteLine(strInText);
//}

for (int i = 0; i < 30; i++)
{
    string[] stringInText = textNoPunctuation[i].Split(' ');

    foreach (var word in stringInText)
    {
        if (uniqueWords.ContainsKey(word))
        {
            uniqueWords[word]++;
        }
        else
        {
            uniqueWords.Add(word, 0);
        }
    }
}

foreach (var wd in uniqueWords)
{
    Console.WriteLine(wd.Key + " " + wd.Value);
}

