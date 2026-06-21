using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao_m8_Alvaro_Dieisson_Kaio_Matheus.Execoes
{
    public class LivroNaoEncontradoExepition : Exception
    {
        public LivroNaoEncontradoExepition(string mensagem) : base(mensagem)
        {
        }
    }
}
