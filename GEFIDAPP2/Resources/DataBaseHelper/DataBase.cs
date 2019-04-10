using Android.Util;
using GEFIDAPP2.Resources.Model;
using SQLite;
using System;
using System.Collections.Generic;

namespace GEFIDAPP2.Resources.DataBaseHelper
{
    public class DataBase
    {
        private readonly string pasta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public bool CriarBancoDeDados()
        {
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
                {
                    //conexao.DropTable<Login>();
                    //conexao.DropTable<Solicitacao>();

                    conexao.CreateTable<Login>();                    
                    conexao.CreateTable<Solicitacao>();

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InserirUsuario(Login usuario)
        {
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
                {
                    List<Login> result = conexao.Query<Login>("SELECT * FROM Login WHERE Cpf=?", usuario.Cpf);
                    if (result.Count>0) {
                        return false;
                    }
                    else
                    {
                        conexao.Insert(usuario);
                        return true;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

         public bool GetUsuario(Login usuario)
        {
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
                {
                    List<Login> result = conexao.Query<Login>("SELECT * FROM Login WHERE Cpf=? AND Senha=?", usuario.Cpf, usuario.Senha);
                    return result.Count==0 ? false : true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //public List<Login> GetExisteUsuario()
        //{
        //    try
        //    {
        //        using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
        //        {
        //            //List<Login> result = conexao.Query<Login>("SELECT * FROM Login");
        //            //return result.Count == 0 ? false : true;
        //            return conexao.Table<Login>().ToList();
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return null;
        //    }
        //}

        public bool InserirSolicitacao(Solicitacao solicitacao)
        {
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
                {
                 conexao.Insert(solicitacao);
                 return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Solicitacao> GetSolicitacao()
        {
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
                {
                    //List<Solicitacao> result = conexao.Query<Solicitacao>("SELECT * FROM Solicitacao ORDER BY IdStatusOuvidoria");
                    //return result.Count == 0 ? null : result;
                    return conexao.Table<Solicitacao>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        //public List<Login> GetAUsuarios()
        //{
        //    try
        //    {
        //        using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
        //        {
        //            return conexao.Table<Login>().ToList();
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return null;
        //    }
        //}

        //public bool DeletarUsuario(Login usuario)
        //{
        //    try
        //    {
        //        using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "GEFIDAPP.db")))
        //        {
        //            conexao.Delete(usuario);
        //            return true;
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return false;
        //    }
        //}
    }
}