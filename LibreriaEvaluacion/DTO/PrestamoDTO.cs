using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DTO
{
    public class PrestamoDTO
    {
        // ToDo: atributos
        private int id;
        private int monto;

        public static List<PrestamoDTO> datos = new List<PrestamoDTO>()
        {
            new PrestamoDTO() {Id = 1, Monto = 100000},
            new PrestamoDTO() {Id = 2, Monto = 200000},
            new PrestamoDTO() {Id = 3, Monto = 300000}
        };

        // ToDo: propiedades
        public int Id { get => id; set => id = value; }
        public int Monto { get => monto; set => monto = value; }
        public int MontoMasIntereses { get => monto * 10/100 + monto; set => monto = value; }
        public int MontoAtraso { get => monto * 10 / 100 + monto + monto * 5 / 100; set => monto = value; }
        
        // ToDo: métodos
        public static bool Add(PrestamoDTO nuevoDato)
        {
            try
            {
                datos.Add(nuevoDato);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<PrestamoDTO> List()
        {
            return datos;
        }

        public static int Find(int id)
        {
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public static PrestamoDTO Find(PrestamoDTO dato)
        {
            for (int i = 0; i < datos.Count; i++) 
            {
                if (datos[i].id == dato.Id) 
                {
                    return datos[i]; 
                }
            }

            return new PrestamoDTO();
        }

        public static bool Edit(PrestamoDTO dato, int indice)
        {
            try
            {
                datos[indice] = dato;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveAtIndex(int index)
        {
            if (index >= 0)
            {
                datos.RemoveAt(index);
            }

            return false;
        }

        public static bool Remove(int id)
        {
            int idEncontrado = Find(id);

            if (idEncontrado >= 0)
            {
                datos.RemoveAt(idEncontrado);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Id: {id}, Monto: {Monto}, Monto + interés: {MontoMasIntereses}, Monto + interés + atraso: {MontoAtraso}";
        }
    }
}

