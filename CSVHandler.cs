using AddressBookTest;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookProjectUC
{
    class CSVHandler
    {
        //Path filr
        private string filePath = @"C:\Users\Ravula\source\repos\AddressBookProjectUC\AddressBookCSV.csv";
        /// <summary>
        /// Method for writing the data to csv file
        /// </summary>
        /// <param name="addressBookDictionary">The address book dictionary.</param>
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (AddressBook obj in addressBookDictionary.Values)
                    {
                        List<Contact> contactRecord = obj.addressBook.Values.ToList();
                        csv.WriteRecords(contactRecord);
                    }
                    Console.WriteLine("\nSuccessfully added to CSV file.");
                    csv.Dispose();
                }
            }
        }
        /// <summary>
        /// Method for reading data from csv file
        /// </summary>
        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Below are Contents of CSV File");
                    List<Contact> contactRecord = csv.GetRecords<Contact>().ToList();
                    foreach (Contact contact in contactRecord)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
        }
    }
}
