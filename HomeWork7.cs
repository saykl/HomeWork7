using System;
using System.IO;

class HomeWork7
{
  static void Main()
  {
    while (true)
    {
      Console.WriteLine("Что вы хотите сделать?");
      Console.WriteLine("1 - Записать в файл");
      Console.WriteLine("2 - Прочитать из файла");
      Console.WriteLine("3 - Выйти");

      string choice = Console.ReadLine();

      if (choice == "1")
      {
        WriteToFile();
      }
      else if (choice == "2")
      {
        ReadFromFile();
      }
      else if (choice == "3")
      {
        break;
      }
      else
      {
        Console.WriteLine("Я вас не понял, попробуйте еще раз.");
      }
    }
  }

  static void WriteToFile()
  {
    Console.WriteLine("Введите текст для записи в файл:");
    string text = Console.ReadLine();

    Console.WriteLine("Введите имя файла:");
    string fileName = Console.ReadLine() + ".txt";

    File.WriteAllText(fileName, text);
    Console.WriteLine("Текст записан в файл " + fileName);
  }

  static void ReadFromFile()
  {
    string[] files = Directory.GetFiles(".", "*.txt");

    if (files.Length == 0)
    {
      Console.WriteLine("Текстовых файлов не найдено.");
      return;
    }

    Console.WriteLine("Список доступных файлов:");
    for (int i = 0; i < files.Length; i++)
    {
      Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
    }

    Console.WriteLine("Введите номер файла для чтения:");
    if (int.TryParse(Console.ReadLine(), out int fileNumber) && fileNumber > 0 && fileNumber <= files.Length)
    {
      string fileName = files[fileNumber - 1];
      string text = File.ReadAllText(fileName);
      Console.WriteLine("Содержимое файла:");
      Console.WriteLine(text);
    }
    else
    {
      Console.WriteLine("Неверный номер файла.");
    }
  }
}