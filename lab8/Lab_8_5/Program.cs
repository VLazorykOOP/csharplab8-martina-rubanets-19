using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Program
    {
        static void Main(string[] args)
        {
            string basePath = @"C:\Lab8\task5\";
            string oldFolderName = "K2";
            string newFolderName = "ALL";
            string studentFolderName = "Rubantz1";

            string oldFolderPath = Path.Combine(basePath, oldFolderName);
            string newFolderPath = Path.Combine(basePath, newFolderName);
            string studentFolderPath = Path.Combine(basePath, studentFolderName);

            if (Directory.Exists(oldFolderPath))
            {
                Directory.Move(oldFolderPath, newFolderPath);
                Console.WriteLine($"Folder '{oldFolderName}' has been renamed to '{newFolderName}'.");
            }
            else
            {
                Console.WriteLine($"Folder '{oldFolderName}' not found!");
            }

            if (Directory.Exists(studentFolderPath))
            {
                Directory.Delete(studentFolderPath, true);
                Console.WriteLine($"Folder '{studentFolderName}' has been deleted.");
            }
            else
            {
                Console.WriteLine($"Folder '{studentFolderName}' not found!");
            }

            Console.WriteLine("Program finished.");
        }
    
    }
}
