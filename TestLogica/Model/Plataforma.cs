namespace TestLogica.Model
{
    public class Plataforma
    {
        public int[,] matriz;
        private int fila;
        private int columna;

        public int Fila { get { return fila; } }
        public int Columna { get { return columna; } }

        public Plataforma(int m, int n)
        {
            matriz = new int[m, n];
            fila = m;
            columna = n;
        }

        public bool Limit(int x, int y)
        {
            if (x < 0 || x > (fila - 1) )
                return true;
            if (y < 0 || y > (columna-1))
                return true;
            if (matriz[x, y] == 1)
                return true;
            return false;
        }
    }
}
