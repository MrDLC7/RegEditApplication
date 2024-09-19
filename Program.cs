using System;
using Microsoft.Win32;

namespace RegEditApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть розширення файлу (наприклад, .txt)");

            string fileExtension = Console.ReadLine();

            string registryPath = @"HKEY_CLASSES_ROOT\" + fileExtension;

            try
            {
                //Спроба отримати значення реєстру
                object regValue = Registry.GetValue(registryPath, "", null);

                if (regValue != null)
                {
                    Console.WriteLine($"Значення для розширення {fileExtension}: {regValue}");
                }
                else
                {
                    Console.WriteLine($"Розділ для розширення {fileExtension} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка в доступі до реєстру: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
