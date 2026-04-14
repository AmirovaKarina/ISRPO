using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Windows.Forms;
using TestApp.Database;
using TestApp.Debugging;
using TestApp.Models;
using TestApp.Solvers;

namespace TestApp
{
    public partial class Form1 : Form
    {
        private List<Item> _allItems;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseTester.TestConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (new ExecutionTimer("Загрузка и отображение исходных данных"))
            {
                try
                {
                    _allItems = DatabaseHelper.LoadItems();
                    DisplayItemsInListView(_allItems, listView1);
                    DebugLogger.Log($"Отображено {_allItems.Count} предметов");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DebugLogger.Log($"Ошибка в btnShowData_Click: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_allItems == null || _allItems.Count == 0)
            {
                MessageBox.Show("Сначала загрузите исходные данные.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int maxWeight) || maxWeight <= 0)
            {
                MessageBox.Show("Введите корректный максимальный вес (целое положительное число).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (new ExecutionTimer($"Решение задачи о рюкзаке (вес до {maxWeight})"))
            {
                try
                {
                    List<Item> solution = KnapsackSolver.Solve(_allItems, maxWeight);
                    DisplayItemsInListView(solution, listView1);
                    DebugLogger.Log($"Решение найдено, количество предметов: {solution.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при решении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DebugLogger.Log($"Ошибка в btnSolve_Click: {ex.Message}");
                }
            }
        }
        private void DisplayItemsInListView(List<Item> items, ListView listView)
        {
            listView.Items.Clear();
            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Weight.ToString());
                listItem.SubItems.Add(item.Cost.ToString());
                listView.Items.Add(listItem);
            }
        }
    }
}

