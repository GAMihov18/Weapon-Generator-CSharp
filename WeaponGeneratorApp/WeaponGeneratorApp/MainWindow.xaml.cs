using System;
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
using RFMiscLib.RandomNumber;
using Generation.Weapons;
using LogSystem;
using System.Threading;

namespace WeaponGenerator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Log logFile = new Log("log.txt", true);
		static List<Weapon> weapons = new List<Weapon>();
		List<ListViewItem> listViewItems = new List<ListViewItem>();

		public MainWindow()
		{
			logFile.LogInfo($"Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
			InitializeComponent();
		}
		delegate void Caller(object sender,MouseButtonEventArgs ev);
		private void weaponItem_DoubleClick(object sender, EventArgs ev)
		{
			MouseButtonEventArgs e = ev as MouseButtonEventArgs;
			ListViewItem item = sender as ListViewItem;
			new WeaponInfo(weapons[(int)item.Tag]).Show();
		}
		private void NumberOfWeapons_KeyPressed(object sender, EventArgs ev)
		{
			KeyEventArgs e = ev as KeyEventArgs;
			if (e.Key == Key.Enter)
			{
				GenerateWeaponsButton_Click(sender, e);
			}
		}
		private void GenerateWeaponsButton_Click(object sender, EventArgs ev)
		{
			RoutedEventArgs e = ev as RoutedEventArgs;
			int num;
			Log weaponLog = new Log("generatedWeapons.txt", true);
			weaponLog.Clear();
			if (int.TryParse(NumberOfWeaponsTB.Text, out num))
			{
				logFile.LogInfo($"Generating {num} weapons");
				//Clear previous generations
				listOfWeapons.Items.Clear();
				weapons.Clear();
				//Start generation timer
				DateTime start = DateTime.Now;
				
				for (int i = 0; i < num; i++)
				{
					weapons.Add(new Weapon());
				}

				if ((bool)SaveWeapon.IsChecked)
				{
					weaponLog.LogText("Name:Assembly Damage:Physical Damage:Magical Damage:Crit Multiplier:Crit Chance:Rarity:Weapon Type:Main Damage Type: Physical Damage Type:Magical Damage Type");
					for (int i = 0; i < num; i++)
					{
						weaponLog.LogText(weapons[i].GetWeaponData(false));
					}
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						ListViewItem weaponItem = new ListViewItem();
						weaponItem.Tag = i;
						weaponItem.Name = "WeaponName";
						weaponItem.Content = weapons[i].Name;
						weaponItem.MouseDoubleClick += weaponItem_DoubleClick;
						listOfWeapons.Items.Add(weaponItem);
					}
				}
				MessageBoxImage icon = MessageBoxImage.Information;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Weapons successfully generated", "Info", button, icon);
				//End generation timer and log in logfile
				DateTime end = DateTime.Now;
				logFile.LogInfo($"Time taken to generate {num} weapons: {end - start}");
			}
			else
			{
				MessageBoxImage icon = MessageBoxImage.Error;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Please enter a number", "Incorrect Input", button, icon);
			}
			NumberOfWeaponsTB.Clear();
		}
		private void NumberOfArmorsTB_KeyDown(object sender, EventArgs ev)
		{
			KeyEventArgs e = ev as KeyEventArgs;
			if (e.Key == Key.Enter)
			{
				GenerateArmorsButton_Click(sender, e);
			}
		}

		private void GenerateArmorsButton_Click(object sender, EventArgs ev)
		{

		}

		private void NumberOfPlayersTB_KeyDown(object sender, EventArgs ev)
		{
			KeyEventArgs e = ev as KeyEventArgs;
			if (e.Key == Key.Enter)
			{
				GeneratePlayersButton_Click(sender, e);
			}
		}

		private void GeneratePlayersButton_Click(object sender, EventArgs ev)
		{

		}

		private void GeneratorMenuButton_Click(object sender, EventArgs ev)
		{
			MainMenu.Visibility = Visibility.Collapsed;
			GeneratorMenu.Visibility = Visibility.Visible;
		}

		private void ChoosePlayerGeneration_Click(object sender, EventArgs ev)
		{
			logFile.LogInfo("Player Menu Chosen");
			WeaponGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Collapsed;
			PlayerGeneratorGrid.Visibility = Visibility.Visible;
			ChoosePlayerGeneration.Visibility = Visibility.Collapsed;
			ChooseWeaponGeneration.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Visible;
		}

		private void ChooseArmorGeneration_Click(object sender, EventArgs ev)
		{
			PlayerGeneratorGrid.Visibility = Visibility.Collapsed;
			WeaponGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Collapsed;
			ChoosePlayerGeneration.Visibility = Visibility.Visible;
			ChooseWeaponGeneration.Visibility = Visibility.Visible;
		}

		private void ChooseWeaponGeneration_Click(object sender, EventArgs ev)
		{
			PlayerGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Collapsed;
			WeaponGeneratorGrid.Visibility = Visibility.Visible;
			ChoosePlayerGeneration.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Visible;
			ChooseWeaponGeneration.Visibility = Visibility.Collapsed;
		}

		private void ChooseBackToMainMenu_Click(object sender, EventArgs ev)
		{
			GeneratorMenu.Visibility = Visibility.Collapsed;
			MainMenu.Visibility = Visibility.Visible;
		}

		private void ExitButton_Click(object sender, EventArgs ev)
		{
			logFile.LogInfo("End of log\n-----------------");
			Application.Current.Shutdown();
		}
	}
}