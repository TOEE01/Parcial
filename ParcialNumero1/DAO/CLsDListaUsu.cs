using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcialNumero1.MODELO;

namespace ParcialNumero1.DAO
{
    class CLsDListaUsu
    {
        public List<Tbl_empleado> Cargar()
        {
            List<Tbl_empleado> Lista;

            using (EMPLEADOEntities db = new EMPLEADOEntities()) {
                Lista = db.Tbl_empleado.ToList();
            }

                return Lista;
        }
        public void delete (int id)
        {
            try {
                using (EMPLEADOEntities db = new EMPLEADOEntities()) {
                    int Eliminar = Convert.ToInt32(id);
                    Tbl_empleado tbl_Empleadoo = db.Tbl_empleado.Where(x => x.Id_empleado == Eliminar).Select(x => x).FirstOrDefault();

                    db.Tbl_empleado.Remove(tbl_Empleadoo);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        
          
    }
}
