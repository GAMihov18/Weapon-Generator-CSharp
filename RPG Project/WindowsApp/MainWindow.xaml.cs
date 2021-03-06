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
using Generators.WeaponGenerators;
using LogSystemLib;
using System.Threading;
using WeaponGenerator;
using System.IO;

namespace WeaponGenerator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static List<Weapon> weapons = new List<Weapon>();
		List<ListViewItem> listViewItems = new List<ListViewItem>();

		public MainWindow()
		{
			InitializeComponent();
		}
		delegate void Caller(object sender,MouseButtonEventArgs ev);
		private void weaponItem_DoubleClick(object sender, EventArgs ev)
		{
			MouseButtonEventArgs e = ev as MouseButtonEventArgs;
			ListViewItem item = sender as ListViewItem;
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
			StreamWriter weaponLog = new StreamWriter("generated_weapons.txt",false);
			if (int.TryParse(NumberOfWeaponsTB.Text, out num))
			{
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
					weaponLog.WriteLine("Name:Assembly Damage:Physical Damage:Magical Damage:Crit Multiplier:Crit Chance:Rarity:Weapon Type:Main Damage Type: Physical Damage Type:Magical Damage Type");
					for (int i = 0; i < num; i++)
					{
						weaponLog.WriteLine(weapons[i].GetWeaponData(false));
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
				DateTime end = DateTime.Now;
				MessageBoxImage icon = MessageBoxImage.Information;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Weapons successfully generated", "Info", button, icon);
				//End generation timer and log in logfile
				
			}
			else
			{
				MessageBoxImage icon = MessageBoxImage.Error;
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBox.Show("Please enter a number", "Incorrect Input", button, icon);
			}
			weaponLog.Close();
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
			Application.Current.Shutdown();
		}

        private void OpenLogWindowButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}