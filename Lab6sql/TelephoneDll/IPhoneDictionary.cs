using System.Collections.Generic;

namespace TelephoneDll
{
    public interface IPhoneDictionary
    {
        void insert(string surname, string number);
        List<Telephone> selectAll();
        void update(int? id, string surname, string number);
        void delete(int? id);
    }
}
