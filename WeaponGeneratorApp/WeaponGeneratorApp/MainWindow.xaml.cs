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
namespace WeaponGenerator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Weapon> weapons = new List<Weapon>();
		int totalGeneratedWeapons = 0;
		Log log = new Log("log.txt",true);
		
		public MainWindow()
		{
			log.LogInfo($"Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
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
			Log log = new Log("generatedWeapons.txt", true);
			log.Clear();
			int num;

			if (int.TryParse(NumberOfWeaponsTB.Text, out num))
			{
				weapons.Clear();
				totalGeneratedWeapons += num;
				for (int i = 0; i < num; i++)
				{

					weapons.Add(new Weapon());
					ListViewItem weaponItem = new ListViewItem();
					weaponItem.Tag = i;
					weaponItem.Name = "WeaponName";
					weaponItem.Content = weapons[i].Name;
					weaponItem.MouseDoubleClick += weaponItem_DoubleClick;
					listOfWeapons.Items.Add(weaponItem);
				}
				if ((bool)SaveWeapon.IsChecked)
				{
					for (int i = 0; i < num; i++)
					{
						log.LogText(weapons[i].GetWeaponData(false));
					}
					MessageBoxImage icon = MessageBoxImage.Information;
					MessageBoxButton button = MessageBoxButton.OK;
					MessageBox.Show("Weapons successfully generated", "Info", button, icon);
				}
				NumberOfWeaponsTB.Clear();
			}
			else
			{
				MessageBoxImage icon = MessageBoxImage.Error;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Please enter a number", "Incorrect Input", button, icon);
				NumberOfWeaponsTB.Clear();
			}

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
			log.LogInfo("End of log\n-----------------");
			Application.Current.Shutdown();
		}
	}
}