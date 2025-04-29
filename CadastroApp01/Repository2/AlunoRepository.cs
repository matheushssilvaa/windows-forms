using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository2
{
    public class AlunoRepository
    {
        // Atributo de classe
        List<Aluno> database = new List<Aluno>();

        public AlunoRepository()
        {
            Aluno a1 = new Aluno();
            a1.Ra = "222";
            a1.Nome = "Aluno da Silva 1";
            a1.Curso = "Administração";

            Aluno a2 = new Aluno();
            a2.Ra = "333";
            a2.Nome = "Aluno da Silva 2";
            a2.Curso = "Pedagogia";

            Aluno a3 = new Aluno();
            a3.Ra = "444";
            a3.Nome = "Aluno da Silva 3";
            a3.Curso = "ADS";

            database.Add(a1);
            database.Add(a2);
            database.Add(a3);
            //gdvAlunos.DataSource = database;

        }

        public void insert(Aluno a)
        {
            database.Add(a);
        }

        public void update(Aluno a)
        {
            for(int i = 0; i < database.Count; i++)
            {
                if(a.Ra == database[i].Ra) // verificando se o ra do parâmetro da função corresponde a posição do valor do loop
                {
                    database[i] = a; // pegando o valor da posição atual do loop
                    return;
                }
            }
        }

        public void delete(string ra)
        {
            for (int i = 0; i < database.Count; i++)
            {
                if (ra == database[i].Ra)
                {
                    database.RemoveAt(i);
                    return;
                }
            }
        }

        public List<Aluno> getAll()
        {
            return database;
        }

        public Aluno getByRa(string ra)
        {
            for(int i = 0; i < database.Count; i++)
            {
                if(ra == database[i].Ra)
                {
                    return database[i];
                }
            }
            return null;
        }
    }
}
