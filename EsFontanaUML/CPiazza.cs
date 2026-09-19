using System;
using System.Collections.Generic;
using System.Text;

namespace EsFontanaUML
{
    public class CPiazza : CFontana
    {
        private float diametro;
        private string città;
        private string nomepiazza;

        public float Diametro
        {
            get => diametro;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Inserisci un valore valido del diametro della piazza");
                diametro = value;
            }
        }

        protected string Città
        {
            get => città;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un nome valido per la città");
                città = value;
            }
        }

        protected string NomePiazza
        {
            get => nomepiazza;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un nome valido della piazza");
                nomepiazza = value;
            }
        }

        public CPiazza(string Nome, float ConsumoAcqua, bool Stato, string Autore, float diametro, string città, string nomepiazza) : base (Nome,ConsumoAcqua, Stato, Autore)
        {
            this.Diametro = diametro;
            this.Città = città;
            this.NomePiazza = nomepiazza;
        }

        public override string print()
        {

            return base.print() + $"\n Diametro della piazza : {diametro} \n Città dove si trova la piazza: {città} \n Nome della piazza: {nomepiazza}";
        }
        public float CalcolaArea()
        {
            return (float)Math.PI * (Diametro * Diametro / 4);
        } 
    }
}
