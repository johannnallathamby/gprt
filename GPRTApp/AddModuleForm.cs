﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRTApp
{
    public partial class AddModuleForm : Form
    {
        private ModulesForm parent;
        public AddModuleForm(String seletedLevel, ModulesForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.levelComboBox.SelectedItem = seletedLevel;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var addAssesmentForm = new AssesmentForm(levelComboBox.SelectedItem.ToString().Replace(" ", ""),
                titleTextBox.Text, Convert.ToInt32(assesmentCountTextBox.Value));
            addAssesmentForm.ShowDialog();

            switch (levelComboBox.SelectedItem.ToString())
            {
                case "Level 4":
                    AddItemsToDataGrid(parent.level4GridView, 
                        titleTextBox.Text, codeTextBox.Text, creditValueTextBox.Text);
                    break;
                case "Level 5":
                    AddItemsToDataGrid(parent.level5GridView,
                       titleTextBox.Text, codeTextBox.Text, creditValueTextBox.Text);
                    break;
                case "Level 6":
                    AddItemsToDataGrid(parent.level6GridView,
                       titleTextBox.Text, codeTextBox.Text, creditValueTextBox.Text);
                    break;
            }
            parent.Show();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void AddItemsToDataGrid(DataGridView dataGridView, string moduleName,
            string predictedMark,
            string actualMark)
        {
            var dataSet = (DataSet)dataGridView.DataSource;
            var table = dataSet.Tables[0];
            table.Rows.Add(moduleName, predictedMark, actualMark);
        }
    }
}
