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
using WeaponGeneration;
using LogSystem;
namespace WeaponGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		List<Weapon> weapons = new List<Weapon>();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void weaponItem_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;
			Window window1 = new WeaponInfo(weapons[(int)item.Tag]);
			window1.Owner = this;
			window1.Show();

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
			Log log = new Log("generatedWeapons.txt",true);
			log.Clear();
			int num;
			
			if (int.TryParse(NumberOfWeaponsTB.Text,out num))
			{
				for (int i = 0; i < num; i++)
				{
					weapons.Add(new Weapon());
					ListViewItem weaponItem = new ListViewItem();
					weaponItem.Tag = i;
					weaponItem.Name = "WeaponName";
					weaponItem.Content = weapons[i].Name;
					weaponItem.MouseDoubleClick += weaponItem_DoubleClick ;
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
				MessageBox.Show("Please enter a number","Incorrect Input",button,icon);
				NumberOfWeaponsTB.Clear();
			}
			
		}

		
	}
}
