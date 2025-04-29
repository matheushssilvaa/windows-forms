using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository2;

namespace Services
{
    public class AlunoService
    {
        AlunoRepository alunoRepository = new AlunoRepository();

        public List<Aluno> getAllAlunos()
        {
            List<Aluno> alunos = this.alunoRepository.getAll();
            return alunos;
        }

        public void save(Aluno a)
        {
            // 1 - checar se o aluno existe
            List<Aluno> alunos = this.alunoRepository.getAll();
            for (int i = 0; i < alunos.Count; i++)
            {
                if (a.Ra == alunos[i].Ra)
                {
                    this.alunoRepository.update(a);
                    return;
                }
            }

            // 2 - Aluno não existe, OK para inserir
            this.alunoRepository.insert(a);
        }

        public void delete(string ra)
        {
            this.alunoRepository.delete(ra);
        }

        public Aluno getByRa(string ra)
        {
            Aluno a = this.alunoRepository.getByRa(ra);
            return a;
        }
    }
}
