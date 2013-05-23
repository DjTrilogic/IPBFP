using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using IcePhoenixAPI;
using IcePhoenixAPI.Account;
using IcePhoenixAPI.Plugins;

namespace IPB_TEST
{
    public class FightAgain : IPluginProgram
    {
        private IIcePhoenix _phoenix;
        private Container _container;
        public void OnUnload()
        {
            _phoenix.DeletePage("FightAgain");
        }

        public Image Icone
        {
            get;
            private set;
        }
        public string Author
        {
            get { return "DjTrilogic"; }
        }
        public string Name
        {
            get { return "FightAgain"; }
        }
        public string Version
        {
            get { return "1.0.0.0"; }
        }
        public void OnLoad(IIcePhoenix eIcePhoenix)
        {
            // events de connexion/déconnexion de comptes
            eIcePhoenix.AccountConnected += AddAccount;
            eIcePhoenix.AccountDisconnected += RemoveAccount;

            _phoenix = eIcePhoenix;
            _container = new Container();
            _container.Dock = DockStyle.Fill;
            eIcePhoenix.AddPage("FightAgain", _container);
            foreach (var account in eIcePhoenix.AccountsList)
            {
                _container.FightAgainInterface.AccountList.Items.Add(account);
            }
            _container.FightAgainInterface.Console.Items.Add(new Notification("FightAgain a été chargé avec succès"));
        }

        private void RemoveAccount(object sender, IAccount account)
        {
            _container.FightAgainInterface.Console.Items.Add(new Notification(account.AccountName + " s'est déconnecté...", NotificationType.Fail));
        }

        public void AddAccount(object o, IAccount account)
        {
            _container.FightAgainInterface.Console.Items.Add(new Notification(account.AccountName+" s'est connecté..."));
            _container.FightAgainInterface.AccountList.Items.Add(account);
        }
    }
}
