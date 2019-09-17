using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<ECategoria> Listar(int EIdcategoria)
        {
            List<ECategoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new ECategoria { EIdCategoria = EIdcategoria });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        public bool Insertar(ECategoria categoria)
        {
            bool result = true;
            List<ECategoria> categorias = null;
            int IdNEXTcategoria = 0;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);
                categorias = new List<ECategoria>();
               //Tener cuidado categorias = DCategoria.Listar(new ECategoria(EIdcategoria = 0));

                IdNEXTcategoria = categorias.Max(x => x.EIdCategoria) + 1;
                categoria.EIdCategoria = IdNEXTcategoria;
                DCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        public bool Actualizar(ECategoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }


        public bool Eliminar(int idCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(idCategoria);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


    }
}
