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


        public ActionResult Index() 
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
                            list_vendedor.Add(vendedor);
                        }
                      
                        return View(list_vendedor);
                    }
                    else
                    {
                        ViewBag.Errologin = true;
                        return RedirectToAction("Index");
                    }
                }
            }
            
        }
        public ActionResult SalvarVendedor(Vendedor vendedor)
        {


            using (var conexao_bd = new Conexao())
            {
                sql = "insert into tb_vendedores (nome,nome_usuario, senha, celular,excluido) values(@n,@u,@s,@c,@e) ";

                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    comando.Parameters.AddWithValue("@n", vendedor.Nome);

                    comando.Parameters.AddWithValue("@u", vendedor.Nome_usuario);

                    comando.Parameters.AddWithValue("@s", vendedor.Senha);

                    comando.Parameters.AddWithValue("@c", vendedor.Celular);

                    comando.Parameters.AddWithValue("@e", vendedor.Excluido);
                    comando.ExecuteNonQuery();

                    return RedirectToAction("Index");

                }
            }



        }

        public ActionResult Visualizar(int id)
        {

            using(var conexao = new Conexao())
            {
                sql = "select * from tb_vendedores where id = @id and excluido = false";

                using(var comando = new MySqlCommand())
                {
                    comando.Parameters.AddWithValue("@id", id);


                    MySqlDataReader Leitura = comando.ExecuteReader();
                    Leitura.Read();
                    if (Leitura.HasRows)
                    {
                        var vendedor = new Vendedor
                        {
                            Nome = Convert.ToString(Leitura["nome"]),
                            Nome_usuario  = Convert.ToString(Leitura["nome_usuario"]),
                            Senha = Convert.ToString(Leitura["senha"]),
                            Celular = Convert.ToString(Leitura["celular"]),

                        };
                        return View(vendedor);
                    }
                    else
                    {
                        ViewBag.ErroLogin = true;
                        return RedirectToAction("Ixdex");
                    }
                }

            }
         



        }
        public ActionResult edit (int id)
        {

            using (var conexao_bd = new Conexao())
            {
                sql = "select * from tb_vendedores where id = @id";

                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    MySqlDataReader leitura = comando.ExecuteReader();
                    leitura.Read();
                    if (leitura.HasRows)
                    {
                        var vendedor = new Vendedor
                        {
                            Nome = Convert.ToString(leitura["nome"]),
                            Nome_usuario = Convert.ToString(leitura["nome_usuario"]),
                            Senha = Convert.ToString(leitura["senha"]),
                            Celular= Convert.ToString(leitura["celular"])
                        };
                        return View(vendedor);
                    }
                    else
                    {
                        ViewBag.ErroLogin = true;
                        return RedirectToAction("Index");
                    }

                }
            }

        }


        public ActionResult NovoVendedor()
        {
            return View();
        }

        public ActionResult Atualizar_vendedor(Vendedor vendedor)
        {

            using (var conexao_bd = new Conexao())
            {
                sql = "update tb_vendedores set nome = @n, nome_usuario = @u, senha = @s, celular = @c, excluido = false where id = @id ";
                using (var comando = new MySqlCommand(sql, conexao_bd.conn))
                {
                    comando.Parameters.AddWithValue("@id", vendedor.Id);
                    
                    comando.Parameters.AddWithValue("@n", vendedor.Nome);
                    
                    comando.Parameters.AddWithValue("@u", vendedor.Nome_usuario);

                    comando.Parameters.AddWithValue("@s", vendedor.Senha);
                    
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

        public ActionResult Verificar_login(Vendedor vendedor)
        {
           
            using(var conexao = new Conexao())
            {
                sql = "select * from vendedores where nome_usuario = @u and senha = @s and excluido = false";
                using(var comando = new MySqlCommand())
                {
                    comando.Parameters.AddWithValue("@u", vendedor.Nome_usuario);
                    comando.Parameters.AddWithValue("@s", vendedor.Senha);

                    MySqlDataReader  leitura = comando.ExecuteReader();

                    leitura.Read();
                    if (leitura.HasRows)
                    {
                        return RedirectToAction("Menu");
                    }
                    else
                    { ViewBag.ErroLogin = true;
                         return RedirectToAction("Index");
                    }
                }
            }
            
            
            
            
            


        }

           
            }
        }
   
