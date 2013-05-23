using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
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
using IPB_TEST.Annotations;
using IcePhoenixAPI.Account;

namespace IPB_TEST
{
    /// <summary>
    /// Interaction logic for FightAgainFrom.xaml
    /// </summary>
    public partial class FightAgainForm : UserControl,INotifyPropertyChanged
    {
        public ObservableCollection<Group> Groups
        {
            get; 
            set;
        }

        public FightAgainForm()
        {
            InitializeComponent();
            DataContext = this;
            Groups = new ObservableCollection<Group>();
        }

        private void AddGroupe_OnClick(object sender, RoutedEventArgs e)
        {
            if (NewGroupName.Text != "")
            {
                var group = new Group(NewGroupName.Text);
                Groups.Add(group);
                SelectedGroup.SelectedItem = group;
                CurrentGroup.DataContext = group;
                NewGroupName.Text = "";
                
            }
        }

        private void RemoveGroupe_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup.SelectedItem != null)
            {
                foreach (var group in Groups)
                {
                    if (group.Name == ((Group) SelectedGroup.SelectedItem).Name)
                    {
                        foreach (var account in group.Accounts)
                        {
                            AccountList.Items.Add(account);
                        }
                        if (SelectedGroup.Items.Count > 0)
                        {
                            SelectedGroup.SelectedItem = SelectedGroup.Items[0];
                            CurrentGroup.DataContext = SelectedGroup.Items[0];
                        }
                        else
                        {
                            CurrentGroup.DataContext = null;
                            CurrentGroup.Items.Clear();
                        }
                        Groups.Remove(group);
                        break;
                    }
                }
            }
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (AccountList.SelectedItem != null && SelectedGroup.SelectedItem != null)
            {
                ((Group)SelectedGroup.SelectedItem).Accounts.Add((IAccount)AccountList.SelectedItem);
                AccountList.Items.Remove(AccountList.SelectedItem);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (CurrentGroup.SelectedItem != null)
            {
                var account = (IAccount)CurrentGroup.SelectedItem;
                ((Group)SelectedGroup.SelectedItem).Accounts.Remove(account);
                AccountList.Items.Add(account);
            }
        }

        private void SelectedGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedGroup.SelectedItem != null)
            {
                CurrentGroup.DataContext = SelectedGroup.SelectedItem;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
