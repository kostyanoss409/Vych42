using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace ComputationalMath42
{
    public partial class Form1 : Form
    {
        string path = "..\\..\\input.txt";
        double[,] Phi = null;
        double[,] Psi = null;
        double[] Coefficients = null;
        int PolynomialDegree = 0;
        PointPairList PointsFromFileList = new PointPairList();
        PointPairList PointsForPolynomialList = new PointPairList();
        LineItem CurveUser;
        public Form1()
        {
            InitializeComponent();
            ChartSetup();
        }
        public double F(double x) { return (Math.Pow(Math.E, (-1) * x) * Math.Cos(x)) + ((x * x) * Math.Sin(x)); }
        private double FBase(int i, double x) { return (Math.Pow(x, i)* Math.Sqrt(Math.Pow(x, i))); }
        //Вычисление значений набора ЛН ф-ций
        private bool Calculate_Phi()
        {
            //Отлов исключений при выходе значений за диапазон double
            try
            {
                //Цикл по строкам
                for (int i = 0; i <= PolynomialDegree; i++)
                {
                    //Цикл по столбцам
                    for (int j = 0; j < PointsFromFileList.Count; j++)
                    {
                        Phi[i, j] = FBase(i, PointsFromFileList[j].X);
                        //Проверка на соответствие формату double
                        if (Double.IsNaN(Phi[i, j]) || Double.IsInfinity(Phi[i, j]))
                            throw new Exception("Полином невозможен на стадии Фи");
                    }
                }
                return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message, "Ошибка");
                return false;
            }
        }
        //Ортонормирование набора ЛН ф-ций
        private bool Calculate_Psi()
        {
            try  //Отлов исключений при вычислении
            {
                double[] fi = new double[PointsFromFileList.Count];
                //Цикл по столбцам
                for (int i = 0; i <= PolynomialDegree; i++)
                {
                    //Вычисление первого слагаемого
                    for (int j = 0; j < Phi.GetLength(1); j++)
                    { fi[j] = Phi[i, j]; }
                    //Вычисление последующих слагаемыех
                    for (int j = 0; j < i; j++)
                    {
                        for (int k = 0; k < Phi.GetLength(1); k++)
                            Psi[j, i] += fi[k] * Phi[j, k];
                        for (int k = 0; k < Phi.GetLength(1); k++)
                            Phi[i, k] -= Psi[j, i] * Phi[j, k];
                    }
                    double norma = 0.0;
                    //Вычисление нормы
                    for (int j = 0; j < Phi.GetLength(1); j++)
                    { norma += Phi[i, j] * Phi[i, j]; }
                    Psi[i, i] = Math.Sqrt(norma);
                    //Нормирование
                    for (int j = 0; j < Phi.GetLength(1); j++)
                        Phi[i, j] /= Psi[i, i];
                }
                return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message, "Ошибка");
                return false;
            }
        }
        private bool Calculate_A()
        {
            try //Отлов исключений при выходе значений за диапазон double
            {
                //Вычисление коэффициентов
                for (int i = 0; i <= PolynomialDegree; i++)
                {
                    //Скалярное произведение значений функции из файла и значений ортонормированной системы
                    for (int j = 0; j < PointsFromFileList.Count; j++)
                    { Coefficients[i] += PointsFromFileList[j].Y * Phi[i, j]; }
                    //Проверка на соответствие формату double
                    if (Double.IsNaN(Coefficients[i]) || Double.IsInfinity(Coefficients[i]))
                        throw new Exception("Полином невозможен на стадии Скаляра");
                }
                return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message, "Ошибка");
                return false;
            }
        }        
        private void TurnNull() //Обнуление массивов
        {
            Phi = null;
            Psi = null;
            Coefficients = null;
        }
        //Вызов функций для ортонормализации
        private bool Orthonormalization()
        {
            Phi = new double[PolynomialDegree + 1, PointsFromFileList.Count];
            //Если выполнить функцию не удалось, передается флаг, чтобы аппроксимация не продолжала выполнятся
            if (Calculate_Phi() == false)
            {
                TurnNull();
                return false;
            }
            //Если выполнить функцию не удалось, передается флаг, чтобы аппроксимация не продолжала выполнятся
            Psi = new double[PolynomialDegree + 1, PointsFromFileList.Count];
            if (Calculate_Psi() == false)
            {
                TurnNull();
                return false;
            }
            //Если выполнить функцию не удалось, передается флаг, чтобы аппроксимация не продолжала выполнятся
            Coefficients = new double[PolynomialDegree + 1];
            if (Calculate_A() == false)
            {
                TurnNull();
                return false;
            }
            return true;
        }
        //Вычисление значений полинома
        private void CalculatePolynomial()
        {
            //Цикл по значениям x
            for (int i = 0; i < PointsFromFileList.Count; i++)
            {
                double y = 0.0;
                //Вычисления конкретного значения полинома
                for (int j = 0; j <= PolynomialDegree; j++)
                    y += Coefficients[j] * Psi_Special(j, PointsFromFileList[i].X);
                PointsForPolynomialList.Add(PointsFromFileList[i].X, y);
            }
            PointsForPolynomialList.Sort();
        }
        //Вычисление набора ортонормированных ф-ций для полинома
        private double Psi_Special(int i, double x)
        {
            double result = FBase(i, x);
            double[] V = new double[i];
            for (int j = 0; j < i; j++)
            {
                V[j] = FBase(j, x);
                for (int k = 0; k < j; k++)
                    V[j] -= Psi[k, j] * V[k];
                V[j] /= Psi[j, j];
                result -= Psi[j, i] * V[j];
            }
            result /= Psi[i, i];
            return result;
        }
        private void WriteValuesToFile_Click(object sender, EventArgs e)
        {
            try
            {
                double RightLimit = 0, LeftLimit = 0, Step;
                RightLimit = Convert.ToDouble(XMax.Text);
                LeftLimit = Convert.ToDouble(XMin.Text);
                if (LeftLimit <= 0) throw new Exception("Я требую чего-то большего, чем ноль.");
                if (RightLimit <= LeftLimit) throw new Exception("Человек будущего может жульничать сегодня.");
                int PointsCount = Convert.ToInt32(AmountOfPoints.Text);
                Step = Math.Round((RightLimit - LeftLimit) / (PointsCount - 1), 15, MidpointRounding.AwayFromZero);
                if (PointsCount < 2) throw new Exception("Твой минимум - две точки.");
                StreamWriter Out = new StreamWriter(path);
                double x = LeftLimit;
                for (int i = 1; i < PointsCount; i++)
                {
                    Out.WriteLine(x + " " + F(x));
                    x += Step;
                }
                Out.WriteLine(RightLimit + " " + F(RightLimit));
                Out.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Позволь входным значениям существовать.", "Ошибка");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
        private void OpenFile_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start(path); }
        private void Draw_Click(object sender, EventArgs e)
        {
            try
            {
                if (Degree.Text == "") { throw new ApplicationException("Дай мне степень не ученую, но полинома."); }
                PointsFromFileList.Clear();
                GraphPane pane = zedGraphControl1.GraphPane;
                pane.XAxis.MinAuto = true;
                pane.XAxis.MaxAuto = true;
                pane.YAxis.MinAuto = true;
                pane.YAxis.MaxAuto = true;
                pane.CurveList.Clear();
                PointsForPolynomialList.Clear();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                int n = 0;
                PolynomialDegree = Convert.ToInt32(Degree.Text);
                StreamReader IN = new StreamReader(path);
                string FileData = IN.ReadToEnd();
                IN.Close();
                string[] OrderData = FileData.Split(' ', '\n');
                n = 0;
                for (int i = 0; i < OrderData.Length - 1; i += 2)
                {
                    n++;
                    PointsFromFileList.Add(double.Parse(OrderData[i]), double.Parse(OrderData[i + 1]));
                }
                if (PolynomialDegree >= n)
                    throw new ApplicationException("Число точек опережает степень полинома. Доминус эт деус ностер сик фиери юбет");
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (PointsFromFileList[i].X == PointsFromFileList[j].X)
                        MessageBox.Show("Некоторые значения Х повторяются. Я построю график, но тебе стоит проверить свои источники.");
                    }
                }
                PointsFromFileList.Sort();
                TurnNull();
                //Проверка корректного выполнения ортонормирования
                if (Orthonormalization() == false)
                    return;
                CalculatePolynomial();
                LineItem CurveOLS = pane.AddCurve("Аппроксимация", PointsForPolynomialList, Color.Red, SymbolType.None);
                CurveOLS.Line.Width = 2;
                LineItem CurveFromFile = pane.AddCurve("y(x)", PointsFromFileList, Color.Blue, SymbolType.Square);
                CurveFromFile.Line.Width = 3;
                CurveFromFile.Line.IsVisible = false;
                CurveFromFile.Symbol.Fill.Color = Color.SkyBlue;
                CurveFromFile.Symbol.Fill.Type = FillType.Solid;
                CurveFromFile.Symbol.Size = 4;
                pane.XAxis.Min = PointsForPolynomialList[0].X;
                pane.XAxis.Max = PointsForPolynomialList[PointsForPolynomialList.Count - 1].X;
                pane.YAxis.MinAuto = true;
                pane.YAxis.MaxAuto = true;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            catch (FileLoadException) { MessageBox.Show("404", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Наверное, это эльфийский", "Ошибка"); }
            catch (ArgumentOutOfRangeException)
            { MessageBox.Show("Файл пуст, и он чувствует себя понедельником. Позволь ему быть ночью субботы.", "Ошибка"); }
            catch (OverflowException) { MessageBox.Show("Римский император ограничен Римом.", "Ошибка"); }
            catch (Exception ea) { MessageBox.Show(ea.Message, "Ошибка"); }
        }
        private void AmountOfPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8)))
            { e.Handled = true; }
        }
        private void Degree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)8) && (e.KeyChar < (char)48 || e.KeyChar > (char)57))
                e.Handled = true;
            if (e.KeyChar == '0' && Degree.Text.Length == 0)
                e.Handled = true;
        }
        private void XUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8) || (e.KeyChar == '-') || (e.KeyChar == '.')))
            { e.Handled = true; }
            if ((e.KeyChar == '.'))
            {
                if ((XUserText.Text.IndexOf('.') != (-1)))
                    e.Handled = true;
            }
            if (XUserText.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                    e.Handled = true;
            }
        }
        private void XMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8) || (e.KeyChar == '-') || (e.KeyChar == '.')))
            { e.Handled = true; }
            if ((e.KeyChar == '.'))
            {
                if ((XMin.Text.IndexOf('.') != (-1)))
                    e.Handled = true;
            }
            if (XMin.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                    e.Handled = true;
            }
        }
        private void XMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8) || (e.KeyChar == '-') || (e.KeyChar == '.')))
            { e.Handled = true; }
            if ((e.KeyChar == '.'))
            {
                if ((XMax.Text.IndexOf('.') != (-1)))
                    e.Handled = true;
            }
            if (XMax.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                    e.Handled = true;
            }
        }
        private void CalculateUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (XUserText.Text == "") { throw new ApplicationException("Любая собака твой поводырь, если тебе неважно куда идти."); }
                for (int Counter = 0; Counter <= PolynomialDegree; Counter++)
                {
                    if (Coefficients == null)
                    { throw new ApplicationException("Я не чувствую коэффициентов полинома"); }
                }
                double XUSER = Convert.ToDouble(XUserText.Text), YUSER = 0;
                if ((XUSER < PointsForPolynomialList[0].X) || (XUSER > PointsForPolynomialList[PointsForPolynomialList.Count - 1].X))
                { throw new ApplicationException("Соблюдай границы."); }
                PointPairList PPL = new PointPairList();
                for (int j = 0; j <= PolynomialDegree; j++)
                    { YUSER += Coefficients[j] * Psi_Special(j, XUSER); }
                PPL.Add(XUSER, YUSER);
                CurveUser = zedGraphControl1.GraphPane.AddCurve("Точка", PPL, Color.Green, SymbolType.Circle);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                YUserText.Text = Convert.ToString(YUSER);
            }
            catch (FormatException)
            { MessageBox.Show("Наверное, это эльфийский", "Ошибка"); }
            catch (Exception ea) { MessageBox.Show(ea.Message, "Ошибка");}
        }
        private void ChartSetup()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.MinAuto = true;
            pane.XAxis.MaxAuto = true;
            pane.YAxis.MinAuto = true;
            pane.YAxis.MaxAuto = true;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            pane.XAxis.Title = "Ось X";
            pane.YAxis.Title = "Ось Y";
            pane.Title = "График функции y(x) = e^(-x)*cos(x)+ x^2*sin(x)";
            pane.XAxis.IsVisible = true;
            pane.YAxis.IsVisible = true;
            pane.XAxis.IsZeroLine = false;
            pane.YAxis.IsZeroLine = false;
        }
    }
}