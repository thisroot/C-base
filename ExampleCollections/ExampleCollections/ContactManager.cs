using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExampleCollections
{
    class ContactManager
    {
        private List<ContactEntery> _enteries;
        private string _filePath;
        private string _log;

        public ContactManager()
        {
            _enteries = new List<ContactEntery>();
            _filePath = "";
        }

        public ContactManager(string filePath)
        {
            _enteries = new List<ContactEntery>();
            ReadFromFile(filePath);
        }

        public bool ReadFromFile(string filePath)
        {
            _filePath = filePath;
            bool retVal = true;

            if (!File.Exists(_filePath))
            {
                _log += string.Format("Document not exist in: {0}", _filePath);
                return false;
            }

            StreamReader sr = File.OpenText(_filePath);

            while (!sr.EndOfStream)
            {
                bool result = this.AddEnteryFromFileLine(sr.ReadLine());
               if(!result)
                    retVal = false;
            }
            return retVal;
        }

        public string Log
        {
            get { return _log; }
        }

        public void AddEntery(ContactEntery contact)
        {
            _enteries.Add(contact);
        }

        public void AddEntery(ContactEntery contact, bool forseCommit)
        {
            AddEntery(contact);
            if (forseCommit)
                Commit();
        }

        private void Commit()
        {
            StreamWriter sw = File.CreateText(_filePath);
            foreach(ContactEntery ce in _enteries)
            {
                sw.WriteLine(string.Format("{0}|{1}|{2}|{3}",
                    ce.LastName,
                    ce.FirstName,
                    ce.PhoneNumber,
                    ce.Email));
            }
            sw.Close();
        }

        public IEnumerable<ContactEntery> Enteries
        {
            get { return _enteries.AsReadOnly(); }
        }

        public ContactEntery SearchForContact(string lastName, string firstName)
        {
            foreach(ContactEntery ce in _enteries)
            {
                if (ce.LastName == lastName && ce.FirstName == firstName)
                    return ce;
            }
            return null;
        }

        public void RemoveEntery(ContactEntery contact)
        {
            _enteries.Remove(contact);
        }

        private bool AddEnteryFromFileLine(string line)
        {
            string[] fields = line.Split('|');

            try
            {
                ContactEntery Ce = new ContactEntery();
                Ce.LastName = fields[0];
                Ce.FirstName = fields[1];
                Ce.PhoneNumber = fields[2];
                Ce.Email = fields[3];

                _enteries.Add(Ce);
            }
            catch(Exception ex)
            {
                BusinessLogicExeption blex = new BusinessLogicExeption();
                blex.BusinessLogicMessage = "Index out of range";
                throw blex;
            }
            return true;
        }

    }

    public class BusinessLogicExeption : Exception
    {
        public string BusinessLogicMessage { get; set;}
    }
}
