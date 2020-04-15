using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gepv.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
    } 
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
       
    }  
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
       
    } 
    public class Entrada
    {
        [Key]
        public int Id { get; set; }
        public Produtos Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Datachegada { get; set; }
        public ApplicationUser Usuario { get; set; }
       
    }
    public class Saida
    {
        [Key]
        public int Id { get; set; }
        public Produtos Produto { get; set; }
        public Cliente Cliente { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataSaida { get; set; }
        public ApplicationUser Usuario { get; set; }

    }
     public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
       
       
    }


}