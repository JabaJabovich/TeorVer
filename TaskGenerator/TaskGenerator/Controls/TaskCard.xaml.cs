﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskGenerator.Controls
{
	/// <summary>
	/// Логика взаимодействия для TaskCard.xaml
	/// </summary>
	public partial class TaskCard : UserControl
	{
		public static readonly DependencyProperty PresentTask =
		DependencyProperty.Register("task", typeof(Task), typeof(TaskCard), new UIPropertyMetadata(new Task(), OnIntValuePropertyChanged));

		private static void OnIntValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Task newTask = (Task)e.NewValue;
			TaskCard instance = (TaskCard)d;
			Console.WriteLine("set");

			instance.setTask(newTask);
		}


		public Task task {
			get {

				return (Task)GetValue(PresentTask);
			}
			set {
				Console.WriteLine("hi");

				SetValue(PresentTask, value);

			}
		}

		public Task presentedTask;
		public int cardIndex = 0;
		public TaskCard()
		{
			Console.WriteLine("create");
			InitializeComponent();
			try {
				taskUpdate += ((MainWindow)Application.Current.MainWindow).updateTask;
				taskSubtypeUpdate += ((MainWindow)Application.Current.MainWindow).updateTaskSubtype;
			} catch {

			}
		}

		public delegate void onUpdateTask(int index);
		public event onUpdateTask taskUpdate;
		public event onUpdateTask taskSubtypeUpdate;

		public void setTask(Task t) {
			presentedTask = t;
			var title = (TextBlock)FindName("taskNum");
			var condition = (TextBlock)FindName("condition");
			var answer = (TextBlock)FindName("answer");

			title.Text = "Задача " + t.type;
			condition.Text = t.conditionWithQuestions;

			var answers = "";
			t.answers.ForEach(x => { answers += x + "\n"; });
			answers = answers.Remove(answers.Length - 1);
			answer.Text = answers;
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			taskUpdate(0);
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			taskSubtypeUpdate(0);
		}
	}
}
