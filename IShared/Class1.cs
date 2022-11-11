using System.Reflection.Metadata;

namespace IShared
{
    public interface IDataWriter
    {
        void WriteUserToDB(User user);
        void ReadDB();
    }

}