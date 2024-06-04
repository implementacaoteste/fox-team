using DAL;
using Models;

namespace BLL
{
    public class CompraBLL : BLLModelo<Compra, CompraDAL>
    {
        public CompraBLL()
        {
            this.DataLayer = new CompraDAL();
        }
    }
}