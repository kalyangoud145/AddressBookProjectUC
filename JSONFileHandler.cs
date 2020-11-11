using AddressBookTest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProjectUC
{
    class JSONFileHandler
    {
        //File path for storing the data
        string filePath = @"C:\Users\Ravula\source\repos\AddressBookProjectUC\AddressBookRecord.json";
        /// <summary>
        /// Writes the data to the json file
        /// </summary>
        /// <param name="addressBookDictionary">The address book dictionary.</param>
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)
        {
            string json = "";
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.addressBook.Values)
                {
                    json = JsonConvert.SerializeObject(contact);
                    File.WriteAllText(filePath, json);
                }
            }
            Console.WriteLine("\nSuccessfully added to JSON file.");
        }
        /// <summary>
        /// Reads data from json file.
        /// </summary>
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of JSON File");
            var json = File.ReadAllText(filePath);
            Contact contact = JsonConvert.DeserializeObject<Contact>(json);
            Console.WriteLine(contact.ToString());
        }
    }
}
