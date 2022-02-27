
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagment
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        CategoryDAO cateDao;
        
        public Form1()
        {
            cateDao = new CategoryDAO();
            InitializeComponent();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(name.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(unit.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn vị sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unit.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(quantity.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantity.Focus();
                return false;
            }
            else
            {
                int a;
                
                if (!Int32.TryParse(quantity.Text, out a))
                {
                    MessageBox.Show("Vui lòng nhập số lượng sản phẩm là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    quantity.Focus();
                    return false;
                }
                else
                {
                    if(Int32.Parse(quantity.Text) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng sản phẩm là nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quantity.Focus();
                        return false;
                    }
                }    
                
            }
            
            if (string.IsNullOrEmpty(price.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                price.Focus();
                return false;
            }
            else
            {
                int b;

                if (!Int32.TryParse(price.Text, out b))
                {
                    MessageBox.Show("Vui lòng nhập giá sản phẩm là số thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    price.Focus();
                    return false;
                }
                else
                {
                    if (Int32.Parse(price.Text) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá sản phẩm là số thực dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        price.Focus();
                        return false;
                    }
                }
            }
            
            
            if (string.IsNullOrEmpty(time.Text))
            {
                MessageBox.Show("Bạn chưa nhập thời gian tạo sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                time.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(cboCategory.Text))
            {
                MessageBox.Show("Bạn chưa nhập loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCategory.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(disc.Text))
            {
                MessageBox.Show("Bạn chưa nhập Discontinued loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                disc.Focus();
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                loadCategories();
                dgvProduct.DataSource = cateDao.getAllProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCategories()
        {
            cboCategory.DataSource = new CategoryDAO().getAllCategory().Tables[0];
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DisplayMember = "CategoryName";

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool checkIdExist(string id)
        {
            foreach(string i in cateDao.listProductId())
            {
                if (i.Equals(id))
                {
                    return true;
                }
                
            }
            return false;
        }

        private bool checkProductId()
        {
            string msg ="";
            
            if (!Regex.IsMatch(id.Text.Trim(), @"^P\d{4}$"))
            {
                msg = "Incorrect format. Ex: P1234.";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (checkIdExist(id.Text.Trim())) 
                {
                    msg = "Id đã tồn tại. ";
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
            
                
            

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (checkProductId())
                {
                    Product p = new Product();
                    p.ProductId = id.Text;
                    p.ProductName = name.Text;
                    p.Unit = unit.Text;
                    p.Quantity = int.Parse(quantity.Text);
                    p.Price = int.Parse(price.Text);
                    p.Discontinued = disc.Text;
                    p.CreateDate = time.Text;
                    p.CategoryId = (string)cboCategory.SelectedValue;

                    if (cateDao.insert(p))
                    {
                        dgvProduct.DataSource = cateDao.getAllProduct();
                        id.Text = "";
                        name.Text = "";
                        unit.Text = "";
                        quantity.Text = "";
                        price.Text = "";
                        disc.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin hãy thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        Product pr;
        private void dataGridViewProduct_cellContent(object sender, DataGridViewCellEventArgs e)
        {
            pr = new Product();
            int index = e.RowIndex;
            if (index >= 0)
            {
                
                pr.ProductId = dgvProduct.Rows[index].Cells["idV"].Value.ToString();
                //id.Text = dgvProduct.Rows[index].Cells["idV"].Value.ToString();
                pr.ProductName = dgvProduct.Rows[index].Cells["nameV"].Value.ToString();
                pr.Unit = dgvProduct.Rows[index].Cells["unitV"].Value.ToString();
                pr.Quantity = Int32.Parse(dgvProduct.Rows[index].Cells["quantityV"].Value.ToString());
                pr.Price = Int32.Parse(dgvProduct.Rows[index].Cells["priceV"].Value.ToString());
                pr.Discontinued = dgvProduct.Rows[index].Cells["discon"].Value.ToString();
                pr.CreateDate = dgvProduct.Rows[index].Cells["timeV"].Value.ToString();
                pr.CategoryId = dgvProduct.Rows[index].Cells["CateV"].Value.ToString();
            }
            
            
        }

        private void edit_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                Product p = new Product();
                p.ProductId = id.Text;
                p.ProductName = name.Text;
                p.Unit = unit.Text;
                p.Quantity = int.Parse(quantity.Text);
                p.Price = int.Parse(price.Text);
                p.Discontinued = disc.Text;
                p.CreateDate = time.Text;
                p.CategoryId = (string)cboCategory.SelectedValue;

                if (cateDao.update(p))
                {
                    dgvProduct.DataSource = cateDao.getAllProduct();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin hãy thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }



        private void delete_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dgvProduct.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["Selected"].Value) == true
                                                  select row).ToList();
            if (MessageBox.Show(string.Format("Do you want to delete {0} rows?", selectedRows.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in selectedRows)
                {


                    Product p = new Product();
                    p.ProductId = (string)row.Cells["idV"].Value;
                    cateDao.delete(p);       
                        
                    
                }

                Form1_Load(sender, e);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllocConsole();
            Console.WriteLine(pr.ProductId);
            Console.WriteLine(pr.ProductName);
            Console.WriteLine(pr.Unit);
            Console.WriteLine(pr.Quantity);
            Console.WriteLine(pr.Price);
            Console.WriteLine(pr.Discontinued);
            Console.WriteLine(pr.CreateDate);
            Console.WriteLine(pr.CategoryId);
            //foreach (DataGridViewRow row in dgvProduct.Rows)
            //{
            //    Console.WriteLine("id"+row.Cells[0].Value);
            //    Console.WriteLine("id" + row.Cells[1].Value);
            //    Console.WriteLine("name" + row.Cells[2].Value);
            //    Console.WriteLine("cate" + row.Cells[3].Value);
            //    Console.WriteLine("unit" + row.Cells[4].Value);
            //    Console.WriteLine("Price" + row.Cells[5].Value);
            //    Console.WriteLine("quantity" + row.Cells[6].Value);
            //    Console.WriteLine("disc" + row.Cells[7].Value);
            //    Console.WriteLine("date" + row.Cells[8].Value);
            //}


        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //AllocConsole();
            //Console.WriteLine(pr.ProductId);
            //Console.WriteLine(pr.ProductName);
            //Console.WriteLine(pr.Unit);
            //Console.WriteLine(pr.Quantity);
            //Console.WriteLine(pr.Price);
            //Console.WriteLine(pr.Discontinued);
            //Console.WriteLine(pr.CreateDate);
            //Console.WriteLine(pr.CategoryId);
            if(dgvProduct.Columns[e.ColumnIndex].Name == "editC")
            {
                FormEdit f = new FormEdit(pr.ProductId, pr.ProductName, pr.Quantity
                , pr.Price, pr.Discontinued, pr.CategoryId, pr.Unit, pr.CreateDate);
                
               // f.ShowDialog();
                f.Show();
                
                this.Hide();
               
            }
            
        }

        

        private void editChange_Click(object sender, EventArgs e)
        {
           
        }
    }
}
