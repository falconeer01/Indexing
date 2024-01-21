using Indexing;
using Indexing.Classes;
using Indexing.Enums;
using Indexing.Interfaces;
using Newtonsoft.Json;

// Default bir user:
var user = UserFactory.GetInstance(UserTypeEnum.Personnel);
user.id = 1;
user.isActive = true;
user.isLoggedIn = false;
user.firstName = "User";
user.lastName = "Useroğlu";
user.userName = "U_oğlu";
user.password = "AS56aşsdlkjfASFF56asf4ASDF";

// Verilerin tutulduğu değişkenler:
var personnelUsers = JsonConvert.DeserializeObject<IList<Personnel>>(Datas.PersonnelJson);
var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(Datas.StudentJson);
var subcontractorUsers = JsonConvert.DeserializeObject<IList<Subcontractor>>(Datas.SubcontractorJson);

// Verilerin indexlerinin tutulduğu dictionaryler:
IDictionary<string, IList<string>> indexes = new Dictionary<string, IList<string>>();

// Verilerin aktarıldığı dictionaryler:
IDictionary<string, IUser> fastList = new Dictionary<string, IUser>();

// Json verilerine indexleme işlemi:
fastList.AddToDictionary(personnelUsers.Select(user => (user as IUser)).ToList(), indexes);
fastList.AddToDictionary(studentUsers.Select(user => (user as IUser)).ToList(), indexes);
fastList.AddToDictionary(subcontractorUsers.Select(user => (user as IUser)).ToList(), indexes);

// İlgili verilerin içinde "Dugall" indexinin aranması:
var findAll = FindByIndex("Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findAll));

// Filtrelenen indexlerin personnelUsers json verisine aktarılması:
var findedListWithPredicate = personnelUsers.FindAll(user => user.firstName == "Dugall" || user.lastName == "Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
Console.ReadKey();

// Filtrelenen indexlerin studentUsers json verisine aktarılması:
//var findedListWithPredicate = studentUsers.FindAll(user => user.firstName == "Dugall" || user.lastName == "Dugall");
//Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
//Console.ReadKey();

// Filtrelenen indexlerin subcontractorUsers json verisine aktarılması:
//var findedListWithPredicate = subcontractorUsers.FindAll(user => user.firstName == "Dugall" || user.lastName == "Dugall");
//Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
//Console.ReadKey();

// Indexe göre filtreleme işlemi yapan fonksiyon:
IList<IUser>? FindByIndex(string search)
{
    if (indexes.ContainsKey(search))
    {
        var findedKeys = indexes[search];
        return findedKeys.Select(key => fastList[key]).ToList();
    }
    return null;
}

// Extensions:
public static class MicrosoftExtensions
{
    // Verilen parametredeki verilerin tümünü bulan fonksiyon:
    public static List<T> FindAll<T>(this IList<T> values, Predicate<T> predicate)
    {
        return values.ToList().FindAll(predicate);
    }

    // Verilen parametreyi tekil olarak bulan fonksiyon:
    public static T? Find<T>(this IList<T> values, Predicate<T> predicate)
    {
        return values.ToList().Find(predicate);
    }

    // Gelen veriyi ilgili dictionarye aktaran fonksiyon:
    public static void AddToDictionary<TKey, TValue>
        (
            this IDictionary<TKey, TValue> values,
            IList<TValue> users,
            IDictionary<TKey, IList<TKey>> indexes
        )
        where TValue : IUser
        where TKey : notnull
    {

        // Girilen parametreyi TKeye çeviren fonksiyon:
        TKey castToKey(object key)
        {
            return (TKey)key;
        }

        // Index verisine yeni index ekleyen fonksiyon:
        void addIndex(object findKeyObject, TKey dataKey)
        {
            if (findKeyObject == null)
            {
                return;
            }

            TKey findKey = castToKey(findKeyObject);

            if (indexes.ContainsKey(findKey) && findKey != null)
            {
                indexes[findKey].Add(dataKey);
            }
            else
            {
                indexes.Add(findKey, new List<TKey>() { dataKey });
            }
        }

        // Dictionarye ekleme işlemi:
        users?.ToList().ForEach(user =>
        {
            TKey key = castToKey(user.userName);
            values.Add(key, user);
            addIndex(user.firstName, key);
            addIndex(user.lastName, key);
            var personal = user.CastTo<IPersonnel>();
            if (personal != null)
            {
                addIndex(personal.recordNumber, key);
            }
        });
    }

    // Girilen parametreyi TObjecte dönüştüren fonksiyon:
    public static TObject? CastTo<TObject>(this object value)
        where TObject : class
    {
        if (value is TObject)
        {
            return value as TObject;
        }
        return null;
    }
}