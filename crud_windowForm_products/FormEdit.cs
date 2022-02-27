using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace ProductManagment
{
    public partial class FormEdit : Form
    {
        CategoryDAO cateDao;
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public string CreateDate { get; set; }
        public int Quantity { get; set; }
        public string Discontinued { get; set; }
        public FormEdit()
        {
            
            InitializeComponent();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(idV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(nameV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(unitV.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn vị sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unitV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(quantityV.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantityV.Focus();
                return false;
            }
            else
            {
                int a;

                if (!Int32.TryParse(quantityV.Text, out a))
                {
                    MessageBox.Show("Vui lòng nhập số lượng sản phẩm là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    quantityV.Focus();
                    return false;
                }
                else
                {
                    if (Int32.Parse(quantityV.Text) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng sản phẩm là nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quantityV.Focus();
                        return false;
                    }
                }

            }

            if (string.IsNullOrEmpty(priceV.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                priceV.Focus();
                return false;
            }
            else
            {
                int b;

                if (!Int32.TryParse(priceV.Text, out b))
                {
                    MessageBox.Show("Vui lòng nhập giá sản phẩm là số thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    priceV.Focus();
                    return false;
                }
                else
                {
                    if (Int32.Parse(priceV.Text) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá sản phẩm là số thực dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        priceV.Focus();
                        return false;
                    }
                }
            }


            if (string.IsNullOrEmpty(createTimeV.Text))
            {
                MessageBox.Show("Bạn chưa nhập thời gian tạo sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                createTimeV.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(categV.Text))
            {
                MessageBox.Show("Bạn chưa nhập loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(discV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Discontinued loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                discV.Focus();
                return false;
            }
            return true;
        }

        public FormEdit(string ProductId, string ProductName, int Quantity, int Price
            , string Discontinued, string CategoryId, string Unit,string CreateDate)
        {

            InitializeComponent();
            cateDao = new CategoryDAO();
            loadCategories();
            idV.Text = ProductId.ToString();
            nameV.Text = ProductName.ToString();
            priceV.Text = Price.ToString();
            unitV.Text = Unit.ToString();
            discV.Text = Discontinued.ToString();
            quantityV.Text = Quantity.ToString();
            
            createTimeV.Text = CreateDate.ToString();
            categV.SelectedValue = CategoryId.ToString();
            //loadCategories();
            //AllocConsole();
            //Console.WriteLine(ProductId);
            //Console.WriteLine(ProductName);
            //Console.WriteLine(Unit);
            //Console.WriteLine(Quantity);
            //Console.WriteLine(Price);
            //Console.WriteLine(Discontinued);
            //Console.WriteLine(CreateDate);
            //Console.WriteLine(CategoryId);

        }

        private void loadCategories()
        {
            categV.DataSource = new CategoryDAO().getAllCategory().Tables[0];
            categV.ValueMember = "CategoryId";
            categV.DisplayMember = "CategoryName";
            

        }



        private void Save_edit_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Product p = new Product();
                p.ProductId = idV.Text;
                p.ProductName = nameV.Text;
                p.Unit = unitV.Text;
                p.Quantity = int.Parse(quantityV.Text);
                p.Price = int.Parse(priceV.Text);
                p.Discontinued = discV.Text;
                p.CreateDate = createTimeV.Text;
                p.CategoryId = (string)categV.SelectedValue;

                if (cateDao.update(p))
                {
                    Form1 form1 = new Form1();

                    this.Hide();
                    form1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin hãy thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {

            
        }
    }
}
