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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnCadClient_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=assistencia;uid=root;pwd=etec");
            conexao.Open();
            MySqlCommand cadastrar = new MySqlCommand("INSERT INTO cliente(id_cliente, nome_cliente, cnpj_cliente, endereco_cliente, num_cliente, bairro_cliente, cidade_cliente, estado_cliente) " +
                "values ("+ idCliente.Text + ",'" + nomeCliente.Text + ",'" + cnpjClient.Text +",'" + endCliente.Text + ",'" + numClient.Text + ",'" + bairroCliente.Text + ",'" + cidadeCliente.Text + ",'" + estadoCliente.Text + "');",conexao);
            cadastrar.ExecuteNonQuery();
            MessageBox.Show("Dados alterados!!!");
            idCliente.Text = "";
            nomeCliente.Text = "";
            cnpjClient.Text = "";
            endCliente.Text = "";
            numClient.Text = "";
            bairroCliente.Text = "";
            cidadeCliente.Text = "";
            estadoCliente.Text = "";


        }
    }
}
