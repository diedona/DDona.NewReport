﻿using DDona.NewReport.Infra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDona.NewReport.DataGenerator
{
    class Program
    {
        private const int NUM_LOJAS = 10;
        private const int NUM_PRODUTOS = 350;
        private const int NUM_MAX_GRADES = 8;
        private const string DELETE_ALL = @"
            DELETE FROM GRADE;
            DELETE FROM PRODUTO;
            DELETE FROM MARCA;
            DELETE FROM COR;
            DELETE FROM TAMANHO;
            DELETE FROM LOJA;
        ";

        static void Main(string[] args)
        {
            Console.Write("Delete all: (Y) / (N)");
            string ForceDelete = Console.ReadLine();

            using (NewReportDB db = new NewReportDB())
            {
                db.Database.Log = (x => Debug.WriteLine(x));

                CheckDeleteAll(ForceDelete, db);

                CheckGenerateLojaData(db);
                CheckGenerateMarcaData(db);
                CheckGenerateTamanho(db);
                CheckGenerateCor(db);
                CheckGenerateProduto(db);
                CheckGenerateGrade(db);

                db.SaveChanges();
            }
        }

        private static void CheckDeleteAll(string ForceDelete, NewReportDB db)
        {
            if (ForceDelete.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                db.Database.ExecuteSqlCommand(DELETE_ALL);
                Message("BANCO ZERADO");
            }
            else
            {
                Message("USANDO DADOS EXISTENTES");
            }
        }

        #region GRADE
        private static void CheckGenerateGrade(NewReportDB db)
        {
            if (db.Grade.Count() == 0)
            {
                Message("GERANDO GRADE");
                List<Grade> Grades = GenerateGradeData(db.Produto.Local.ToList(), 
                    db.Cor.Local.ToList(),
                    db.Tamanho.Local.ToList());
                
                db.Grade.AddRange(Grades);
                try
                {
                    Message("GRADE GERADA");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                Message("GRADE JÁ EXISTENTE");
            }
        }

        private static List<Grade> GenerateGradeData(List<Produto> Produtos, List<Cor> Cores, List<Tamanho> Tamanhos)
        {
            List<Grade> Grades = new List<Grade>();

            Random Random = new Random(DateTime.Now.Millisecond);
            foreach (Produto Produto in Produtos)
            {
                int NroGrades = Random.Next(1, NUM_MAX_GRADES);
                for (int i = 0; i < NroGrades; i++)
                {
                    int Cor1 = Random.Next(0, Cores.Count - 1);
                    int Cor2 = Random.Next(0, Cores.Count - 1);
                    int Cor3 = Random.Next(0, Cores.Count - 1);
                    int TamanhoId = Random.Next(0, Tamanhos.Count - 1);
                    Tamanho Tamanho = Tamanhos.ElementAt(TamanhoId);

                    Grade Grade = new Grade()
                    {
                        Cor_Cor1Id = Cores.ElementAt(Cor1),
                        Cor_Cor2Id = Cores.ElementAt(Cor2),
                        Cor_Cor3Id = Cores.ElementAt(Cor3),
                        Tamanho = Tamanho,
                        Produto = Produto
                    };

                    Grade.Referencia = GetReferencia(Tamanho.Nome, Produto.Descricao);
                    Grades.Add(Grade);
                }
            }

            return Grades;
        }

        private static string GetReferencia(string Tamanho, string ProductName)
        {
            string ProductCut = ProductName.Substring(0, ProductName.Length - 4).Trim();
            return string.Concat(ProductCut, " - ", Tamanho);
        }
        #endregion

        #region PRODUTO
        private static void CheckGenerateProduto(NewReportDB db)
        {
            if (db.Produto.Count() == 0)
            {
                Message("GERANDO PRODUTO");
                List<Produto> Produtos = GenerateProdutoData(db.Loja.Local.ToList(), db.Marca.Local.ToList());
                db.Produto.AddRange(Produtos);
                try
                {
                    Message("PRODUTO GERADO");
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            else
            {
                Message("PRODUTO JÁ EXISTENTE");
            }
        }

        private static List<Produto> GenerateProdutoData(List<Loja> Lojas, List<Marca> Marcas)
        {
            List<Produto> Produtos = new List<Produto>();

            Random Random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < NUM_PRODUTOS; i++)
            {
                bool ProdutoExiste = false;
                Produto Produto = null;

                int PorcentagemLucro = Random.Next(1, 15);
                decimal PC = RandomNumberBetween(Random, 5, 150);
                decimal PV = PC * (1m + (PorcentagemLucro / 100.0m));

                Produto = new Produto()
                {
                    PrecoCompra = PC,
                    PrecoVenda = PV
                };

                int qnt = 0;
                do
                {
                    int RandomMarca = Random.Next(0, Marcas.Count - 1);
                    int RandomLoja = Random.Next(0, Lojas.Count - 1);
                    Marca Marca = Marcas.ElementAt(RandomMarca);
                    Loja Loja = Lojas.ElementAt(RandomLoja);

                    Produto.Loja = Loja;
                    Produto.Marca = Marca;
                    Produto.Descricao = GetRandomProductName(Random);

                    ProdutoExiste = (Produtos.Exists(x =>
                        x.Descricao.Equals(Produto.Descricao)
                        && x.Loja.Nome.Equals(Produto.Loja.Nome)
                        && x.Marca.Nome.Equals(Produto.Marca.Nome)
                    ));

                    if (ProdutoExiste)
                    {
                        qnt++;
                        Message("JÁ EXISTE - " + qnt.ToString());
                    }

                } while (ProdutoExiste);

                Produtos.Add(Produto);
            }

            return Produtos;
        }

        private static decimal RandomNumberBetween(Random Random, decimal minValue, decimal maxValue)
        {
            decimal next = Convert.ToDecimal(Random.NextDouble());
            return minValue + (next * (maxValue - minValue));
        }

        private static string GetRandomProductName(Random Random)
        {
            string[] nomes = new string[] { 
                "MEIA CALÇA", 
                "CHINELO DE CAPA", 
                "CHINELO DE DEDO",
                "MEIA CALÇA 3/4", 
                "BERMUDA JEANS", 
                "BERMUDA SURF", 
                "BERMUDA ESPORTE",
                "TÊNIS CASUAL", 
                "SAPATENIS", 
                "SAPATO FORMAL", 
                "CALÇA JEANS", 
                "CALÇA/BERMUDA",
                "SAPATILHA", 
                "CAMISA", 
                "CAMISA SOCIAL", 
                "TERNO FLEX", 
                "TERNO FULL", 
                "GRAVATA FORMAL", 
                "CAMISETA INFORMAL",
                "CAMISETA SURF", 
                "CAMISETA TEMÁTICA", 
                "PANTUFA"};

            int idx = Random.Next(0, nomes.Length);
            return nomes[idx];
        }
        #endregion

        #region COR
        private static void CheckGenerateCor(NewReportDB db)
        {
            if (db.Cor.Count() == 0)
            {
                Message("GERANDO COR");
                List<Cor> Cores = GenerateCorData();
                db.Cor.AddRange(Cores);
                Message("COR GERADO");
            }
            else
            {
                Message("COR JÁ EXISTENTE");
            }
        }

        private static List<Cor> GenerateCorData()
        {
            List<Cor> Cores = new List<Cor>();
            Cores.Add(new Cor() { Nome = "Preto" });
            Cores.Add(new Cor() { Nome = "Azul" });
            Cores.Add(new Cor() { Nome = "Verde" });
            Cores.Add(new Cor() { Nome = "Diversas" });
            Cores.Add(new Cor() { Nome = "Rosa" });
            Cores.Add(new Cor() { Nome = "Amarelo" });
            Cores.Add(new Cor() { Nome = "Vermelho" });
            Cores.Add(new Cor() { Nome = "Roxo" });
            Cores.Add(new Cor() { Nome = "Bege" });
            Cores.Add(new Cor() { Nome = "Quartzo" });

            return Cores;
        }
        #endregion

        #region TAMANHO
        private static void CheckGenerateTamanho(NewReportDB db)
        {
            if (db.Tamanho.Count() == 0)
            {
                Message("GERANDO TAMANHO");
                List<Tamanho> Tamanhos = GenerateTamanhoData();
                db.Tamanho.AddRange(Tamanhos);
                Message("TAMANHO GERADO");
            }
            else
            {
                Message("TAMANHO JÁ EXISTENTE");
            }
        }

        private static List<Tamanho> GenerateTamanhoData()
        {
            List<Tamanho> Tamanhos = new List<Tamanho>();
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "1P" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "PP" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "P" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "M" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "G" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "GG" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "XG" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "XXG" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "3G" });
            Tamanhos.Add(new Tamanho() { Ordem = Tamanhos.Count + 1, Nome = "UN" });

            return Tamanhos;
        }
        #endregion

        #region MARCA
        private static void CheckGenerateMarcaData(NewReportDB db)
        {
            if (db.Marca.Count() == 0)
            {
                Message("GERANDO MARCA");
                List<Marca> Marcas = GenerateMarcaData();
                db.Marca.AddRange(Marcas);
                Message("MARCA GERADA");
            }
            else
            {
                Message("MARCA JÁ EXISTENTE");
            }
        }

        private static List<Marca> GenerateMarcaData()
        {
            List<Marca> Marcas = new List<Marca>();
            Marcas.Add(new Marca() { Nome = "Adidas" });
            Marcas.Add(new Marca() { Nome = "Aqua" });
            Marcas.Add(new Marca() { Nome = "Bello" });
            Marcas.Add(new Marca() { Nome = "Brioni" });
            Marcas.Add(new Marca() { Nome = "Escada" });
            Marcas.Add(new Marca() { Nome = "Fendi" });
            Marcas.Add(new Marca() { Nome = "Hermes" });
            Marcas.Add(new Marca() { Nome = "Locman" });
            Marcas.Add(new Marca() { Nome = "Nanet Lepore" });
            Marcas.Add(new Marca() { Nome = "ZZegna" });

            return Marcas;
        }
        #endregion

        #region LOJA
        private static void CheckGenerateLojaData(NewReportDB db)
        {
            if (db.Loja.Count() == 0)
            {
                Message("GERANDO LOJA");
                List<Loja> Lojas = GenerateLojaData();
                db.Loja.AddRange(Lojas);
                Message("LOJA GERADA");
            }
            else
            {
                Message("LOJA JÁ EXISTENTE");
            }
        }

        private static List<Loja> GenerateLojaData()
        {
            List<Loja> Lojas = new List<Loja>(NUM_LOJAS);
            for (int i = 0; i < NUM_LOJAS; i++)
            {
                Loja Loja = new Loja()
                {
                    Nome = "Loja " + (i + 1)
                };

                Lojas.Add(Loja);
            }

            return Lojas;
        }
        #endregion

        private static void Message(string message)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + ") " + message);
            Console.WriteLine("-------------------------");
        }
    }
}
