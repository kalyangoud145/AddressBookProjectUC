using AddressBookTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProjectUC
{
    class FileIOOperations
    {
        //File path
        private string filePath = @"C:\Users\Ravula\source\repos\AddressBookProjectUC\AddressBookRecord.txt";
        /// <summary>
        /// Method write  data to text file in given path
        /// </summary>
        /// <param name="addressBookDictionary">The address book dictionary.</param>
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookobj.addressBook.Values)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        /// <summary>
        /// Reads data from the file path provided
        /// </summary>
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of Text File");
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
    }
}
