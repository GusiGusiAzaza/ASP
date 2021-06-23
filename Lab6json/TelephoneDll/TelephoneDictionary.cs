using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TelephoneDll
{
    public class TelephoneDictionary : IPhoneDictionary
    {
        private List<Telephone> telephones = new List<Telephone>();

        public TelephoneDictionary()
        {

        }

        public List<Telephone> selectAll()
        {
            string jsonString = File.ReadAllText("C:\\main\\6SEM\\ASP\\Lab6json\\Lab3new\\App_Data\\numbers.json");
            telephones = JsonConvert.DeserializeObject<List<Telephone>>(jsonString).ToList();
            return telephones.OrderBy(u => u.surname).ToList();
        }

        public void insert(string surname, int number)
        {
            telephones = selectAll();
            int id = 0;
            foreach (Telephone telephone in telephones)
            {
                if (telephone.id > id)
                {
                    id = telephone.id;
                }
            }
            telephones.Add(new Telephone { id = id + 1, surname = surname, number = number });
            saveChange(telephones);
        }

        public void update(int id, string surname, int number)
        {
            telephones = selectAll();
            int index = telephones.IndexOf(telephones.Find(x => x.id == id));
            if (index != -1)
            {
                telephones[index].surname = surname;
                telephones[index].number = number;
                saveChange(telephones);
            }
        }

        public void delete(int id)
        {
            telephones = selectAll();
            Telephone removed = telephones.Find(x => x.id == id);
            if (removed != null)
            {
                telephones.Remove(removed);
                saveChange(telephones);
            }
        }

        public void saveChange(List<Telephone> telephones)
        {
            string jsonString = JsonConvert.SerializeObject(telephones);
            File.WriteAllText("C:\\main\\6SEM\\ASP\\Lab6json\\Lab3new\\App_Data\\numbers.json", jsonString);
        }
    }
}
