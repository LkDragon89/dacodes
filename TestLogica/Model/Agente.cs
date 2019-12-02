namespace TestLogica.Model
{
    public class Agente
    {
        private int ejeX;
        private int ejeY;
        private ESentido eSentido;
        private Plataforma mapa;

        public bool Stop { get; set; }

        public Plataforma Mapa { set { this.mapa = value; } }

        public ESentido Sentido { get{ return eSentido; } }

        public Agente()
        {
            ejeX = 0;
            ejeY = 0;
            eSentido = ESentido.RIGTH;
        }

        public void Move()
        {
            if (eSentido == ESentido.RIGTH)
                ejeX += 1;
            if (eSentido == ESentido.LEFT)
                ejeX -= 1;
            if (eSentido == ESentido.UP)
                ejeY -= 1;
            if (eSentido == ESentido.DOWN)
                ejeY += 1;

            var limit = mapa.Limit(ejeX, ejeY);
            if(!limit)
                mapa.matriz[ejeX, ejeY] = 1;

            Stoping();
            if(!Stop)
                Validate(limit);
        }

        public void Init()
        {
            mapa.matriz[ejeX, ejeY] = 1;
        }

        private void Stoping()
        {
            int find = 0;
            for(int i = 0; i< mapa.Fila;i++)
            {
                for(int j = 0; j<mapa.Columna; j++)
                {
                    if(mapa.matriz[i,j] == 1)
                    {
                        find++;
                    }
                }
            }

            if(find == (mapa.Columna * mapa.Fila))
                Stop = true;
        }

        private void Validate(bool limit)
        {
            if (limit)
            {
                switch (eSentido)
                {
                    case ESentido.RIGTH:
                        eSentido = ESentido.DOWN;
                        ejeX -= 1;
                        break;
                    case ESentido.DOWN:
                        eSentido = ESentido.LEFT;
                        ejeY -= 1;
                        break;
                    case ESentido.LEFT:
                        eSentido = ESentido.UP;
                        ejeX += 1;
                        break;
                    case ESentido.UP:
                        eSentido = ESentido.RIGTH;
                        ejeY += 1;
                        break;
                }
            }
        }

        public enum ESentido
        {
            UP = 1,
            DOWN = 2,
            LEFT = 3,
            RIGTH = 4
        }
    }
}
