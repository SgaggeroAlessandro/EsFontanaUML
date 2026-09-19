using System;
using System.Collections.Generic;
using System.Text;

namespace EsFontanaUML
{
    public class CFontana
    {
        private string nome;
        private float consumoacqua;
        public bool stato {  get; set; }

        public List<string> Manutezioni =  new List<string>();
        private string autore;

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Errore, inserisci un valore valido per il nome della fontana");
                nome = value;
            }
        }

        protected float ConsumoAcqua
        {
            get => consumoacqua;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Errore, il consumo giornaliero di acqua non può essere minore di 0");
                consumoacqua = value;
            }
        }

        protected string Autore
        {
            get => autore;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Errore, inserisci un valore valido per il nome dell'autore");
                autore = value;
            }
        }

        public CFontana(string Nome, float ConsumoAcqua, bool Stato,  string Autore)
        {
            this.Nome = Nome;
            this.ConsumoAcqua = ConsumoAcqua;
            this.stato = Stato;
            this.Autore = Autore;
        }

        public void AggManute(string manutenzione)
        {
            if (string.IsNullOrEmpty(manutenzione))
            {
                Console.WriteLine("Errore, la manutenzione non può essere vuota");
                return;
            }

            Manutezioni.Add(manutenzione);
        }

        public void EliminaManute()
        {
            Manutezioni.Clear();
        }
        public virtual string print()
        {
            string s = "";
            if(stato == false)
            {
                s = "No";
            }
            else
            {
                s = "Sì";
            }
            return $"Nome della fontana: {Nome} \n Consumo acqua giornaliero della fontana: {ConsumoAcqua} \n Accesa di notte: {s} \n Nome dell'autore della fontana: {autore}";
        }

       
        public void CambiaStato()
        {
            stato = !stato; 
        }
    }
   }

