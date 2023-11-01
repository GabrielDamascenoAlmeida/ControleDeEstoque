using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControleDeEstoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }

        private void CarregarDadosBanco() 
        {
            string conexao = "server=localhost;database=assistencia;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from tecnico", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvList.DataSource = dt;

        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCargo.Text = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            groupBox1.Visible = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=assistencia;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("update tecnico set nome_tec='" + txtNome.Text + "', cargo='" + txtCargo.Text + "' where id_tec=" + txtId.Text, conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Dados alterados!!!");
            txtNome.Text = "";
            txtCargo.Text = "";
            txtId.Text = "";
            groupBox1.Visible = false;
            CarregarDadosBanco();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja exluir esse técnico?", "Alerta", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                string conexao = "server=localhost;database=assistencia;uid=root;pwd=etec";
                MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("delete from tecnico where id_tec=" + txtId.Text + ";", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Técnico excluído  com sucesso!");
                txtNome.Text = "";
                txtCargo.Text = "";
                txtId.Text = "";
                groupBox1.Visible = false;
                CarregarDadosBanco();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=assistencia;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("insert into tecnico (nome_tec,cargo) values ('" + txtNome.Text + "','" + txtCargo.Text + "');", conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Cadastro realizado com sucesso!!!");
            txtNome.Text = "";
            txtCargo.Text = "";
            txtId.Text = "";
            groupBox1.Visible = false;
            CarregarDadosBanco();
        }
    }
}
