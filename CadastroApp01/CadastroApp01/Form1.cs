using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Services;

namespace CadastroApp01
{
    public partial class Form1 : Form
    {
        AlunoService alunoService = new AlunoService();
        string raSelecionado = "";
        public Form1()
        {
            InitializeComponent();
            carregarDados();
            txtRa.Enabled = false;
            txtNome.Enabled = false;
            txtCurso.Enabled = false;
        }

        public void carregarDados()
        {
            List<Aluno> alunos = this.alunoService.getAllAlunos();
            gdvAlunos.DataSource = null;
            gdvAlunos.DataSource = alunos;
            gdvAlunos.Refresh();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Ra = txtRa.Text;
            aluno.Nome = txtNome.Text;
            aluno.Curso = txtCurso.Text;

            this.alunoService.save(aluno);
            carregarDados();

            txtRa.Enabled = false;
            txtNome.Enabled = false;
            txtCurso.Enabled = false;
        }

        private void gdvAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            raSelecionado = gdvAlunos.Rows[1].Cells[0].Value.ToString(); // selecionando a linha que clica, selecione o primeiro campo da celula pega o valor e converte para string

            Aluno aluno = this.alunoService.getByRa(raSelecionado);
            txtRa.Text = aluno.Ra;
            txtNome.Text = aluno.Nome;
            txtCurso.Text = aluno.Curso;
            
            //MessageBox.Show($"Clicou na célula {e.RowIndex} e o RA: {ra}");
            
        }

        private void btnRemover_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            this.alunoService.delete(raSelecionado);
            carregarDados();
            raSelecionado = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCurso.Clear();
            txtNome.Clear();
            txtRa.Clear();
            txtRa.Enabled = true;
            txtNome.Enabled = true;
            txtCurso.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtRa.Enabled = false;
            txtNome.Enabled = true;
            txtCurso.Enabled = true;
            txtRa.Focus();
        }
    }
}
