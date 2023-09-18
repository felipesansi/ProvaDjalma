using MySql.Data.MySqlClient;
using ProvaDjalma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaDjalma.Controllers
{
    public class UsuarioController : Controller
    {
        string sql = "";


        public ActionResult Visualizar_vendedor() 
        {
            using (var conexao_bd = new Conexao()) 
            {
                sql = "select * from tb_vendedores where excluido = true";
                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    MySqlDataReader leitura = comando.ExecuteReader();
                    if (leitura.HasRows)
                    { var list_vendedor = new List<Vendedor>();
                        while (leitura.Read())
                        {
                            var vendedor = new Vendedor
                            {
                                Id = Convert.ToInt32(leitura["id"]),
                                Nome = Convert.ToString(leitura["nome"]),
                                Celular = Convert.ToString(leitura["celular"])

                            };
                        }
                    }
                }
            }
            return View();  
        }
        public ActionResult Salvar_vendedor(Vendedor vendedor)
        {


            using (var conexao_bd = new Conexao())
            {
                sql = "insert into tb_vendedores (nome,celular,excluido) values(@n,@c,@e) ";

                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    comando.Parameters.AddWithValue("@n", vendedor.Nome);
                    comando.Parameters.AddWithValue("@c", vendedor.Celular);
                    comando.Parameters.AddWithValue("@e", vendedor.Excluido);
                    comando.ExecuteNonQuery();

                    return RedirectToAction("Index");

                }
            }



        }

        public ActionResult Atualizar_vendedor(Vendedor vendedor)
        {

            using (var conexao_bd = new Conexao())
            {
                sql = "update tb_vendedores set nome = @n, celular = @c, excluido = false where id = @id ";
                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    comando.Parameters.AddWithValue("@id", vendedor.Id);
                    comando.Parameters.AddWithValue("@n", vendedor.Nome);
                    comando.Parameters.AddWithValue("@c", vendedor.Celular);
                    comando.Parameters.AddWithValue("@e", vendedor.Excluido);
                    comando.ExecuteNonQuery();

                    return RedirectToAction("Index");
                }




            }
        }

        public ActionResult Excuir_vendedor(Vendedor vendedor) 
        { 
            using(var conexao_bd = new Conexao()) 
            {
                sql = "update tb_vendedores set excluido = true where id = @id";
                using( var comando = new MySqlCommand())
                {
                    comando.Parameters.AddWithValue("@id", vendedor.Id);

                    comando.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
        }

            // GET: Usuario
            public ActionResult Index()
            {
                return View();
            }
        }
    } 
