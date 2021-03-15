using System;
using System.Collections.Generic;
using System.Text;

namespace BCLocaliza.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }


        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valor)
        {
            if(this.Saldo - valor < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valor;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valor, Conta conta)
        {
            if(this.Sacar(valor))
            {
                conta.Depositar(valor);
            }
        }

        public override string ToString()
        {
            string retorno = $@"TipoConta {this.TipoConta} | Nome {this.Nome} | Saldo {this.Saldo:C} | Crédito {this.Credito:C}";
            return retorno;
        }
    }
}
