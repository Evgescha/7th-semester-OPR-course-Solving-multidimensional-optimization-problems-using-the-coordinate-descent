using org.mariuszgromada.math.mxparser;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

            Logger.Setup(logToDebug: true, addDateTime: false);
            Logger.MessageWrited += Logger_MessageWrited;
        }

        public Form1 Form11
        {
            get => default(Form1);
            set
            {
            }
        }

        public Point2D Point2D
        {
            get => default(Point2D);
            set
            {
            }
        }

        public Form1 Form12
        {
            get => default(Form1);
            set
            {
            }
        }

        internal GaussZeidelMethod GaussZeidelMethod
        {
            get => default(GaussZeidelMethod);
            set
            {
            }
        }

        //Запись сообщениея
        private void Logger_MessageWrited(string message)
        {
            txtLog.Text += message + Environment.NewLine;
        }

        //Тестовое задание
        double test(double x1, double x2)
        {
            Function F = new Function("F(x1,x2)="+textBox1.Text);
            Argument Ax1 = new Argument("x1", x1);
            Argument Ax2 = new Argument("x2", x2);
            Expression ex = new Expression("F(x1,x2)", F,Ax1,Ax2);
            return ex.calculate();
        }

        

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Point2D x0, h;
            double eps = 0, x0x = 0, x0y = 0, hx = 0, hy = 0;
            Point2D res;

            //Парсинг параметров
            try
            {
                x0x = double.Parse(txtX0X.Text);
                x0y = double.Parse(txtX0Y.Text);
                hx = double.Parse(txtHX.Text);
                hy = double.Parse(txtHY.Text);
                eps = double.Parse(txtEps.Text);
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Неверный ввод - не число");
                return;
            }

            x0 = new Point2D(x0x, x0y);
            h = new Point2D(hx, hy);

            //Определяем функцию
            Func<double, double, double> f;


            f = test;
            res = GaussZeidelMethod.FindMinimum(f, x0, h, eps);

            txtOut.Text = res.ToString(OptimizationUtils.GetFormat(eps));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "(x1-5)^2+(x2-6)^2";
            txtX0X.Text = "0";
            txtX0Y.Text = "0";
            txtHX.Text = "1";
            txtHY.Text = "1";
            txtEps.Text = "0,1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            
            try {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default))
                {
                    textBox1.Text = sr.ReadLine();
                    string[] xy0 = sr.ReadLine().Split(' ');
                    txtX0X.Text = xy0[0];
                    txtX0Y.Text = xy0[1];

                    xy0 = sr.ReadLine().Split(' ');
                    txtHX.Text = xy0[0];
                    txtHY.Text = xy0[1];

                    txtEps.Text = sr.ReadLine();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка чтения из файла");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            string save = $"F(x1,x2)={textBox1.Text}\nx0={txtX0X.Text}, y0={txtX0Y.Text}\nhx={txtHX.Text}, xy={txtHY.Text}\neps={txtEps.Text}\n";
            System.IO.File.WriteAllText(filename, save+txtLog.Text);
            MessageBox.Show("Файл сохранен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения файла");
            }
        }
    }
}