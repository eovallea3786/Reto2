using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ClassNegocio
    {

        ClassDatos objd = new ClassDatos();
        public DataTable N_listar_libros()
        {
            return objd.D_listar_libros();
        }

        public DataTable N_buscar_libros(ClassEntidad obje)
        {
            return objd.D_buscar_libros(obje);
        }
        
        public String N_mantenimiento_libros(ClassEntidad obje)
        {
            return objd.D_mantenimiento_libros(obje);
        }
        
    }
}
