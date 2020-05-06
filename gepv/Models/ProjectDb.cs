using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gepv.Models
{
    public class AdminUserViewModel
    {
        public string UserName { get; set; }
        public string RankName { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string RankId { get; set; }
    }

    public class AdminEditViewModel
    {
        public string UserName { get; set; }
        public string RankName { get; set; }
        public string Email { get; set; }
    }
    public class AdminRoleViewModel
    {
        public string Role { get; set; }
        public string RoleId { get; set; }
        public string RoleValue { get; set; }
    }
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
        public double Preco { get; set; }
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


    public static class ExtensionMethods
    {
        public static string TransformNumberToString(this int number)
        {
            switch (number.ToString().Length)
            {
                case 1:
                case 2:
                case 3:
                    return number.ToString();
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                default:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}m";
            }
        }

        public static string SaidadosNumeros(this int number)
        {
            switch (number.ToString().Length)
            {
                case 1:
                case 2:
                case 3:
                    return number.ToString();
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                default:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}m";
            }
        }

        public static string FormatDateTime(this DateTime dateTime, string cultureInfo)
        {
            if (cultureInfo.Equals("pt"))
                return string.Format("{0:d MMMM, yyyy | HH:mm:ss}", System.Convert.ToDateTime(dateTime));
            else
                return string.Format("{0:MMMM d, yyyy | HH:mm:ss}", System.Convert.ToDateTime(dateTime));
        }

        public static DateTime TransformLongToDateTime(this long value)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(value).ToLocalTime();
        }

        public static string RemoveAccents(this string texto)
        {
            string listA = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string listB = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int a = 0; a < listA.Length; a++)
            {
                texto = texto.Replace(listA[a].ToString(), listB[a].ToString());
            }

            return texto;
        }
    }

}