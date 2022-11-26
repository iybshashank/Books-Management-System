using System.Data;

namespace MiddleTier
{
    public interface IMiddleLayer
    {
        DataSet Load();
        int Save();
        int Update();
        int Delete(int id);
    }
}