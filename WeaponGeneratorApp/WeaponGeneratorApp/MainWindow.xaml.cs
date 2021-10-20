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
		Log logFile = new Log("log.txt",true);
		List<Weapon> weapons = new List<Weapon>();
		List<ListViewItem> listViewItems = new List<ListViewItem>();
		int totalGeneratedWeapons = 0;
		public MainWindow()
		{
			logFile.Clear();
			InitializeComponent();
		}

		private void weaponItem_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;
			WeaponInfoTB.Text = weapons[(int)item.Tag].GetWeaponData(true);

		}
		private void NumberOfWeapons_KeyPressed(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				GenerateWeaponsButton_Click(sender, e);
			}
		}
		private void GenerateWeaponsButton_Click(object sender, RoutedEventArgs e)
		{
			int num;
			Log weaponLog = new Log("generatedWeapons.txt", true);
			weaponLog.Clear();
			if (int.TryParse(NumberOfWeaponsTB.Text, out num))
			{
				listOfWeapons.Items.Clear();
				DateTime start = DateTime.Now;
				weapons.Clear();
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
				DateTime end = DateTime.Now;
				logFile.LogText((end - start).ToString());
			}
			else
			{
				MessageBoxImage icon = MessageBoxImage.Error;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Please enter a number", "Incorrect Input", button, icon);
			}
			NumberOfWeaponsTB.Clear();
		}
		private void NumberOfArmorsTB_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				GenerateArmorsButton_Click(sender, e);
			}
		}

		private void GenerateArmorsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void NumberOfPlayersTB_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				GeneratePlayersButton_Click(sender, e);
			}
		}

		private void GeneratePlayersButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void GeneratorMenuButton_Click(object sender, RoutedEventArgs e)
		{
			MainMenu.Visibility = Visibility.Collapsed;
			GeneratorMenu.Visibility = Visibility.Visible;
		}

		private void ChoosePlayerGeneration_Click(object sender, RoutedEventArgs e)
		{

			WeaponGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Collapsed;
			PlayerGeneratorGrid.Visibility = Visibility.Visible;
			ChoosePlayerGeneration.Visibility = Visibility.Collapsed;
			ChooseWeaponGeneration.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Visible;
		}

		private void ChooseArmorGeneration_Click(object sender, RoutedEventArgs e)
		{
			PlayerGeneratorGrid.Visibility = Visibility.Collapsed;
			WeaponGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Collapsed;
			ChoosePlayerGeneration.Visibility = Visibility.Visible;
			ChooseWeaponGeneration.Visibility = Visibility.Visible;
		}

		private void ChooseWeaponGeneration_Click(object sender, RoutedEventArgs e)
		{
			PlayerGeneratorGrid.Visibility = Visibility.Collapsed;
			ArmorGeneratorGrid.Visibility = Visibility.Collapsed;
			WeaponGeneratorGrid.Visibility = Visibility.Visible;
			ChoosePlayerGeneration.Visibility = Visibility.Visible;
			ChooseArmorGeneration.Visibility = Visibility.Visible;
			ChooseWeaponGeneration.Visibility = Visibility.Collapsed;
		}

		private void ChooseBackToMainMenu_Click(object sender, RoutedEventArgs e)
		{
			GeneratorMenu.Visibility = Visibility.Collapsed;
			MainMenu.Visibility = Visibility.Visible;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}