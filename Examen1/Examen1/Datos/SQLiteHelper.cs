using Examen1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Datos
{
   public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<DatosGps>().Wait();
        }

        public Task<int> SaveDatos(DatosGps datos)
        {
            if (datos.IdDatos != 0)
            {
                return db.UpdateAsync(datos);
                ;
            }
            else
            {
                return db.InsertAsync(datos);
            }
        }
        /// <summary>
        /// Recuperar todos los personas
        /// </summary>
        /// <returns></returns>
        public Task<List<DatosGps>> GetDatosAync()
        {
            return db.Table<DatosGps>().ToListAsync();
        }
        /// <summary>
        /// Recupera las personas por la identidad
        /// </summary>
        /// <param name="IdDatos">Identidad de la persona requerida</param>
        /// <returns></returns>
        public Task<DatosGps> GetDatosByIdAsync(int IdDatos)
        {
            return db.Table<DatosGps>().Where(a => a.IdDatos == IdDatos).FirstOrDefaultAsync();
        }

        public Task<int> DropDatosAsync(DatosGps datos)
        {
            return db.DeleteAsync(datos);
        }
    }
}
