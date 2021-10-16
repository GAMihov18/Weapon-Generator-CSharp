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
using System.Windows.Shapes;
using Generation.Weapons;
namespace WeaponGenerator
{
    /// <summary>
    /// Interaction logic for WeaponInfo.xaml
    /// </summary>
    public partial class WeaponInfo : Window
    {
        Weapon weapon;
        public WeaponInfo(Weapon weapon)
        {
            this.weapon = weapon;
            InitializeComponent();
            textBlock.Text = weapon.GetWeaponData(true);
        }
    }
}
