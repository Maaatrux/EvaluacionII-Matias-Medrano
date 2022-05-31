using LibreriaEvaluacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DAL
{
    public class PrestamoDAL
    {
        // ToDo: métodos
        public bool Insertar(PrestamoDTO datos)
        {
            return PrestamoDTO.Add(datos);
        }

        public bool Actualizar(PrestamoDTO dato)
        {
            int indice = BuscarPorIdSimple(dato.Id);

            return PrestamoDTO.Edit(dato, indice);
        }

        public bool Eliminar(PrestamoDTO datos)
        {
            return false; 
        }

        public List<PrestamoDTO> Listar()
        {
            return PrestamoDTO.datos;
        }

        public int BuscarPorIdSimple(int id)
        {
            for (int i = 0; i < PrestamoDTO.List().Count; i++)
            {
                if (PrestamoDTO.List()[i].Id == id)
                {
                    return i; 
                }
            }
            return -1;
        }

        public bool EliminarPorIndice(int indice)
        {
            return PrestamoDTO.RemoveAtIndex(indice);
        }

        public PrestamoDTO? BuscarPorId(int id)
        {
            foreach (PrestamoDTO dato in PrestamoDTO.List())
            {
                if (dato.Id == id) { return dato; }
            }
            return null;
        }
    }
}

