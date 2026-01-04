// Путь к файлу
using System.Diagnostics.Tracing;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

string pathToRaed = "C:\\Code\\Repose\\Task13_6_2\\Task13_6_2\\input.txt";

// Создаем список, который будет содержать все строки из исходного текста, без знаков пунктуации 
List<string> textNoPunctuation = new List<string>();

//Создаем словарь для учета уникальных слов и количества их повторений
Dictionary<string, int> uniqueWords = new Dictionary<string, int>();

// Откроем файл и прочитаем его содержимое
using (StreamReader sr = File.OpenText(pathToRaed))
{
    string str = "";
    while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной
    {
        var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
        textNoPunctuation.Add(noPunctuationText);
    }
}

// Разбиваем строки на слова
for (int i = 0; i < textNoPunctuation.Count; i++)
{
    // Вынимаем строку из исходного текста
    string stringFromText = textNoPunctuation[i].ToString();

    // Удаляем из вынутой строки символы перехода строки /n
    stringFromText.Trim('\n', '\r');

    // Преобразуем выделенную строку в массив слов
    string[] wordsArray = stringFromText.Split(' ');

    // Каждое слово пытаемся записать в словарь, если слово уже есть, то увеличиваем счетчик
    foreach (var word in wordsArray)
    {
        
        // Пропускаем пустые строки.
        if (word == "")
        {
            break;
        }

        // Если находим слово в словаре, то увеличиваем счетчик
        if (uniqueWords.ContainsKey(word))
        {
            uniqueWords[word]++;
        }

        // Если слово не нейдено, то вставляем его в словарь, счетчик задаем равным 1
        else
        {
            uniqueWords.Add(word, 1);
        }
    }
}

// сортируем полученный массив слов по количеству повторений
var sortedWords = uniqueWords.OrderByDescending(pair => pair.Value).ToArray();

// Вывод тестового массива слов с их количеством
Console.WriteLine("Список двадцати слов, наиболее часто встречающихся в исходном тексте.");
Console.WriteLine("---------------------------------------------------------------------");
for (int i = 0; i < 20; i++)
{
    Console.WriteLine("Слово - " + sortedWords[i].Key + " " + ", Количество повторений - " + sortedWords[i].Value);
}


